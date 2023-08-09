using UnityEngine.Events;

namespace DT.UniStart {
  public class CommandBus : IWritableCommandBus {
    IEventBus bus;

    public CommandBus(IEventBus bus = null) {
      this.bus = bus ?? new EventBus();
    }

    public UnityAction Add<T>(UnityAction command) where T : ICommand {
      this.bus.AddListener<T>(command);
      return command;
    }
    public UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand {
      this.bus.AddListener(command);
      return command;
    }

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