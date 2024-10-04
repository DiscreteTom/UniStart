using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  [Flags]
  public enum DebugEventBusMode {
    None = 0b000,
    AddListener = 0b001,
    RemoveListener = 0b010,
    Invoke = 0b100,
    All = AddListener | RemoveListener | Invoke
  }

  /// <summary>
  /// DebugEventBus is a wrapper around an IEventBus which optionally logs all calls to AddListener, RemoveListener and Invoke.
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
      this.isAddListenerModeEnabled = (this.mode & DebugEventBusMode.AddListener) != 0;
      this.isRemoveListenerModeEnabled = (this.mode & DebugEventBusMode.RemoveListener) != 0;
      this.isInvokeModeEnabled = (this.mode & DebugEventBusMode.Invoke) != 0;
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
      return this.bus.AddListener<T>(action);
    }

    public UnityAction AddOnceListener<T>(UnityAction action) {
      this.LogAddOnceListener<T>();
      return this.bus.AddOnceListener<T>(action);
    }

    public UnityAction RemoveListener<T>(UnityAction action) {
      this.LogRemoveListener<T>();
      return this.bus.RemoveListener<T>(action);
    }

    public UnityAction<T> AddListener<T>(UnityAction<T> action) {
      this.LogAddListener<T>();
      return this.bus.AddListener(action);
    }

    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action) {
      this.LogAddOnceListener<T>();
      return this.bus.AddOnceListener(action);
    }

    public UnityAction<T> RemoveListener<T>(UnityAction<T> action) {
      this.LogRemoveListener<T>();
      return this.bus.RemoveListener(action);
    }

    public void Invoke<T>(T e) {
      if (this.isInvokeModeEnabled) Debug.Log($"{this.name}.Invoke: event = {typeof(T)}, parameter = {e}");
      this.bus.Invoke(e);
    }

    void LogAddListener<T>() {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
    }
    void LogAddOnceListener<T>() {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
    }
    void LogRemoveListener<T>() {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
    }
  }
}