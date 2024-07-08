using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommand { }

  public interface ICommandRepo {
    UnityAction Add<T>(UnityAction command) where T : ICommand;
    UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand;
  }

  public interface ICommandBus {
    void Push<T>(T arg) where T : ICommand;
  }

  public static class ICommandBusExtension {
    public static void Push<T>(this ICommandBus self) where T : ICommand, new() => self.Push(new T());
  }

  public interface ICommandCenter : ICommandRepo, ICommandBus { }
}