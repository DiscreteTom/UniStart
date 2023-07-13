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
    Parameter = 8,
    All = AddListener | RemoveListener | Invoke | Parameter
  }

  /// <summary>
  /// DebugEventBus is a wrapper around an IEventBus which logs all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugEventBus : IEventBus {
    DebugEventBusMode mode;
    IEventBus bus;
    string name;

    bool isAddListenerModeEnabled => (this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener;
    bool isRemoveListenerModeEnabled => (this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener;
    bool isInvokeModeEnabled => (this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke;
    bool isParameterModeEnabled => (this.mode & DebugEventBusMode.Parameter) == DebugEventBusMode.Parameter;

    public DebugEventBus(IEventBus bus = null, DebugEventBusMode mode = DebugEventBusMode.Invoke, string name = "DebugEventBus") {
      this.bus = bus ?? new EventBus();
      this.mode = mode;
      this.name = name;
    }

    public UnityAction AddListener<T>(UnityAction action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
      return this.bus.AddListener<T>(action);
    }
    public UnityAction AddListener<T>(UnityAction action, out UnityAction named) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
      return this.bus.AddListener<T>(action, out named);
    }
    public UnityAction<T> AddListener<T>(UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
      return this.bus.AddListener(action);
    }
    public UnityAction<T> AddListener<T>(UnityAction<T> action, out UnityAction<T> named) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
      return this.bus.AddListener(action, out named);
    }
    public UnityAction AddOnceListener<T>(UnityAction action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener<T>(action);
    }
    public UnityAction AddOnceListener<T>(UnityAction action, out UnityAction named) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener<T>(action, out named);
    }
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener(action);
    }
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action, out UnityAction<T> named) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener(action, out named);
    }

    public UnityAction RemoveListener<T>(UnityAction action) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener<T>(action);
    }
    public UnityAction RemoveListener<T>(UnityAction action, out UnityAction named) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener<T>(action, out named);
    }
    public UnityAction<T> RemoveListener<T>(UnityAction<T> action) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener(action);
    }
    public UnityAction<T> RemoveListener<T>(UnityAction<T> action, out UnityAction<T> named) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener(action, out named);
    }

    public void Invoke<T>(T e) {
      if (this.isInvokeModeEnabled || this.isParameterModeEnabled) {
        string message = "DebugEventBus.Invoke: ";
        if (this.isInvokeModeEnabled) message += $"event = {typeof(T)}";
        if (this.isInvokeModeEnabled && this.isParameterModeEnabled) message += ", ";
        if (this.isParameterModeEnabled) message += $"parameter = {e}";
        Debug.Log(message);
      }
      this.bus.Invoke(e);
    }
    public void Invoke<T>() where T : new() => this.Invoke(new T());
  }
}