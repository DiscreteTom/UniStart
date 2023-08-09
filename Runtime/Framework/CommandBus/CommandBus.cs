using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class CommandBus : IWritableCommandBus {
    readonly IEventBus bus;
    readonly Dictionary<Type, object> commands;

    public CommandBus(IEventBus bus = null) {
      this.bus = bus ?? new EventBus();
      this.commands = new();
    }

    public UnityAction Add<T>(UnityAction command) where T : ICommand {
      // IMPORTANT! transform UnityAction into UnityAction<T> for latter Get
      this.commands.Add(typeof(T), UniStart.Fn((T _) => command.Invoke()));
      this.bus.AddListener<T>(command);
      return command;
    }
    public UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand {
      this.commands.Add(typeof(T), command);
      this.bus.AddListener(command);
      return command;
    }

    public UnityAction<T> Get<T>() where T : ICommand => this.commands.GetOrDefault(typeof(T)) as UnityAction<T>;

    public void Push<T>(T arg) where T : ICommand => this.bus.Invoke(arg);
  }

  // helper classes
  public class DebugCommandBus : CommandBus {
    public DebugCommandBus(InterceptEventBusMode mode = InterceptEventBusMode.Invoke) : base(new DebugEventBus(name: "DebugCommandBus", mode: mode)) { }
  }
  public class DelayedCommandBus : CommandBus {
    public DelayedCommandBus() : base(new DelayedEventBus()) { }
  }
}