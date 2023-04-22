using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventBus {
    UnityAction AddListener(object key, UnityAction action);
    UnityAction<T0> AddListener<T0>(object key, UnityAction<T0> action);
    UnityAction<T0, T1> AddListener<T0, T1>(object key, UnityAction<T0, T1> action);
    UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action);

    UnityAction RemoveListener(object key, UnityAction action);
    UnityAction<T0> RemoveListener<T0>(object key, UnityAction<T0> action);
    UnityAction<T0, T1> RemoveListener<T0, T1>(object key, UnityAction<T0, T1> action);
    UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action);

    void Invoke(object key);
    void Invoke<T0>(object key, T0 arg0);
    void Invoke<T0, T1>(object key, T0 arg0, T1 arg1);
    void Invoke<T0, T1, T2>(object key, T0 arg0, T1 arg1, T2 arg2);
    void Invoke<T0, T1, T2, T3>(object key, T0 arg0, T1 arg1, T2 arg2, T3 arg3);
  }
}