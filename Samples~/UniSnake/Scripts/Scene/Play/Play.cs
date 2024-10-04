using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public class Play : Entry {
    void Awake() {
      var config = this.Add(this.GetComponent<GameConfig>());
      var model = this.Add(this.GetOrAddComponent<Model>().Init(config));
      var eb = this.AddEventBus(debug: true);
      var ctx = new CommandContext(model, config, eb);
      var cb = this.AddCommandBus(ctx, debug: true);

      cb.Push(new MoveFoodCommand());

      // move snake when not paused
      var timer = new RepeatedTimer(config.moveInterval, () => cb.Push<MoveSnakeCommand>());
      this.onUpdate.AddListener(timer.UpdateWithDelta);
      model.gameState.OnEnter(GameState.Playing).AddListener(() => timer.Start());
      model.gameState.OnExit(GameState.Playing).AddListener(() => timer.Stop());

      // pause game when space is pressed
      this.onUpdate.AddListener(() => {
        if (Input.GetKeyDown(KeyCode.Space)) {
          if (model.gameState.Value != GameState.GameOver)
            cb.Push<TogglePauseCommand>();
        }
      });

      // handle input
      this.onUpdate.AddListener(() => {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var xInt = x > 0.5f ? 1 : x < -0.5f ? -1 : 0;
        var yInt = y > 0.5f ? 1 : y < -0.5f ? -1 : 0;
        if (xInt != 0 || yInt != 0) {
          cb.Push(new SetSnakeDirectionCommand(new Vector2Int(xInt, yInt)));
        }
      });
    }
  }
}