using UnityEngine.Events;

namespace DT.UniStart {
  public interface IWatchable {
    UnityAction AddListener(UnityAction f);
    UnityAction AddListener(UnityAction f, out UnityAction named);
    UnityAction RemoveListener(UnityAction f);
    UnityAction RemoveListener(UnityAction f, out UnityAction named);
  }

  public interface IWatchable<T0> {
    UnityAction<T0> AddListener(UnityAction<T0> f);
    UnityAction<T0> AddListener(UnityAction<T0> f, out UnityAction<T0> named);
    UnityAction<T0> RemoveListener(UnityAction<T0> f);
    UnityAction<T0> RemoveListener(UnityAction<T0> f, out UnityAction<T0> named);
  }

  public interface IWatchable<T0, T1> {
    UnityAction<T0, T1> AddListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> AddListener(UnityAction<T0, T1> f, out UnityAction<T0, T1> named);
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f, out UnityAction<T0, T1> named);
  }

  public interface IWatchable<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> f, out UnityAction<T0, T1, T2> named);
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f, out UnityAction<T0, T1, T2> named);
  }

  public interface IWatchable<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> f, out UnityAction<T0, T1, T2, T3> named);
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f, out UnityAction<T0, T1, T2, T3> named);
  }

  public interface IOnceWatchable {
    UnityAction AddOnceListener(UnityAction f);
    UnityAction AddOnceListener(UnityAction f, out UnityAction named);
    UnityAction RemoveListener(UnityAction f);
    UnityAction RemoveListener(UnityAction f, out UnityAction named);
  }

  public interface IOnceWatchable<T0> {
    UnityAction<T0> AddOnceListener(UnityAction<T0> f);
    UnityAction<T0> AddOnceListener(UnityAction<T0> f, out UnityAction<T0> named);
    UnityAction<T0> RemoveListener(UnityAction<T0> f);
    UnityAction<T0> RemoveListener(UnityAction<T0> f, out UnityAction<T0> named);
  }

  public interface IOnceWatchable<T0, T1> {
    UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> f, out UnityAction<T0, T1> named);
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> f, out UnityAction<T0, T1> named);
  }

  public interface IOnceWatchable<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> f, out UnityAction<T0, T1, T2> named);
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> f, out UnityAction<T0, T1, T2> named);
  }

  public interface IOnceWatchable<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> f, out UnityAction<T0, T1, T2, T3> named);
    UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f, out UnityAction<T0, T1, T2, T3> named);
    UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> f);
  }
}