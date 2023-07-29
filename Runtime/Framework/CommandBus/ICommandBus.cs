using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommand : IEvent { }

  public interface ICommandRepo {
    UnityAction Add<T>(UnityAction command) where T : ICommand;
    UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand;
  }

  public static class ICommandRepoExtension {
    public static UnityAction Add<T>(this ICommandRepo self, out UnityAction named, UnityAction command) where T : ICommand {
      named = command;
      return self.Add<T>(command);
    }
    public static UnityAction<T> Add<T>(this ICommandRepo self, out UnityAction<T> named, UnityAction<T> command) where T : ICommand {
      named = command;
      return self.Add(command);
    }
  }

  public interface ICommandBus {
    void Push<T>(T arg) where T : ICommand;
  }

  public static class ICommandBusExtension {
    public static void Push<T>(this ICommandBus self) where T : ICommand, new() => self.Push(new T());
  }

  public interface IWritableCommandBus : ICommandRepo, ICommandBus { }
}