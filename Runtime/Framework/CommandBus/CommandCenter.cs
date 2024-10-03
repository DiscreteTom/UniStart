using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class CommandCenter : ICommandCenter {
    readonly Dictionary<Type, object> dict = new();

    public virtual UnityAction Add<T>(UnityAction command) where T : ICommand {
      this.AddCommon<T>(e => e.AddListener(command));
      return command;
    }
    public virtual UnityAction<T> Add<T>(UnityAction<T> command) where T : ICommand {
      this.AddCommon<T>(e => e.AddListener(command));
      return command;
    }

    /// <summary>
    /// Add a command to the CommandCenter and return the CommandCenter for chaining.
    /// </summary>
    public virtual CommandCenter With<T>(UnityAction command) where T : ICommand {
      this.Add<T>(command);
      return this;
    }
    /// <summary>
    /// Add a command to the CommandCenter and return the CommandCenter for chaining.
    /// </summary>
    public virtual CommandCenter With<T>(UnityAction<T> command) where T : ICommand {
      this.Add(command);
      return this;
    }

    public virtual void Push<T>(T arg) where T : ICommand => (this.dict[typeof(T)] as UniEvent<T>).Invoke(arg);

    void AddCommon<T>(Action<UniEvent<T>> decorator) {
      var e = new UniEvent<T>();
      decorator(e);
      if (!this.dict.TryAdd(typeof(T), e)) {
        throw new InvalidOperationException($"Command of type {typeof(T)} already exists!");
      }
    }
  }
}