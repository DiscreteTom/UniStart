using UnityEngine.Events;

namespace DT.UniStart {
  #region IRemoveListener
  public interface IRemoveListener {
    UnityAction RemoveListener(UnityAction f);
  }
  public interface IRemoveListener<T0> {
    UnityAction<T0> RemoveListener(UnityAction<T0> f);
  }
  public interface IRemoveListener<T0, T1> {
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f);
  }
  public interface IRemoveListener<T0, T1, T2> {
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f);
  }
  public interface IRemoveListener<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f);
  }
  #endregion

  #region IWatchable
  public interface IWatchable : IRemoveListener {
    UnityAction AddListener(UnityAction f);
  }
  public interface IWatchable<T0> : IRemoveListener<T0> {
    UnityAction<T0> AddListener(UnityAction<T0> f);
  }
  public interface IWatchable<T0, T1> : IRemoveListener<T0, T1> {
    UnityAction<T0, T1> AddListener(UnityAction<T0, T1> f);
  }
  public interface IWatchable<T0, T1, T2> : IRemoveListener<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> f);
  }
  public interface IWatchable<T0, T1, T2, T3> : IRemoveListener<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> f);
  }
  #endregion

  #region IOnceWatchable
  public interface IOnceWatchable : IRemoveListener {
    UnityAction AddOnceListener(UnityAction f);
  }
  public interface IOnceWatchable<T0> : IRemoveListener<T0> {
    UnityAction<T0> AddOnceListener(UnityAction<T0> f);
  }
  public interface IOnceWatchable<T0, T1> : IRemoveListener<T0, T1> {
    UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> f);
  }
  public interface IOnceWatchable<T0, T1, T2> : IRemoveListener<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> f);
  }
  public interface IOnceWatchable<T0, T1, T2, T3> : IRemoveListener<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> f);
  }
  #endregion

  public static class IWatchableExtension {
    #region IRemoveListener
    public static UnityAction RemoveListener(this IRemoveListener self, out UnityAction named, UnityAction f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0> RemoveListener<T0>(this IRemoveListener<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0, T1> RemoveListener<T0, T1>(this IRemoveListener<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(this IRemoveListener<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      return self.RemoveListener(f);
    }
    public static UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(this IRemoveListener<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      return self.RemoveListener(f);
    }
    #endregion

    #region IWatchable
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

    #region IOnceWatchable
    public static UnityAction AddOnceListener(this IOnceWatchable self, out UnityAction named, UnityAction f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0> AddOnceListener<T0>(this IOnceWatchable<T0> self, out UnityAction<T0> named, UnityAction<T0> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1> AddOnceListener<T0, T1>(this IOnceWatchable<T0, T1> self, out UnityAction<T0, T1> named, UnityAction<T0, T1> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(this IOnceWatchable<T0, T1, T2> self, out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    public static UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(this IOnceWatchable<T0, T1, T2, T3> self, out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f) {
      named = f;
      return self.AddOnceListener(f);
    }
    #endregion
  }
}