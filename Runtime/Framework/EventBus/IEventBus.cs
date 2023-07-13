using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventListener {
    UnityAction AddListener<T>(UnityAction action);
    UnityAction AddListener<T>(out UnityAction named, UnityAction action);
    UnityAction<T> AddListener<T>(UnityAction<T> action);
    UnityAction<T> AddListener<T>(out UnityAction<T> named, UnityAction<T> action);
    UnityAction AddOnceListener<T>(UnityAction action);
    UnityAction AddOnceListener<T>(out UnityAction named, UnityAction action);
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action);
    UnityAction<T> AddOnceListener<T>(out UnityAction<T> named, UnityAction<T> action);
    UnityAction RemoveListener<T>(UnityAction action);
    UnityAction RemoveListener<T>(out UnityAction named, UnityAction action);
    UnityAction<T> RemoveListener<T>(UnityAction<T> action);
    UnityAction<T> RemoveListener<T>(out UnityAction<T> named, UnityAction<T> action);
  }

  public interface IEventInvoker {
    void Invoke<T>() where T : new();
    void Invoke<T>(T e);
  }

  public interface IEventBus : IEventListener, IEventInvoker { }
}