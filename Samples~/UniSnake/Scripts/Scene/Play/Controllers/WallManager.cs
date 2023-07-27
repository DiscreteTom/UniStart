using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public class WallManager : CBC {
    void Start() {
      var config = this.Get<GameConfig>();
      var model = this.Get<Model>();

      // create walls
      foreach (var pos in model.wallPositions) {
        var wall = Instantiate(config.wallPrefab);
        wall.transform.parent = this.transform;
        wall.transform.position = new Vector3(pos.x, pos.y, 0);
      }
    }
  }
}