using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommandRepo {
    UnityAction Add<T>(UnityAction command);
    UnityAction<T> Add<T>(UnityAction<T> command);
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