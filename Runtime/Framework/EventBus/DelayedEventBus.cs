using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// A wrapper around an IEventBus which delays all events until InvokeDelayed is called.
  /// </summary>
  public class DelayedEventBus : IEventBus {
    UnityAction delayedActions;
    IEventBus bus;

    public DelayedEventBus(IEventBus bus = null) {
      this.bus = bus ?? new EventBus();
      this.delayedActions = () => { };
    }

    /// <summary>
    /// Invoke all delayed actions.
    /// </summary>
    public void InvokeDelayed() {
      this.delayedActions.Invoke();
      this.delayedActions = () => { };
    }

    public UnityAction AddListener<T>(UnityAction action) => this.bus.AddListener<T>(action);
    public UnityAction<T> AddListener<T>(UnityAction<T> action) => this.bus.AddListener(action);
    public UnityAction AddOnceListener<T>(UnityAction action) => this.bus.AddOnceListener<T>(action);
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action) => this.bus.AddOnceListener(action);

    public UnityAction RemoveListener<T>(UnityAction action) => this.bus.RemoveListener<T>(action);
    public UnityAction<T> RemoveListener<T>(UnityAction<T> action) => this.bus.RemoveListener(action);
    public UnityAction RemoveOnceListener<T>(UnityAction action) => this.bus.RemoveOnceListener<T>(action);
    public UnityAction<T> RemoveOnceListener<T>(UnityAction<T> action) => this.bus.RemoveOnceListener(action);

    public void Invoke<T>(T e) => this.delayedActions += () => this.bus.Invoke(e);
  }
}