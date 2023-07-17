using UnityEngine.Events;

namespace DT.UniStart {
  public class CommandBus : IWritableCommandBus {
    IEventBus bus;

    public CommandBus(IEventBus bus = null) {
      this.bus = bus ?? new EventBus();
    }

    public UnityAction Add<T>(UnityAction command) {
      this.bus.AddListener<T>(command);
      return command;
    }
    public UnityAction<T> Add<T>(UnityAction<T> command) {
      this.bus.AddListener(command);
      return command;
    }

    public void Push<T>(T arg) => this.bus.Invoke(arg);
  }

  // helper classes
  public class DebugCommandBus : CommandBus {
    public DebugCommandBus(DebugEventBusMode mode = DebugEventBusMode.Invoke) : base(new DebugEventBus(name: "DebugCommandBus", mode: mode)) { }
  }
  public class DelayedCommandBus : CommandBus {
    public DelayedCommandBus() : base(new DelayedEventBus()) { }
  }
}