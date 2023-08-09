using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class DebugStateMachine<T> : IStateMachine<T> where T : Enum {
    readonly IStateMachine<T> machine;

    public T Value {
      get => (this.machine as IGetValue<T>).Value;
      set {
        Debug.Log($"DebugStateMachine: {(this.machine as IGetValue<T>).Value} -> {value}");
        (this.machine as ISetValue<T>).Value = value;
      }
    }

    public DebugStateMachine(T initialState) {
      this.machine = new StateMachine<T>(initialState);
    }

    public DebugStateMachine(IStateMachine<T> machine) {
      this.machine = machine;
    }


    public UnityAction AddListener(T value, StateMachineEventType eventType, UnityAction action) => this.machine.AddListener(value, eventType, action);
    public UnityAction RemoveListener(T value, StateMachineEventType eventType, UnityAction action) => this.machine.RemoveListener(value, eventType, action);
    public UnityAction AddOnceListener(T value, StateMachineEventType eventType, UnityAction action) => this.machine.AddOnceListener(value, eventType, action);
    public UnityAction RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction action) => this.machine.RemoveOnceListener(value, eventType, action);
    public UnityAction<T> AddListener(T value, StateMachineEventType eventType, UnityAction<T> action) => this.machine.AddListener(value, eventType, action);
    public UnityAction<T> RemoveListener(T value, StateMachineEventType eventType, UnityAction<T> action) => this.machine.RemoveListener(value, eventType, action);
    public UnityAction<T> AddOnceListener(T value, StateMachineEventType eventType, UnityAction<T> action) => this.machine.AddOnceListener(value, eventType, action);
    public UnityAction<T> RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction<T> action) => this.machine.RemoveOnceListener(value, eventType, action);
    public UnityAction<T, T> AddListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) => this.machine.AddListener(value, eventType, action);
    public UnityAction<T, T> RemoveListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) => this.machine.RemoveListener(value, eventType, action);
    public UnityAction<T, T> AddOnceListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) => this.machine.AddOnceListener(value, eventType, action);
    public UnityAction<T, T> RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) => this.machine.RemoveOnceListener(value, eventType, action);
  }
}