using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommand : IEvent { }

  public interface ICommandRepo {
    UnityAction Add<T>(UnityAction command) where T : ICommand;
    UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand;
  }

  public interface ICommandExecutor {
    void Push<T>(T arg) where T : ICommand;
  }

  public static class ICommandExecutorExtension {
    public static void Push<T>(this ICommandExecutor self) where T : ICommand, new() => self.Push(new T());
  }

  public interface ICommandBus : ICommandRepo, ICommandExecutor { }
}