using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventListener {
    UnityAction AddListener<T>(UnityAction action);
    UnityAction<T> AddListener<T>(UnityAction<T> action);
    UnityAction AddOnceListener<T>(UnityAction action);
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action);
    UnityAction RemoveListener<T>(UnityAction action);
    UnityAction<T> RemoveListener<T>(UnityAction<T> action);
    UnityAction RemoveOnceListener<T>(UnityAction action);
    UnityAction<T> RemoveOnceListener<T>(UnityAction<T> action);
  }

  public interface IEventInvoker {
    void Invoke<T>(T e);
  }

  public interface IEventBus : IEventListener, IEventInvoker { }
}