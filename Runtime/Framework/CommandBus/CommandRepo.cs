using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class CommandRepo : ICommandRepo {
    IEventBus bus;

    public CommandRepo(IEventBus bus = null) {
      this.bus = bus ?? new EventBus();
    }

    public ICommandRepo Add<T>(UnityAction command) {
      this.bus.AddListener<T>(command);
      return this;
    }
    public ICommandRepo Add<T>(UnityAction<T> command) {
      this.bus.AddListener(command);
      return this;
    }
    public void Invoke<T>(T arg) => this.bus.Invoke(arg);
  }
}