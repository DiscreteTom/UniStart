using System.Collections.Generic;
using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public record CommandContext(Model model, GameConfig config, IEventInvoker eb);

  public record MoveFoodCommand : ICommand<CommandContext> {
    public void Invoke(CommandContext ctx) {
      var (model, config, _) = ctx;

      // collect available positions
      var availablePositions = new List<Vector2Int>();
      for (var x = 0; x < config.mapDimensions.x; x++) {
        for (var y = 0; y < config.mapDimensions.y; y++) {
          var pos = new Vector2Int(x, y);
          if (!model.CheckCollision(pos)) {
            availablePositions.Add(pos);
          }
        }
      }

      // move food to a random available position
      ctx.model.foodPosition.Value = availablePositions[Random.Range(0, availablePositions.Count)];
    }
  }

  public record TogglePauseCommand : ICommand<CommandContext> {
    public void Invoke(CommandContext ctx) {
      var (model, _, _) = ctx;

      if (model.gameState.Value == GameState.Pause) {
        model.gameState.Value = GameState.Playing;
      } else if (model.gameState.Value == GameState.Playing) {
        model.gameState.Value = GameState.Pause;
      }
    }
  }
  public record MoveSnakeCommand : ICommand<CommandContext> {
    public void Invoke(CommandContext ctx) {
      var (model, _, _) = ctx;

      if (model.gameState.Value != GameState.Playing) return;

      var target = model.snakePositions[0] + model.snakeDirection.Value;

      // check game over
      if (model.CheckCollision(target)) {
        model.gameState.Value = GameState.GameOver;
        return;
      }

      // check food and move snake
      if (target == model.foodPosition.Value) {
        model.snakePositions.Insert(0, target);
        new MoveFoodCommand().Invoke(ctx);
      } else {
        model.snakePositions.Commit((pos) => {
          pos.Insert(0, target);
          pos.RemoveAt(pos.Count - 1);
        });
      }
    }
  }
  public record SetSnakeDirectionCommand(Vector2Int direction) : ICommand<CommandContext> {
    public void Invoke(CommandContext ctx) {
      var (model, _, _) = ctx;

      if (model.gameState.Value != GameState.Playing) return;

      // ignore both 0 or both 1
      if (direction.x == direction.y) return;
      // ignore reverse direction (snake can't turn 180 degrees
      if (model.snakePositions.Count > 1 && direction + model.snakePositions[0] == model.snakePositions[1]) return;

      model.snakeDirection.Value = direction;
    }
  }
}