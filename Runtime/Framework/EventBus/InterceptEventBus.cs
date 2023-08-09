using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  [Flags]
  public enum InterceptEventBusMode {
    None = 0,
    AddListener = 1,
    RemoveListener = 2,
    Invoke = 4,
    All = AddListener | RemoveListener | Invoke
  }

  /// <summary>
  /// InterceptEventBus is a wrapper around an IEventBus which proxy all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class InterceptEventBus : IEventBus {

    protected IEventBus bus { get; private set; }
    protected InterceptEventBusMode mode { get; private set; }
    protected bool isAddListenerModeEnabled;
    protected bool isRemoveListenerModeEnabled;
    protected bool isInvokeModeEnabled;

    readonly AdvancedEvent<Type, UnityAction> onAddListener;
    readonly AdvancedEvent<Type, UnityAction> onRemoveListener;
    readonly AdvancedEvent<Type, object, UnityAction> onInvoke;

    public InterceptEventBus(IEventBus bus = null, InterceptEventBusMode mode = InterceptEventBusMode.Invoke) {
      this.bus = bus ?? new EventBus();
      this.mode = mode;
      this.isAddListenerModeEnabled = (this.mode & InterceptEventBusMode.AddListener) == InterceptEventBusMode.AddListener;
      this.isRemoveListenerModeEnabled = (this.mode & InterceptEventBusMode.RemoveListener) == InterceptEventBusMode.RemoveListener;
      this.isInvokeModeEnabled = (this.mode & InterceptEventBusMode.Invoke) == InterceptEventBusMode.Invoke;
      this.onAddListener = new AdvancedEvent<Type, UnityAction>();
      this.onRemoveListener = new AdvancedEvent<Type, UnityAction>();
      this.onInvoke = new AdvancedEvent<Type, object, UnityAction>();
    }

    protected InterceptEventBus OnAddListener(UnityAction<Type, UnityAction> action) {
      this.onAddListener.AddListener(action);
      return this;
    }
    protected InterceptEventBus OnRemoveListener(UnityAction<Type, UnityAction> action) {
      this.onRemoveListener.AddListener(action);
      return this;
    }
    protected InterceptEventBus OnInvoke(UnityAction<Type, object, UnityAction> action) {
      this.onInvoke.AddListener(action);
      return this;
    }

    public UnityAction<T> AddListener<T>(UnityAction<T> action) where T : IEvent {
      if (this.isAddListenerModeEnabled) this.onAddListener.Invoke(typeof(T), () => this.bus.AddListener(action));
      else this.bus.AddListener(action);
      return action;
    }

    public UnityAction<T> RemoveListener<T>(UnityAction<T> action) where T : IEvent {
      if (this.isRemoveListenerModeEnabled) this.onRemoveListener.Invoke(typeof(T), () => this.bus.RemoveListener(action));
      else this.bus.RemoveListener(action);
      return action;
    }

    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action) where T : IEvent {
      if (this.isAddListenerModeEnabled) this.onAddListener.Invoke(typeof(T), () => this.bus.AddOnceListener(action));
      else this.bus.AddOnceListener(action);
      return action;
    }

    public UnityAction<T> RemoveOnceListener<T>(UnityAction<T> action) where T : IEvent {
      if (this.isRemoveListenerModeEnabled) this.onRemoveListener.Invoke(typeof(T), () => this.bus.RemoveOnceListener(action));
      else this.bus.RemoveOnceListener(action);
      return action;
    }

    public void Invoke<T>(T e) where T : IEvent {
      if (this.isInvokeModeEnabled) this.onInvoke.Invoke(typeof(T), e, () => this.bus.Invoke(e));
      else this.bus.Invoke(e);
    }
  }
}