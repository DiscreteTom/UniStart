using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommandRepo {
    ICommandRepo Add<T>(UnityAction command);
    ICommandRepo Add<T>(out UnityAction named, UnityAction command);
    ICommandRepo Add<T>(UnityAction<T> command);
    ICommandRepo Add<T>(out UnityAction<T> named, UnityAction<T> command);
    void Invoke<T>(T arg);
    void Invoke<T>() where T : new();
  }

  public class CommandRepo : ICommandRepo {
    IEventBus bus;

    public CommandRepo(IEventBus bus = null) {
      this.bus = bus ?? new EventBus();
    }

    public ICommandRepo Add<T>(UnityAction command) {
      this.bus.AddListener<T>(command);
      return this;
    }
    public ICommandRepo Add<T>(out UnityAction named, UnityAction command) {
      named = command;
      return this.Add<T>(command);
    }
    public ICommandRepo Add<T>(UnityAction<T> command) {
      this.bus.AddListener(command);
      return this;
    }
    public ICommandRepo Add<T>(out UnityAction<T> named, UnityAction<T> command) {
      named = command;
      return this.Add(command);
    }
    public void Invoke<T>(T arg) => this.bus.Invoke(arg);
    public void Invoke<T>() where T : new() => this.bus.Invoke<T>();
  }
}