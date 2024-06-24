using System.Collections.Generic;
using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public enum GameState {
    Playing,
    Pause,
    GameOver,
  }

  public class Model : StateManager {
    public readonly IReadOnlyList<Vector2Int> wallPositions;
    public readonly IListState<Vector2Int> snakePositions;
    public readonly IValueState<Vector2Int> snakeDirection;
    public readonly IValueState<Vector2Int> foodPosition;
    public readonly IEnumState<GameState> gameState;

    public Model(GameConfig config, ICommandRepo cb, IEventInvoker eb) {
      // init wall positions by config.wall dimensions
      var wallDimensions = new Vector2Int(config.mapDimensions.x + 2, config.mapDimensions.y + 2);
      var wallPositions = this.Init(ref this.wallPositions, (wallDimensions.x + wallDimensions.y) * 2 - 4);
      var wallIndex = 0;
      for (var x = 0; x < wallDimensions.x; x++) {
        for (var y = 0; y < wallDimensions.y; y++) {
          if (x == 0 || y == 0 || x == wallDimensions.x - 1 || y == wallDimensions.y - 1) {
            wallPositions[wallIndex] = new Vector2Int(x, y);
            wallIndex++;
          }
        }
      }

      // init snake positions
      var snakePositions = this.Init(ref this.snakePositions);
      snakePositions.Add(new Vector2Int(config.mapDimensions.x / 2, config.mapDimensions.y / 2));

      // init others
      var snakeDirection = this.Init(ref this.snakeDirection, new Vector2Int(0, 1));
      var foodPosition = this.Init(ref this.foodPosition, new Vector2Int(0, 0)); // give a random position later
      var gameState = this.Init(ref this.gameState, GameState.Playing);

      // util functions
      var checkCollision = UniStart.Fn((Vector2Int target) => {
        // check walls
        foreach (var pos in wallPositions) {
          if (pos == target) return true;
        }
        // check snake
        foreach (var pos in snakePositions) {
          if (pos == target) return true;
        }
        return false;
      });
      var moveFood = UniStart.Fn(() => {
        // collect available positions
        var availablePositions = new List<Vector2Int>();
        for (var x = 0; x < config.mapDimensions.x; x++) {
          for (var y = 0; y < config.mapDimensions.y; y++) {
            var pos = new Vector2Int(x, y);
            if (!checkCollision(pos)) {
              availablePositions.Add(pos);
            }
          }
        }

        // move food to a random available position
        foodPosition.Value = availablePositions[Random.Range(0, availablePositions.Count)];
      });

      // init food position
      moveFood();

      cb.Add<MoveSnakeCommand>(() => {
        if (gameState.Value != GameState.Playing) return;

        var target = snakePositions[0] + snakeDirection.Value;

        // check game over
        if (checkCollision(target)) {
          gameState.Value = GameState.GameOver;
          return;
        }

        // check food and move snake
        if (target == foodPosition.Value) {
          snakePositions.Insert(0, target);
          moveFood();
        } else {
          snakePositions.Commit((pos) => {
            pos.Insert(0, target);
            pos.RemoveAt(pos.Count - 1);
          });
        }
      });

      cb.Add<SetSnakeDirectionCommand>((cmd) => {
        if (gameState.Value != GameState.Playing) return;

        // ignore both 0 or both 1
        if (cmd.direction.x == cmd.direction.y) return;
        // ignore reverse direction (snake can't turn 180 degrees
        if (snakePositions.Count > 1 && cmd.direction + snakePositions[0] == snakePositions[1]) return;

        snakeDirection.Value = cmd.direction;
      });

      cb.Add<TogglePauseCommand>((cmd) => {
        if (gameState.Value == GameState.Pause) {
          gameState.Value = GameState.Playing;
        } else if (gameState.Value == GameState.Playing) {
          gameState.Value = GameState.Pause;
        }
      });
    }
  }
}