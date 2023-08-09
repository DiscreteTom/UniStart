using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public class GameOverManager : CBC {
    void Start() {
      var config = this.Get<GameConfig>();
      var model = this.Get<Model>();

      model.gameState.OnEnter(GameState.GameOver, UniStart.ReloadScene);
    }
  }
}