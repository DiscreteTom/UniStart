using UnityEngine.Events;

namespace DT.UniStart {
  public interface IEventListener<T> {
    UnityAction AddListener(T key, UnityAction action);
    UnityAction AddOnceListener(T key, UnityAction action);
    UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action);
    UnityAction<T0> AddOnceListener<T0>(T key, UnityAction<T0> action);
    UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action);
    UnityAction<T0, T1> AddOnceListener<T0, T1>(T key, UnityAction<T0, T1> action);
    UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action);
    UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action);

    UnityAction RemoveListener(T key, UnityAction action);
    UnityAction RemoveOnceListener(T key, UnityAction action);
    UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action);
    UnityAction<T0> RemoveOnceListener<T0>(T key, UnityAction<T0> action);
    UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action);
    UnityAction<T0, T1> RemoveOnceListener<T0, T1>(T key, UnityAction<T0, T1> action);
    UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2> RemoveOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action);
    UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action);
    UnityAction<T0, T1, T2, T3> RemoveOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action);
  }
  public interface IEventListener : IEventListener<object> { }

  public interface IEventInvoker<T> {
    void Invoke(T key);
    void Invoke<T0>(T key, T0 arg0);
    void Invoke<T0, T1>(T key, T0 arg0, T1 arg1);
    void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2);
    void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3);
  }
  public interface IEventInvoker : IEventInvoker<object> { }

  public interface IEventBus<T> : IEventListener<T>, IEventInvoker<T> { }
  public interface IEventBus : IEventBus<object>, IEventListener, IEventInvoker { }
}