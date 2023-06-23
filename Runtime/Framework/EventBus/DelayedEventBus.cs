using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// A wrapper around an IEventBus which delays all events until InvokeDelayed is called.
  /// </summary>
  public class DelayedEventBus<T> : IEventBus<T> {
    List<UnityAction> delayedActions;
    IEventBus<T> bus;

    public DelayedEventBus(IEventBus<T> eventBus) {
      this.bus = eventBus;
      this.delayedActions = new List<UnityAction>();
    }

    /// <summary>
    /// Invoke all delayed actions.
    /// </summary>
    public void InvokeDelayed() {
      foreach (UnityAction action in this.delayedActions) {
        action.Invoke();
      }
      this.delayedActions.Clear();
    }

    public UnityAction AddListener(T key, UnityAction action) => this.bus.AddListener(key, action);
    public UnityAction AddOnceListener(T key, UnityAction action) => this.bus.AddOnceListener(key, action);
    public UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action) => this.bus.AddListener(key, action);
    public UnityAction<T0> AddOnceListener<T0>(T key, UnityAction<T0> action) => this.bus.AddOnceListener(key, action);
    public UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action) => this.bus.AddListener(key, action);
    public UnityAction<T0, T1> AddOnceListener<T0, T1>(T key, UnityAction<T0, T1> action) => this.bus.AddOnceListener(key, action);
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) => this.bus.AddListener(key, action);
    public UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) => this.bus.AddOnceListener(key, action);
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) => this.bus.AddListener(key, action);
    public UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) => this.bus.AddOnceListener(key, action);

    public UnityAction RemoveListener(T key, UnityAction action) => this.bus.RemoveListener(key, action);
    public UnityAction RemoveOnceListener(T key, UnityAction action) => this.bus.RemoveOnceListener(key, action);
    public UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action) => this.bus.RemoveListener(key, action);
    public UnityAction<T0> RemoveOnceListener<T0>(T key, UnityAction<T0> action) => this.bus.RemoveOnceListener(key, action);
    public UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action) => this.bus.RemoveListener(key, action);
    public UnityAction<T0, T1> RemoveOnceListener<T0, T1>(T key, UnityAction<T0, T1> action) => this.bus.RemoveOnceListener(key, action);
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) => this.bus.RemoveListener(key, action);
    public UnityAction<T0, T1, T2> RemoveOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) => this.bus.RemoveOnceListener(key, action);
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) => this.bus.RemoveListener(key, action);
    public UnityAction<T0, T1, T2, T3> RemoveOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) => this.bus.RemoveOnceListener(key, action);

    public void Invoke(T key) => this.delayedActions.Add(() => this.bus.Invoke(key));
    public void Invoke<T0>(T key, T0 arg0) => this.delayedActions.Add(() => this.bus.Invoke(key, arg0));
    public void Invoke<T0, T1>(T key, T0 arg0, T1 arg1) => this.delayedActions.Add(() => this.bus.Invoke(key, arg0, arg1));
    public void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2) => this.delayedActions.Add(() => this.bus.Invoke(key, arg0, arg1, arg2));
    public void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => this.delayedActions.Add(() => this.bus.Invoke(key, arg0, arg1, arg2, arg3));
  }

  public class DelayedEventBus : DelayedEventBus<object>, IEventBus<object>, IEventBus {
    public DelayedEventBus() : base(new EventBus()) { }
  }
}