using System.Collections.Generic;
using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public enum GameState {
    Playing,
    Pause,
    GameOver,
  }

  public class Model : CBC {
    public IReadOnlyList<Vector2Int> wallPositions;
    public WatchList<Vector2Int> snakePositions;
    public Watch<Vector2Int> snakeDirection;
    public Watch<Vector2Int> foodPosition;
    public StateMachine<GameState> gameState;

    public Model Init(GameConfig config) {
      // init wall positions by config.wall dimensions
      var wallDimensions = new Vector2Int(config.mapDimensions.x + 2, config.mapDimensions.y + 2);
      var wallPositions = new List<Vector2Int>((wallDimensions.x + wallDimensions.y) * 2 - 4);
      for (var x = 0; x < wallDimensions.x; x++) {
        for (var y = 0; y < wallDimensions.y; y++) {
          if (x == 0 || y == 0 || x == wallDimensions.x - 1 || y == wallDimensions.y - 1) {
            wallPositions.Add(new Vector2Int(x, y));
          }
        }
      }
      this.wallPositions = wallPositions;

      // init snake positions
      this.snakePositions = new();
      snakePositions.Add(new Vector2Int(config.mapDimensions.x / 2, config.mapDimensions.y / 2));

      // init others
      this.snakeDirection = new(new Vector2Int(0, 1));
      this.foodPosition = new(new Vector2Int(0, 0)); // give a random position later
      this.gameState = new(GameState.Playing);

      return this;
    }

    public bool CheckCollision(Vector2Int target) {
      // check walls
      foreach (var pos in this.wallPositions) {
        if (pos == target) return true;
      }
      // check snake
      foreach (var pos in this.snakePositions) {
        if (pos == target) return true;
      }
      return false;
    }
  }
}