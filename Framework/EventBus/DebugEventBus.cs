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
  }

  /// <summary>
  /// DebugEventBus is a wrapper around an IEventBus which logs all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugEventBus<T> : IEventBus where T : IEventBus {

    DebugEventBusMode mode;
    T bus;

    public DebugEventBus(T bus, DebugEventBusMode mode = DebugEventBusMode.Invoke) {
      this.mode = mode;
      this.bus = bus;
    }

    public UnityAction AddListener(object key, UnityAction action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0> AddListener<T0>(object key, UnityAction<T0> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1> AddListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }

    public UnityAction RemoveListener(object key, UnityAction action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0> RemoveListener<T0>(object key, UnityAction<T0> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }

    public void Invoke(object key) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      this.bus.Invoke(key);
    }
    public void Invoke<T0>(object key, T0 arg0) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      this.bus.Invoke(key, arg0);
    }
    public void Invoke<T0, T1>(object key, T0 arg0, T1 arg1) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      this.bus.Invoke(key, arg0, arg1);
    }
    public void Invoke<T0, T1, T2>(object key, T0 arg0, T1 arg1, T2 arg2) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      this.bus.Invoke(key, arg0, arg1, arg2);
    }
    public void Invoke<T0, T1, T2, T3>(object key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      this.bus.Invoke(key, arg0, arg1, arg2, arg3);
    }
  }

  /// <summary>
  /// DebugEventBus logs all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugEventBus : DebugEventBus<EventBus> {
    public DebugEventBus(DebugEventBusMode mode = DebugEventBusMode.Invoke) : base(new EventBus(), mode) { }
  }
}