using System.Collections.Generic;
using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public class SnakeManager : CBC {
    void Start() {
      var config = this.Get<GameConfig>();
      var model = this.Get<Model>();

      var snakeObjs = new List<GameObject>();
      // init snake objs
      for (var i = 0; i < model.snakePositions.Count; ++i) {
        var prefab = i == 0 ? config.snakeHeadPrefab : config.snakeBodyPrefab;
        snakeObjs.Add(Instantiate(prefab, new Vector3(model.snakePositions[i].x, model.snakePositions[i].y, 0), Quaternion.identity, this.transform));
      }
      this.Watch(model.snakePositions, (pos) => {
        for (var i = 0; i < pos.Count; ++i) {
          if (i < snakeObjs.Count) {
            // move existing objects
            snakeObjs[i].transform.position = new Vector3(model.snakePositions[i].x, model.snakePositions[i].y, 0);
          } else {
            // create new objects
            snakeObjs.Add(Instantiate(config.snakeBodyPrefab, new Vector3(pos[i].x, pos[i].y, 0), Quaternion.identity, this.transform));
          }
        }
      });
    }
  }
}