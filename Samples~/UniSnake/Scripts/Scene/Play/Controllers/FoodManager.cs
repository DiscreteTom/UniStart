using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public class FoodManager : CBC {
    void Start() {
      var config = this.Get<GameConfig>();
      var model = this.Get<Model>();

      var food = Instantiate(config.foodPrefab, this.transform);
      model.foodPosition.AddListener((pos) => {
        food.transform.position = new Vector3(pos.x, pos.y, 0);
      }).Invoke(model.foodPosition.Value);
    }
  }
}