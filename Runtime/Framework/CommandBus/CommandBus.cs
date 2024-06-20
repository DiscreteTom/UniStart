using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class CommandBus : ICommandBus {
    readonly IEventBus bus;
    readonly HashSet<Type> commands = new();

    public CommandBus(IEventBus bus = null) {
      this.bus = bus ?? new EventBus();
    }

    public virtual UnityAction Add<T>(UnityAction command) where T : ICommand {
      this.CheckCommand<T>();
      this.bus.AddListener<T>(command);
      return command;
    }
    public virtual UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand {
      this.CheckCommand<T>();
      this.bus.AddListener(command);
      return command;
    }

    public virtual void Push<T>(T arg) where T : ICommand => this.bus.Invoke(arg);

    void CheckCommand<T>() {
      if (!this.commands.Add(typeof(T)))
        throw new InvalidOperationException($"Command of type {typeof(T)} already exists!");
    }
  }

  // TODO: move to a single file
  public class DebugCommandBus : CommandBus {
    public DebugCommandBus(DebugEventBusMode mode = DebugEventBusMode.Invoke) : base(new DebugEventBus(mode: mode).WithName("DebugCommandBus")) { }
  }
}