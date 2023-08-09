using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEvent { }

  public interface IEventListener {
    UnityAction<T> AddListener<T>(UnityAction<T> action) where T : IEvent;
    UnityAction<T> RemoveListener<T>(UnityAction<T> action) where T : IEvent;
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action) where T : IEvent;
    UnityAction<T> RemoveOnceListener<T>(UnityAction<T> action) where T : IEvent;
  }

  public interface IEventInvoker {
    void Invoke<T>(T e) where T : IEvent;
  }

  public static class IEventInvokerExtension {
    public static void Invoke<T>(this IEventInvoker self) where T : IEvent, new() => self.Invoke(new T());
  }

  public interface IEventBus : IEventListener, IEventInvoker { }
}