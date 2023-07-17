using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommandRepo {
    UnityAction Add<T>(UnityAction command);
    UnityAction<T> Add<T>(UnityAction<T> command);
  }

  public static class ICommandRepoExtension {
    public static UnityAction Add<T>(this ICommandRepo self, out UnityAction named, UnityAction command) {
      named = command;
      return self.Add<T>(command);
    }
    public static UnityAction<T> Add<T>(this ICommandRepo self, out UnityAction<T> named, UnityAction<T> command) {
      named = command;
      return self.Add(command);
    }
  }

  public interface ICommandBus {
    void Push<T>(T arg);
  }

  public static class ICommandBusExtension {
    public static void Push<T>(this ICommandBus self) where T : new() => self.Push(new T());
  }

  public interface IWritableCommandBus : ICommandRepo, ICommandBus { }
}