using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  [Flags]
  public enum DebugEventBusMode {
    None = 0,
    AddListener = 1,
    RemoveListener = 2,
    Invoke = 4,
    All = AddListener | RemoveListener | Invoke
  }

  /// <summary>
  /// DebugEventBus is a wrapper around an IEventBus which logs all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugEventBus : IEventBus {
    public string name = "DebugEventBus";

    readonly IEventBus bus;

    readonly DebugEventBusMode mode;
    // cache the enabled modes for performance
    readonly bool isAddListenerModeEnabled;
    readonly bool isRemoveListenerModeEnabled;
    readonly bool isInvokeModeEnabled;

    public DebugEventBus(IEventBus bus = null, DebugEventBusMode mode = DebugEventBusMode.Invoke) {
      this.bus = bus ?? new EventBus();
      this.mode = mode;
      this.isAddListenerModeEnabled = (this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener;
      this.isRemoveListenerModeEnabled = (this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener;
      this.isInvokeModeEnabled = (this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke;
    }

    /// <summary>
    /// Set the name of the DebugEventBus.
    /// </summary>
    public DebugEventBus WithName(string name) {
      this.name = name;
      return this;
    }

    public UnityAction AddListener<T>(UnityAction action) {
      this.LogAddListener<T>();
      this.bus.AddListener<T>(action);
      return action;
    }

    public UnityAction RemoveListener<T>(UnityAction action) {
      this.LogRemoveListener<T>();
      this.bus.RemoveListener<T>(action);
      return action;
    }

    public UnityAction AddOnceListener<T>(UnityAction action) {
      this.LogAddOnceListener<T>();
      this.bus.AddOnceListener<T>(action);
      return action;
    }

    public UnityAction<T> AddListener<T>(UnityAction<T> action) {
      this.LogAddListener<T>();
      this.bus.AddListener(action);
      return action;
    }

    public UnityAction<T> RemoveListener<T>(UnityAction<T> action) {
      this.LogRemoveListener<T>();
      this.bus.RemoveListener(action);
      return action;
    }

    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action) {
      this.LogAddOnceListener<T>();
      this.bus.AddOnceListener(action);
      return action;
    }

    public void Invoke<T>(T e) {
      if (this.isInvokeModeEnabled)
        Debug.Log($"{this.name}.Invoke: event = {typeof(T)}, parameter = {e}");
      this.bus.Invoke(e);
    }

    void LogAddListener<T>() {
      if (this.isAddListenerModeEnabled)
        Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
    }
    void LogRemoveListener<T>() {
      if (this.isRemoveListenerModeEnabled)
        Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
    }
    void LogAddOnceListener<T>() {
      if (this.isAddListenerModeEnabled)
        Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
    }
  }
}