using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommandRepo {
    ICommandRepo Add<T>(UnityAction command);
    ICommandRepo Add<T>(out UnityAction named, UnityAction command);
    ICommandRepo Add<T>(UnityAction<T> command);
    ICommandRepo Add<T>(out UnityAction<T> named, UnityAction<T> command);
    void Invoke<T>(T arg);
    void Invoke<T>() where T : new();
  }
}