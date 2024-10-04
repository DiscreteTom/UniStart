using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommandRepo {
    /// <summary>
    /// Register a command with a handler.
    /// </summary>
    UnityAction Add<T>(UnityAction handler);
    /// <summary>
    /// Register a command with a handler.
    /// </summary>
    UnityAction<T> Add<T>(UnityAction<T> handler);
  }

  public interface ICommandBus {
    /// <summary>
    /// Push a command to the CommandBus.
    /// If the command is not registered, an exception will be thrown.
    /// </summary>
    void Push<T>(T arg);
  }

  public static class ICommandBusExtension {
    /// <summary>
    /// Push a command to the CommandBus.
    /// If the command is not registered, an exception will be thrown.
    /// </summary>
    public static void Push<T>(this ICommandBus self) where T : new() => self.Push(new T());
  }

  public interface ICommandCenter : ICommandRepo, ICommandBus { }
}