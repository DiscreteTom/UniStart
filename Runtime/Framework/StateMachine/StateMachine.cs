using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class StateMachine<T> : IStateMachine<T>, IEnumState<T> where T : Enum {
    public T Value {
      get => this.value;
      set {
        if (this.value.Equals(value)) return;
        var prev = this.value;
        this.onExitEvents.GetOrDefault(prev)?.Invoke(value, prev);
        this.onEnterEvents.GetOrDefault(value)?.Invoke(value, prev);
        this.value = value;
      }
    }

    T value;
    readonly Dictionary<T, AdvancedEvent<T, T>> onEnterEvents;
    readonly Dictionary<T, AdvancedEvent<T, T>> onExitEvents;

    public StateMachine(T initialState) {
      this.value = initialState;
      this.onEnterEvents = new();
      this.onExitEvents = new();
    }

    public UnityAction AddListener(T value, StateMachineEventType eventType, UnityAction action) {
      return eventType switch {
        StateMachineEventType.OnEnter => this.onEnterEvents.GetOrAddNew(value).AddListener(action),
        StateMachineEventType.OnExit => this.onExitEvents.GetOrAddNew(value).AddListener(action),
        _ => throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!"),
      };
    }
    public UnityAction RemoveListener(T value, StateMachineEventType eventType, UnityAction action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          this.onEnterEvents.GetOrDefault(value)?.RemoveListener(action);
          return action;
        case StateMachineEventType.OnExit:
          this.onExitEvents.GetOrDefault(value)?.RemoveListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }
    public UnityAction AddOnceListener(T value, StateMachineEventType eventType, UnityAction action) {
      return eventType switch {
        StateMachineEventType.OnEnter => this.onEnterEvents.GetOrAddNew(value).AddOnceListener(action),
        StateMachineEventType.OnExit => this.onExitEvents.GetOrAddNew(value).AddOnceListener(action),
        _ => throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!"),
      };
    }
    public UnityAction RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          this.onEnterEvents.GetOrDefault(value)?.RemoveOnceListener(action);
          return action;
        case StateMachineEventType.OnExit:
          this.onExitEvents.GetOrDefault(value)?.RemoveOnceListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }

    public UnityAction<T> AddListener(T value, StateMachineEventType eventType, UnityAction<T> action) {
      return eventType switch {
        StateMachineEventType.OnEnter => this.onEnterEvents.GetOrAddNew(value).AddListener(action),
        StateMachineEventType.OnExit => this.onExitEvents.GetOrAddNew(value).AddListener(action),
        _ => throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!"),
      };
    }
    public UnityAction<T> RemoveListener(T value, StateMachineEventType eventType, UnityAction<T> action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          this.onEnterEvents.GetOrDefault(value)?.RemoveListener(action);
          return action;
        case StateMachineEventType.OnExit:
          this.onExitEvents.GetOrDefault(value)?.RemoveListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }
    public UnityAction<T> AddOnceListener(T value, StateMachineEventType eventType, UnityAction<T> action) {
      return eventType switch {
        StateMachineEventType.OnEnter => this.onEnterEvents.GetOrAddNew(value).AddOnceListener(action),
        StateMachineEventType.OnExit => this.onExitEvents.GetOrAddNew(value).AddOnceListener(action),
        _ => throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!"),
      };
    }
    public UnityAction<T> RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction<T> action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          this.onEnterEvents.GetOrDefault(value)?.RemoveOnceListener(action);
          return action;
        case StateMachineEventType.OnExit:
          this.onExitEvents.GetOrDefault(value)?.RemoveOnceListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }

    public UnityAction<T, T> AddListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) {
      return eventType switch {
        StateMachineEventType.OnEnter => this.onEnterEvents.GetOrAddNew(value).AddListener(action),
        StateMachineEventType.OnExit => this.onExitEvents.GetOrAddNew(value).AddListener(action),
        _ => throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!"),
      };
    }
    public UnityAction<T, T> RemoveListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          this.onEnterEvents.GetOrDefault(value)?.RemoveListener(action);
          return action;
        case StateMachineEventType.OnExit:
          this.onExitEvents.GetOrDefault(value)?.RemoveListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }
    public UnityAction<T, T> AddOnceListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) {
      return eventType switch {
        StateMachineEventType.OnEnter => this.onEnterEvents.GetOrAddNew(value).AddOnceListener(action),
        StateMachineEventType.OnExit => this.onExitEvents.GetOrAddNew(value).AddOnceListener(action),
        _ => throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!"),
      };
    }
    public UnityAction<T, T> RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction<T, T> action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          this.onEnterEvents.GetOrDefault(value)?.RemoveOnceListener(action);
          return action;
        case StateMachineEventType.OnExit:
          this.onExitEvents.GetOrDefault(value)?.RemoveOnceListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }
  }
}