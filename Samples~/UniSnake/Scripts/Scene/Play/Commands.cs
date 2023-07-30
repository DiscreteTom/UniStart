using DT.UniStart;
using UnityEngine;

namespace UniSnake.Scene.Play {
  public record MoveSnakeCommand : ICommand;
  public record SetSnakeDirectionCommand(Vector2Int direction) : ICommand;
}