using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  [Flags]
  public enum DebugCommandBusMode {
    None = 0,
    Add = 1,
    Push = 2,
    All = Add | Push
  }

  public class DebugCommandBus : ICommandBus {
    public string name = "DebugCommandBus";

    readonly ICommandBus bus;

    readonly DebugCommandBusMode mode;
    // cache the enabled modes for performance
    readonly bool isAddModeEnabled;
    readonly bool isPushModeEnabled;

    public DebugCommandBus(ICommandBus bus = null, DebugCommandBusMode mode = DebugCommandBusMode.Push) {
      this.bus = bus ?? new CommandBus();
      this.mode = mode;
      this.isAddModeEnabled = (this.mode & DebugCommandBusMode.Add) == DebugCommandBusMode.Add;
      this.isPushModeEnabled = (this.mode & DebugCommandBusMode.Push) == DebugCommandBusMode.Push;
    }

    /// <summary>
    /// Set the name of the DebugCommandBus.
    /// </summary>
    public DebugCommandBus WithName(string name) {
      this.name = name;
      return this;
    }

    public UnityAction Add<T>(UnityAction command) where T : ICommand {
      this.LogAdd<T>();
      return this.bus.Add<T>(command);
    }

    public UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand {
      this.LogAdd<T>();
      return this.bus.Add(command);
    }

    public void Push<T>(T arg) where T : ICommand {
      if (this.isPushModeEnabled)
        Debug.Log($"{this.name}.Push: command = {typeof(T)}");
      this.bus.Push(arg);
    }

    void LogAdd<T>() {
      if (this.isAddModeEnabled)
        Debug.Log($"{this.name}.Add: command = {typeof(T)}");
    }
  }
}