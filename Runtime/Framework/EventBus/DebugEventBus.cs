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
  }

  /// <summary>
  /// DebugEventBus is a wrapper around an IEventBus which logs all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugEventBus<T> : IEventBus<T> {
    DebugEventBusMode mode;
    IEventBus<T> bus;

    public DebugEventBus(IEventBus<T> bus, DebugEventBusMode mode = DebugEventBusMode.Invoke) {
      this.mode = mode;
      this.bus = bus;
    }

    public UnityAction AddListener(T key, UnityAction action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction AddOnceListener(T key, UnityAction action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddOnceListener: key = {key}");
      return this.bus.AddOnceListener(key, action);
    }
    public UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0> AddOnceListener<T0>(T key, UnityAction<T0> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddOnceListener: key = {key}");
      return this.bus.AddOnceListener(key, action);
    }
    public UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1> AddOnceListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddOnceListener: key = {key}");
      return this.bus.AddOnceListener(key, action);
    }
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddOnceListener: key = {key}");
      return this.bus.AddOnceListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddListener: key = {key}");
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if ((this.mode & DebugEventBusMode.AddListener) == DebugEventBusMode.AddListener) Debug.Log($"DebugEventBus.AddOnceListener: key = {key}");
      return this.bus.AddOnceListener(key, action);
    }

    public UnityAction RemoveListener(T key, UnityAction action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction RemoveOnceListener(T key, UnityAction action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveOnceListener: key = {key}");
      return this.bus.RemoveOnceListener(key, action);
    }
    public UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0> RemoveOnceListener<T0>(T key, UnityAction<T0> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveOnceListener: key = {key}");
      return this.bus.RemoveOnceListener(key, action);
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1> RemoveOnceListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveOnceListener: key = {key}");
      return this.bus.RemoveOnceListener(key, action);
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2> RemoveOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveOnceListener: key = {key}");
      return this.bus.RemoveOnceListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveListener: key = {key}");
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> RemoveOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if ((this.mode & DebugEventBusMode.RemoveListener) == DebugEventBusMode.RemoveListener) Debug.Log($"DebugEventBus.RemoveOnceListener: key = {key}");
      return this.bus.RemoveOnceListener(key, action);
    }

    public void Invoke(T key) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      this.bus.Invoke(key);
    }
    public void Invoke<T0>(T key, T0 arg0) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      if ((this.mode & DebugEventBusMode.Parameter) == DebugEventBusMode.Parameter) Debug.Log($"DebugEventBus.Invoke: arg0 = {arg0}");
      this.bus.Invoke(key, arg0);
    }
    public void Invoke<T0, T1>(T key, T0 arg0, T1 arg1) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      if ((this.mode & DebugEventBusMode.Parameter) == DebugEventBusMode.Parameter) Debug.Log($"DebugEventBus.Invoke: arg0 = {arg0}, arg1 = {arg1}");
      this.bus.Invoke(key, arg0, arg1);
    }
    public void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      if ((this.mode & DebugEventBusMode.Parameter) == DebugEventBusMode.Parameter) Debug.Log($"DebugEventBus.Invoke: arg0 = {arg0}, arg1 = {arg1}, arg2 = {arg2}");
      this.bus.Invoke(key, arg0, arg1, arg2);
    }
    public void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      if ((this.mode & DebugEventBusMode.Invoke) == DebugEventBusMode.Invoke) Debug.Log($"DebugEventBus.Invoke: key = {key}");
      if ((this.mode & DebugEventBusMode.Parameter) == DebugEventBusMode.Parameter) Debug.Log($"DebugEventBus.Invoke: arg0 = {arg0}, arg1 = {arg1}, arg2 = {arg2}, arg3 = {arg3}");
      this.bus.Invoke(key, arg0, arg1, arg2, arg3);
    }
  }

  /// <summary>
  /// DebugEventBus can log calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugEventBus : DebugEventBus<object>, IEventBus<object>, IEventBus {
    public DebugEventBus(DebugEventBusMode mode = DebugEventBusMode.Invoke) : base(new EventBus(), mode) { }
  }
}