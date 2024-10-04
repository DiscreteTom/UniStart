using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventListener {
    UnityAction AddListener<T>(UnityAction action);
    UnityAction RemoveListener<T>(UnityAction action);
    UnityAction AddOnceListener<T>(UnityAction action);
    UnityAction<T> AddListener<T>(UnityAction<T> action);
    UnityAction<T> RemoveListener<T>(UnityAction<T> action);
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action);
  }

  public interface IEventInvoker {
    void Invoke<T>(T e);
  }

  public static class IEventInvokerExtension {
    public static void Invoke<T>(this IEventInvoker self) where T : new() => self.Invoke(new T());
  }

  public interface IEventBus : IEventListener, IEventInvoker { }
}