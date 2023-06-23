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

  public interface IOnceWatchable {
    UnityAction AddOnceListener(UnityAction f);
    UnityAction RemoveOnceListener(UnityAction f);
  }

  public interface IOnceWatchable<T0> {
    UnityAction<T0> AddOnceListener(UnityAction<T0> f);
    UnityAction<T0> RemoveOnceListener(UnityAction<T0> f);
  }

  public interface IOnceWatchable<T0, T1> {
    UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> f);
    UnityAction<T0, T1> RemoveOnceListener(UnityAction<T0, T1> f);
  }

  public interface IOnceWatchable<T0, T1, T2> {
    UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> f);
    UnityAction<T0, T1, T2> RemoveOnceListener(UnityAction<T0, T1, T2> f);
  }

  public interface IOnceWatchable<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> f);
    UnityAction<T0, T1, T2, T3> RemoveOnceListener(UnityAction<T0, T1, T2, T3> f);
  }
}