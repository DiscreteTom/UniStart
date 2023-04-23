using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventBus<T> {
    UnityAction AddListener(T key, UnityAction action);
    UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action);
    UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action);
    UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action);

    UnityAction RemoveListener(T key, UnityAction action);
    UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action);
    UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action);
    UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action);

    void Invoke(T key);
    void Invoke<T0>(T key, T0 arg0);
    void Invoke<T0, T1>(T key, T0 arg0, T1 arg1);
    void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2);
    void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3);
  }

  public interface IEventBus : IEventBus<object> { }
}