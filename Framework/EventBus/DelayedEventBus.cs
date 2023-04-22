using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// A wrapper around an IEventBus which delays all events until InvokeDelayed is called.
  /// </summary>
  public class DelayedEventBus<T> : IEventBus where T : IEventBus {
    List<UnityAction> delayedActions;
    T bus;

    public DelayedEventBus(T eventBus) {
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

    public UnityAction AddListener(object key, UnityAction action) {
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0> AddListener<T0>(object key, UnityAction<T0> action) {
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1> AddListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      return this.bus.AddListener(key, action);
    }

    public UnityAction RemoveListener(object key, UnityAction action) {
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0> RemoveListener<T0>(object key, UnityAction<T0> action) {
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      return this.bus.RemoveListener(key, action);
    }

    public void Invoke(object key) {
      this.delayedActions.Add(() => this.bus.Invoke(key));
    }
    public void Invoke<T0>(object key, T0 arg0) {
      this.delayedActions.Add(() => this.bus.Invoke(key, arg0));
    }
    public void Invoke<T0, T1>(object key, T0 arg0, T1 arg1) {
      this.delayedActions.Add(() => this.bus.Invoke(key, arg0, arg1));
    }
    public void Invoke<T0, T1, T2>(object key, T0 arg0, T1 arg1, T2 arg2) {
      this.delayedActions.Add(() => this.bus.Invoke(key, arg0, arg1, arg2));
    }
    public void Invoke<T0, T1, T2, T3>(object key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      this.delayedActions.Add(() => this.bus.Invoke(key, arg0, arg1, arg2, arg3));
    }
  }

  public class DelayedEventBus : DelayedEventBus<EventBus> {
    public DelayedEventBus() : base(new EventBus()) { }
  }
}