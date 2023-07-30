using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEvent { }

  public interface IEventListener {
    UnityAction AddListener<T>(UnityAction action) where T : IEvent;
    UnityAction<T> AddListener<T>(UnityAction<T> action) where T : IEvent;
    UnityAction RemoveListener<T>(UnityAction action) where T : IEvent;
    UnityAction<T> RemoveListener<T>(UnityAction<T> action) where T : IEvent;
    UnityAction AddOnceListener<T>(UnityAction action) where T : IEvent;
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action) where T : IEvent;
    UnityAction RemoveOnceListener<T>(UnityAction action) where T : IEvent;
    UnityAction<T> RemoveOnceListener<T>(UnityAction<T> action) where T : IEvent;
  }

  public static class IEventListenerExtension {
    // echoed AddListener
    public static UnityAction AddListener<T>(this IEventListener self, out UnityAction named, UnityAction action) where T : IEvent {
      named = action;
      return self.AddListener<T>(action);
    }
    public static UnityAction<T> AddListener<T>(this IEventListener self, out UnityAction<T> named, UnityAction<T> action) where T : IEvent {
      named = action;
      return self.AddListener(action);
    }
    // echoed RemoveListener
    public static UnityAction RemoveListener<T>(this IEventListener self, out UnityAction named, UnityAction action) where T : IEvent {
      named = action;
      return self.RemoveListener<T>(action);
    }
    public static UnityAction<T> RemoveListener<T>(this IEventListener self, out UnityAction<T> named, UnityAction<T> action) where T : IEvent {
      named = action;
      return self.RemoveListener(action);
    }
    // echoed AddOnceListener
    public static UnityAction AddOnceListener<T>(this IEventListener self, out UnityAction named, UnityAction action) where T : IEvent {
      named = action;
      return self.AddOnceListener<T>(action);
    }
    public static UnityAction<T> AddOnceListener<T>(this IEventListener self, out UnityAction<T> named, UnityAction<T> action) where T : IEvent {
      named = action;
      return self.AddOnceListener(action);
    }
    // echoed RemoveOnceListener
    public static UnityAction RemoveOnceListener<T>(this IEventListener self, out UnityAction named, UnityAction action) where T : IEvent {
      named = action;
      return self.RemoveOnceListener<T>(action);
    }
    public static UnityAction<T> RemoveOnceListener<T>(this IEventListener self, out UnityAction<T> named, UnityAction<T> action) where T : IEvent {
      named = action;
      return self.RemoveOnceListener(action);
    }
  }

  public interface IEventInvoker {
    void Invoke<T>(T e) where T : IEvent;
  }

  public static class IEventInvokerExtension {
    public static void Invoke<T>(this IEventInvoker self) where T : IEvent, new() => self.Invoke(new T());
  }

  public interface IEventBus : IEventListener, IEventInvoker { }
}