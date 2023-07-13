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
    public UnityAction AddListener<T>(out UnityAction named, UnityAction action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
      return this.bus.AddListener<T>(out named, action);
    }
    public UnityAction<T> AddListener<T>(UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
      return this.bus.AddListener(action);
    }
    public UnityAction<T> AddListener<T>(out UnityAction<T> named, UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddListener: event = {typeof(T)}");
      return this.bus.AddListener(out named, action);
    }
    public UnityAction AddOnceListener<T>(UnityAction action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener<T>(action);
    }
    public UnityAction AddOnceListener<T>(out UnityAction named, UnityAction action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener<T>(out named, action);
    }
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener(action);
    }
    public UnityAction<T> AddOnceListener<T>(out UnityAction<T> named, UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) Debug.Log($"{this.name}.AddOnceListener: event = {typeof(T)}");
      return this.bus.AddOnceListener(out named, action);
    }

    public UnityAction RemoveListener<T>(UnityAction action) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener<T>(action);
    }
    public UnityAction RemoveListener<T>(out UnityAction named, UnityAction action) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener<T>(out named, action);
    }
    public UnityAction<T> RemoveListener<T>(UnityAction<T> action) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener(action);
    }
    public UnityAction<T> RemoveListener<T>(out UnityAction<T> named, UnityAction<T> action) {
      if (this.isRemoveListenerModeEnabled) Debug.Log($"{this.name}.RemoveListener: event = {typeof(T)}");
      return this.bus.RemoveListener(out named, action);
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