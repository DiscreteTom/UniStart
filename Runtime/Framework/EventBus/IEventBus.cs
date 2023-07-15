using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventListener {
    UnityAction AddListener<T>(UnityAction action);
    UnityAction<T> AddListener<T>(UnityAction<T> action);
    UnityAction AddOnceListener<T>(UnityAction action);
    UnityAction<T> AddOnceListener<T>(UnityAction<T> action);
    UnityAction RemoveListener<T>(UnityAction action);
    UnityAction<T> RemoveListener<T>(UnityAction<T> action);
  }

  public static class IEventListenerExtension {
    // echoed AddListener
    public static UnityAction AddListener<T>(this IEventListener self, out UnityAction named, UnityAction action) {
      named = action;
      return self.AddListener<T>(action);
    }
    public static UnityAction<T> AddListener<T>(this IEventListener self, out UnityAction<T> named, UnityAction<T> action) {
      named = action;
      return self.AddListener(action);
    }
    // echoed RemoveListener
    public static UnityAction RemoveListener<T>(this IEventListener self, out UnityAction named, UnityAction action) {
      named = action;
      return self.RemoveListener<T>(action);
    }
    public static UnityAction<T> RemoveListener<T>(this IEventListener self, out UnityAction<T> named, UnityAction<T> action) {
      named = action;
      return self.RemoveListener(action);
    }
    // echoed AddOnceListener
    public static UnityAction AddOnceListener<T>(this IEventListener self, out UnityAction named, UnityAction action) {
      named = action;
      return self.AddOnceListener<T>(action);
    }
    public static UnityAction<T> AddOnceListener<T>(this IEventListener self, out UnityAction<T> named, UnityAction<T> action) {
      named = action;
      return self.AddOnceListener(action);
    }
  }

  public interface IEventInvoker {
    void Invoke<T>(T e);
  }

  public static class IEventInvokerExtension {
    public static void Invoke<T>(this IEventInvoker self) where T : new() => self.Invoke(new T());
  }

  public interface IEventBus : IEventListener, IEventInvoker { }
}