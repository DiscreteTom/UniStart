using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  class State<T> : IState<T> {
    public T Value => this.box.Value;

    Box<T> box;
    AdvancedEvent<T> listeners;

    public State(Box<T> box, AdvancedEvent<T> listeners) {
      this.box = box;
      this.listeners = listeners;
    }

    // IWatchable
    public UnityAction AddListener(UnityAction listener) => this.listeners.AddListener(listener);
    public UnityAction RemoveListener(UnityAction listener) => this.listeners.RemoveListener(listener);
    public UnityAction<T> AddListener(UnityAction<T> listener) => this.listeners.AddListener(listener);
    public UnityAction<T> RemoveListener(UnityAction<T> listener) => this.listeners.RemoveListener(listener);
  }

  public class StateManager : IStateManager {
    // StateItem => value setter
    Dictionary<object, object> dict;

    public StateManager() {
      this.dict = new Dictionary<object, object>();
    }

    public IState<T> Add<T>(T value) {
      var box = new Box<T>(value);
      var listeners = new AdvancedEvent<T>();
      var setter = new Action<T>(v => {
        box.Value = v;
        listeners.Invoke(v);
      });
      var item = new State<T>(box, listeners);
      this.dict.Add(item, setter);
      return item;
    }

    public IStateCommitter Commit<T>(IState<T> item, T value) {
      (this.dict[item] as Action<T>).Invoke(value);
      return this;
    }
  }
}