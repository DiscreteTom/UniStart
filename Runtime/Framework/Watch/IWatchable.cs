using UnityEngine.Events;

namespace DT.UniStart {
  public interface IWatchable {
    UnityAction AddListener(UnityAction f);
    UnityAction AddListener(out UnityAction named, UnityAction f);
    UnityAction RemoveListener(UnityAction f);
    UnityAction RemoveListener(out UnityAction named, UnityAction f);
  }

  public interface IWatchable<T0> {
    UnityAction<T0> AddListener(UnityAction<T0> f);
    UnityAction<T0> AddListener(out UnityAction<T0> named, UnityAction<T0> f);
    UnityAction<T0> RemoveListener(UnityAction<T0> f);
    UnityAction<T0> RemoveListener(out UnityAction<T0> named, UnityAction<T0> f);
  }

  public interface IWatchable<T0, T1> {
    UnityAction<T0, T1> AddListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> AddListener(out UnityAction<T0, T1> named, UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveListener(out UnityAction<T0, T1> named, UnityAction<T0, T1> f);
  }

  public interface IWatchable<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> AddListener(out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveListener(out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f);
  }

  public interface IWatchable<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> AddListener(out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveListener(out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f);
  }

  public interface IOnceWatchable {
    UnityAction AddOnceListener(UnityAction f);
    UnityAction AddOnceListener(out UnityAction named, UnityAction f);
    UnityAction RemoveListener(UnityAction f);
    UnityAction RemoveListener(out UnityAction named, UnityAction f);
  }

  public interface IOnceWatchable<T0> {
    UnityAction<T0> AddOnceListener(UnityAction<T0> f);
    UnityAction<T0> AddOnceListener(out UnityAction<T0> named, UnityAction<T0> f);
    UnityAction<T0> RemoveListener(UnityAction<T0> f);
    UnityAction<T0> RemoveListener(out UnityAction<T0> named, UnityAction<T0> f);
  }

  public interface IOnceWatchable<T0, T1> {
    UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> AddOnceListener(out UnityAction<T0, T1> named, UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveListener(out UnityAction<T0, T1> named, UnityAction<T0, T1> f);
  }

  public interface IOnceWatchable<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> AddOnceListener(out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveListener(out UnityAction<T0, T1, T2> named, UnityAction<T0, T1, T2> f);
  }

  public interface IOnceWatchable<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddOnceListener(out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveListener(out UnityAction<T0, T1, T2, T3> named, UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f);
  }
}