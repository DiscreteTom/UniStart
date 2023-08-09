using UnityEngine.Events;

namespace DT.UniStart {
  public interface IWatchable {
    void AddListener(UnityAction f);
    void RemoveListener(UnityAction f);
    void AddOnceListener(UnityAction f);
    void RemoveOnceListener(UnityAction f);
  }
  public interface IWatchable<T0> {
    void AddListener(UnityAction<T0> f);
    void RemoveListener(UnityAction<T0> f);
    void AddOnceListener(UnityAction<T0> f);
    void RemoveOnceListener(UnityAction<T0> f);
  }
  public interface IWatchable<T0, T1> {
    void AddListener(UnityAction<T0, T1> f);
    void RemoveListener(UnityAction<T0, T1> f);
    void AddOnceListener(UnityAction<T0, T1> f);
    void RemoveOnceListener(UnityAction<T0, T1> f);
  }
  public interface IWatchable<T0, T1, T2> {
    void AddListener(UnityAction<T0, T1, T2> f);
    void RemoveListener(UnityAction<T0, T1, T2> f);
    void AddOnceListener(UnityAction<T0, T1, T2> f);
    void RemoveOnceListener(UnityAction<T0, T1, T2> f);
  }
  public interface IWatchable<T0, T1, T2, T3> {
    void AddListener(UnityAction<T0, T1, T2, T3> f);
    void RemoveListener(UnityAction<T0, T1, T2, T3> f);
    void AddOnceListener(UnityAction<T0, T1, T2, T3> f);
    void RemoveOnceListener(UnityAction<T0, T1, T2, T3> f);
  }
}