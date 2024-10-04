using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play
{
  public record TogglePauseCommand;
  public record MoveSnakeCommand;
  public record SetSnakeDirectionCommand(Vector2Int direction);
}