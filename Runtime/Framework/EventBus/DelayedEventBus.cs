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
    public UnityAction AddListener<T>(out UnityAction named, UnityAction action) => this.bus.AddListener<T>(out named, action);
    public UnityAction<T> AddListener<T>(UnityAction<T> action) => this.bus.AddListener(action);
    public UnityAction<T> AddListener<T>(out UnityAction<T> named, UnityAction<T> action) => this.bus.AddListener(out named, action);
    public UnityAction AddOnceListener<T>(UnityAction action) => this.bus.AddOnceListener<T>(action);
    public UnityAction AddOnceListener<T>(out UnityAction named, UnityAction action) => this.bus.AddOnceListener<T>(out named, action);
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action) => this.bus.AddOnceListener(action);
    public UnityAction<T> AddOnceListener<T>(out UnityAction<T> named, UnityAction<T> action) => this.bus.AddOnceListener(out named, action);

    public UnityAction RemoveListener<T>(UnityAction action) => this.bus.RemoveListener<T>(action);
    public UnityAction RemoveListener<T>(out UnityAction named, UnityAction action) => this.bus.RemoveListener<T>(out named, action);
    public UnityAction<T> RemoveListener<T>(UnityAction<T> action) => this.bus.RemoveListener(action);
    public UnityAction<T> RemoveListener<T>(out UnityAction<T> named, UnityAction<T> action) => this.bus.RemoveListener(out named, action);

    public void Invoke<T>(T e) => this.delayedActions += () => this.bus.Invoke(e);
    public void Invoke<T>() where T : new() => this.Invoke(new T());
  }
}