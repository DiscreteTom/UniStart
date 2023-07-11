using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  [Flags]
  public enum DebugCommandBusMode {
    None = 0,
    Push = 1,
    Parameter = 2,
  }

  /// <summary>
  /// A wrapper around an ICommandBus which will log all commands to the console.
  /// </summary>
  public class DebugCommandBus<T> : ICommandBus<T> {
    ICommandBus<T> bus;
    DebugCommandBusMode mode;

    bool isPushModeEnabled => (this.mode & DebugCommandBusMode.Push) == DebugCommandBusMode.Push;
    bool isParameterModeEnabled => (this.mode & DebugCommandBusMode.Parameter) == DebugCommandBusMode.Parameter;

    public DebugCommandBus(ICommandBus<T> CommandBus, DebugCommandBusMode mode = DebugCommandBusMode.Push) {
      this.bus = CommandBus;
      this.mode = mode;
    }

    void LogPush(string keyStr, string argsStr) {
      if (this.isPushModeEnabled || this.isParameterModeEnabled) {
        string message = "DebugCommandBus.Push: ";
        if (this.isPushModeEnabled) message += keyStr;
        if (this.isPushModeEnabled && this.isParameterModeEnabled) message += ", ";
        if (this.isParameterModeEnabled) message += argsStr;
        Debug.Log(message);
      }
    }

    public void Push(T key) {
      if ((this.mode & DebugCommandBusMode.Push) == DebugCommandBusMode.Push) Debug.Log($"DebugCommandBus.Push: key = {key}");
      this.bus.Push(key);
    }
    public void Push<T1>(T key, T1 arg0) {
      this.LogPush($"key = {key}", $"arg0 = {arg0}");
      this.bus.Push(key, arg0);
    }
    public void Push<T1, T2>(T key, T1 arg0, T2 arg1) {
      this.LogPush($"key = {key}", $"arg0 = {arg0}, arg1 = {arg1}");
      this.bus.Push(key, arg0, arg1);
    }
    public void Push<T1, T2, T3>(T key, T1 arg0, T2 arg1, T3 arg2) {
      this.LogPush($"key = {key}", $"arg0 = {arg0}, arg1 = {arg1}, arg2 = {arg2}");
      this.bus.Push(key, arg0, arg1, arg2);
    }
    public void Push<T1, T2, T3, T4>(T key, T1 arg0, T2 arg1, T3 arg2, T4 arg3) {
      this.LogPush($"key = {key}", $"arg0 = {arg0}, arg1 = {arg1}, arg2 = {arg2}, arg3 = {arg3}");
      this.bus.Push(key, arg0, arg1, arg2, arg3);
    }
  }

  public class DebugCommandBus : DebugCommandBus<object>, ICommandBus<object>, ICommandBus {
    public DebugCommandBus(ICommandRepo repo) : base(new CommandBus(repo)) { }
  }
}