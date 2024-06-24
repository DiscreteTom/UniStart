using DT.UniStart;

namespace UniSnake.Scene.Play {
  public class GameOverManager : CBC {
    void Start() {
      var model = this.Get<Model>();

      model.gameState.OnEnter(GameState.GameOver).AddListener(UniStart.ReloadScene);
    }
  }
}