using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public interface ICommandRepo<K> {
    UnityAction Add(K key, UnityAction command);
    UnityAction<T1> Add<T1>(K key, UnityAction<T1> command);
    UnityAction<T1, T2> Add<T1, T2>(K key, UnityAction<T1, T2> command);
    UnityAction<T1, T2, T3> Add<T1, T2, T3>(K key, UnityAction<T1, T2, T3> command);
    UnityAction<T1, T2, T3, T4> Add<T1, T2, T3, T4>(K key, UnityAction<T1, T2, T3, T4> command);
    UnityAction Get(K key);
    UnityAction Get<T1>(K key, T1 arg1);
    UnityAction Get<T1, T2>(K key, T1 arg1, T2 arg2);
    UnityAction Get<T1, T2, T3>(K key, T1 arg1, T2 arg2, T3 arg3);
    UnityAction Get<T1, T2, T3, T4>(K key, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
  }

  public interface ICommandRepo : ICommandRepo<object> { }

  public class CommandRepo<K> : ICommandRepo<K> {
    Dictionary<K, object> commands = new Dictionary<K, object>();

    // for simple command, store the command itself
    public UnityAction Add(K key, UnityAction command) {
      this.commands.Add(key, command);
      return command;
    }
    // for other command, store a factory instead of the command itself
    public UnityAction<T1> Add<T1>(K key, UnityAction<T1> command) {
      this.commands.Add(key, (Func<T1, UnityAction>)((T1 arg1) => () => command.Invoke(arg1)));
      return command;
    }
    public UnityAction<T1, T2> Add<T1, T2>(K key, UnityAction<T1, T2> command) {
      this.commands.Add(key, (Func<T1, T2, UnityAction>)((T1 arg1, T2 arg2) => () => command.Invoke(arg1, arg2)));
      return command;
    }
    public UnityAction<T1, T2, T3> Add<T1, T2, T3>(K key, UnityAction<T1, T2, T3> command) {
      this.commands.Add(key, (Func<T1, T2, T3, UnityAction>)((T1 arg1, T2 arg2, T3 arg3) => () => command.Invoke(arg1, arg2, arg3)));
      return command;
    }
    public UnityAction<T1, T2, T3, T4> Add<T1, T2, T3, T4>(K key, UnityAction<T1, T2, T3, T4> command) {
      this.commands.Add(key, (Func<T1, T2, T3, T4, UnityAction>)((T1 arg1, T2 arg2, T3 arg3, T4 arg4) => () => command.Invoke(arg1, arg2, arg3, arg4)));
      return command;
    }

    // for simple command, return the command itself
    public UnityAction Get(K key) => (UnityAction)this.commands[key];
    // for other command, invoke the factory to get the command
    public UnityAction Get<T1>(K key, T1 arg1) => ((Func<T1, UnityAction>)this.commands[key]).Invoke(arg1);
    public UnityAction Get<T1, T2>(K key, T1 arg1, T2 arg2) => ((Func<T1, T2, UnityAction>)this.commands[key]).Invoke(arg1, arg2);
    public UnityAction Get<T1, T2, T3>(K key, T1 arg1, T2 arg2, T3 arg3) => ((Func<T1, T2, T3, UnityAction>)this.commands[key]).Invoke(arg1, arg2, arg3);
    public UnityAction Get<T1, T2, T3, T4>(K key, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => ((Func<T1, T2, T3, T4, UnityAction>)this.commands[key]).Invoke(arg1, arg2, arg3, arg4);
  }

  public class CommandRepo : CommandRepo<object>, ICommandRepo { }
}