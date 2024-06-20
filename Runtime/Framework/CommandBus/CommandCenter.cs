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

    public virtual void Push<T>(T arg) where T : ICommand => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.Invoke(arg);

    void AddCommon<T>(Action<AdvancedEvent<T>> decorator) {
      var e = new AdvancedEvent<T>();
      decorator(e);
      if (!this.dict.TryAdd(typeof(T), e)) {
        throw new InvalidOperationException($"Command of type {typeof(T)} already exists!");
      }
    }
  }
}