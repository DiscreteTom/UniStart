using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventListener {
    UnityAction AddListener<T>(UnityAction action);
    UnityAction AddListener<T>(UnityAction action, out UnityAction named);
    UnityAction<T> AddListener<T>(UnityAction<T> action);
    UnityAction<T> AddListener<T>(UnityAction<T> action, out UnityAction<T> named);
    UnityAction AddOnceListener<T>(UnityAction action);
    UnityAction AddOnceListener<T>(UnityAction action, out UnityAction named);
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action);
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action, out UnityAction<T> named);
    UnityAction RemoveListener<T>(UnityAction action);
    UnityAction RemoveListener<T>(UnityAction action, out UnityAction named);
    UnityAction<T> RemoveListener<T>(UnityAction<T> action);
    UnityAction<T> RemoveListener<T>(UnityAction<T> action, out UnityAction<T> named);
  }

  public interface IEventInvoker {
    void Invoke<T>() where T : new();
    void Invoke<T>(T e);
  }

  public interface IEventBus : IEventListener, IEventInvoker { }
}