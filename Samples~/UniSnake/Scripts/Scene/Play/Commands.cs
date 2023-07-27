using UnityEngine;

namespace UniSnake.Scene.Play {
  public record MoveSnakeCommand;
  public record SetSnakeDirectionCommand(Vector2Int direction);
}