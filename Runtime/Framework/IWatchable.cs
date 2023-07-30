using UnityEngine.Events;

namespace DT.UniStart {
  public interface IWatchable {
    UnityAction AddListener(UnityAction f);
    UnityAction RemoveListener(UnityAction f);
  }
  public interface IWatchable<T0> {
    UnityAction<T0> AddListener(UnityAction<T0> f);
    UnityAction<T0> RemoveListener(UnityAction<T0> f);
  }
  public interface IWatchable<T0, T1> {
    UnityAction<T0, T1> AddListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f);
  }
  public interface IWatchable<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f);
  }
  public interface IWatchable<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f);
  }

  public static class IWatchableExtension {
    #region Echoed AddListener
    public static UnityAction AddListener(this IWatchable self, out UnityAction named, UnityAction f) {
      named = f;
      return self.AddListener(f);
    }
    public static UnityAction<T0> AddListener<T0>(this IWatchable<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      return self.AddListener(f);
    }
    public static UnityAction<T0, T1> AddListener<T0, T1>(this IWatchable<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      return self.AddListener(f);
    }
    public static UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(this IWatchable<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      return self.AddListener(f);
    }
    public static UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(this IWatchable<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      return self.AddListener(f);
    }
    #endregion

    #region Echoed RemoveListener
    public static UnityAction RemoveListener(this IWatchable self, out UnityAction named, UnityAction f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0> RemoveListener<T0>(this IWatchable<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0, T1> RemoveListener<T0, T1>(this IWatchable<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(this IWatchable<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(this IWatchable<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      return self.RemoveListener(f);
    }
    #endregion

    #region AddOnceListener
    public static UnityAction AddOnceListener(this IWatchable self, UnityAction f) {
      self.AddListener(f);
      self.AddListener(() => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0> AddOnceListener<T0>(this IWatchable<T0> self, UnityAction<T0> f) {
      self.AddListener(f);
      self.AddListener((_) => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0, T1> AddOnceListener<T0, T1>(this IWatchable<T0, T1> self, UnityAction<T0, T1> f) {
      self.AddListener(f);
      self.AddListener((_, __) => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(this IWatchable<T0, T1, T2> self, UnityAction<T0, T1, T2> f) {
      self.AddListener(f);
      self.AddListener((_, __, ___) => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(this IWatchable<T0, T1, T2, T3> self, UnityAction<T0, T1, T2, T3> f) {
      self.AddListener(f);
      self.AddListener((_, __, ___, ____) => self.RemoveListener(f));
      return f;
    }
    #endregion

    #region Echoed AddOnceListener
    public static UnityAction AddOnceListener(this IWatchable self, out UnityAction named, UnityAction f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0> AddOnceListener<T0>(this IWatchable<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1> AddOnceListener<T0, T1>(this IWatchable<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(this IWatchable<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(this IWatchable<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    #endregion
  }

  public static class IUnityEventExtension {
    #region Echoed AddListener
    public static UnityAction AddListener(this UnityEvent self, out UnityAction named, UnityAction f) {
      named = f;
      self.AddListener(f);
      return f;
    }
    public static UnityAction<T0> AddListener<T0>(this UnityEvent<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      self.AddListener(f);
      return f;
    }
    public static UnityAction<T0, T1> AddListener<T0, T1>(this UnityEvent<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      self.AddListener(f);
      return f;
    }
    public static UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      self.AddListener(f);
      return f;
    }
    public static UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      self.AddListener(f);
      return f;
    }
    #endregion

    #region Echoed RemoveListener
    public static UnityAction RemoveListener(this UnityEvent self, out UnityAction named, UnityAction f) {
      named = f;
      self.RemoveListener(f);
      return f;
    }
    public static UnityAction<T0> RemoveListener<T0>(this UnityEvent<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      self.RemoveListener(f);
      return f;
    }
    public static UnityAction<T0, T1> RemoveListener<T0, T1>(this UnityEvent<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      self.RemoveListener(f);
      return f;
    }
    public static UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      self.RemoveListener(f);
      return f;
    }
    public static UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      self.RemoveListener(f);
      return f;
    }
    #endregion

    #region AddOnceListener
    public static UnityAction AddOnceListener(this UnityEvent self, UnityAction f) {
      self.AddListener(f);
      self.AddListener(() => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0> AddOnceListener<T0>(this UnityEvent<T0> self, UnityAction<T0> f) {
      self.AddListener(f);
      self.AddListener((_) => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0, T1> AddOnceListener<T0, T1>(this UnityEvent<T0, T1> self, UnityAction<T0, T1> f) {
      self.AddListener(f);
      self.AddListener((_, __) => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> self, UnityAction<T0, T1, T2> f) {
      self.AddListener(f);
      self.AddListener((_, __, ___) => self.RemoveListener(f));
      return f;
    }
    public static UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> self, UnityAction<T0, T1, T2, T3> f) {
      self.AddListener(f);
      self.AddListener((_, __, ___, ____) => self.RemoveListener(f));
      return f;
    }
    #endregion

    #region Echoed AddOnceListener
    public static UnityAction AddOnceListener(this UnityEvent self, out UnityAction named, UnityAction f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0> AddOnceListener<T0>(this UnityEvent<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1> AddOnceListener<T0, T1>(this UnityEvent<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(this UnityEvent<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(this UnityEvent<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    #endregion
  }
}