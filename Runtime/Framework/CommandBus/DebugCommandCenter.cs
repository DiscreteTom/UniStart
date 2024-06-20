using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  [Flags]
  public enum DebugCommandCenterMode {
    None = 0,
    Add = 1,
    Push = 2,
    All = Add | Push
  }

  public class DebugCommandCenter : ICommandCenter {
    public string name = "DebugCommandCenter";

    readonly ICommandCenter inner;

    readonly DebugCommandCenterMode mode;
    // cache the enabled modes for performance
    readonly bool isAddModeEnabled;
    readonly bool isPushModeEnabled;

    public DebugCommandCenter(ICommandCenter inner = null, DebugCommandCenterMode mode = DebugCommandCenterMode.Push) {
      this.inner = inner ?? new CommandCenter();
      this.mode = mode;
      this.isAddModeEnabled = (this.mode & DebugCommandCenterMode.Add) == DebugCommandCenterMode.Add;
      this.isPushModeEnabled = (this.mode & DebugCommandCenterMode.Push) == DebugCommandCenterMode.Push;
    }

    /// <summary>
    /// Set the name of the DebugCommandCenter.
    /// </summary>
    public DebugCommandCenter WithName(string name) {
      this.name = name;
      return this;
    }

    public UnityAction Add<T>(UnityAction command) where T : ICommand {
      this.LogAdd<T>();
      return this.inner.Add<T>(command);
    }

    public UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand {
      this.LogAdd<T>();
      return this.inner.Add(command);
    }

    public void Push<T>(T arg) where T : ICommand {
      if (this.isPushModeEnabled)
        Debug.Log($"{this.name}.Push: command = {typeof(T)}");
      this.inner.Push(arg);
    }

    void LogAdd<T>() {
      if (this.isAddModeEnabled)
        Debug.Log($"{this.name}.Add: command = {typeof(T)}");
    }
  }
}