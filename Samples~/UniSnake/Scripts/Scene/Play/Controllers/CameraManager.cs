using System.Linq;
using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public class CameraManager : CBC {
    void Start() {
      var config = this.Get<GameConfig>();
      var model = this.Get<Model>();

      // find the wall bound
      var left = model.wallPositions.Min(pos => pos.x);
      var right = model.wallPositions.Max(pos => pos.x);
      var bottom = model.wallPositions.Min(pos => pos.y);
      var top = model.wallPositions.Max(pos => pos.y);

      // move camera
      Camera.main.transform.position = new Vector3(
        (left + right) / 2f,
        (bottom + top) / 2f,
        Camera.main.transform.position.z
      );
    }
  }
}