using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class CommandCenter : ICommandCenter {
    readonly Dictionary<Type, object> dict = new();

    public virtual UnityAction Add<T>(UnityAction handler) {
      this.AddCommon<T>(e => e.AddListener(handler));
      return handler;
    }
    public virtual UnityAction<T> Add<T>(UnityAction<T> handler) {
      this.AddCommon<T>(e => e.AddListener(handler));
      return handler;
    }

    /// <summary>
    /// Register a command with a handler to the CommandCenter and return the CommandCenter for chaining.
    /// </summary>
    public virtual CommandCenter With<T>(UnityAction handler) {
      this.Add<T>(handler);
      return this;
    }
    /// <summary>
    /// Register a command with a handler to the CommandCenter and return the CommandCenter for chaining.
    /// </summary>
    public virtual CommandCenter With<T>(UnityAction<T> handler) {
      this.Add(handler);
      return this;
    }

    public virtual void Push<T>(T arg) => (this.dict[typeof(T)] as UniEvent<T>).Invoke(arg);

    void AddCommon<T>(Action<UniEvent<T>> decorator) {
      var e = new UniEvent<T>();
      decorator(e);
      if (!this.dict.TryAdd(typeof(T), e)) {
        throw new InvalidOperationException($"Command of type {typeof(T)} already exists!");
      }
    }
  }
}