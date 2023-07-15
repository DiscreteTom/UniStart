using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommandRepo {
    ICommandRepo Add<T>(UnityAction command);
    ICommandRepo Add<T>(UnityAction<T> command);
    void Invoke<T>(T arg);
  }

  public static class ICommandRepoExtension {
    public static ICommandRepo Add<T>(this ICommandRepo self, out UnityAction named, UnityAction command) {
      named = command;
      return self.Add<T>(command);
    }
    public static ICommandRepo Add<T>(this ICommandRepo self, out UnityAction<T> named, UnityAction<T> command) {
      named = command;
      return self.Add(command);
    }
    public static void Invoke<T>(this ICommandRepo self) where T : new() => self.Invoke(new T());
  }
}