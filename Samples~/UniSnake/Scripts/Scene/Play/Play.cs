using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public class Play : Entry {
    void Awake() {
      var config = this.GetComponent<GameConfig>();
      var eb = new DebugEventBus();
      var cb = new DebugCommandBus();
      var model = new ModelManager(config, cb, eb);
      var tm = new TimerManager(this);

      this.Add(config);
      this.Add<IEventListener>(eb);
      this.Add<ICommandBus>(cb);
      this.Add<Model>(model);
      this.Add(tm);

      // move snake when not paused
      var timer = tm.AddRepeated(this, config.moveInterval, () => cb.Push<MoveSnakeCommand>());
      model.gameState.OnEnter(GameState.Playing, () => timer.Start());
      model.gameState.OnExit(GameState.Playing, () => timer.Stop());

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