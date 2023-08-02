using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public enum StateMachineEventType {
    OnEnter,
    OnExit,
  }

  // TODO: composable behaviour.Watch for IStateMachine
  // TODO: InterceptStateMachine, DebugStateMachine
  public interface IStateMachine<T> where T : Enum {
    T State { get; set; }
    UnityAction AddListener(T state, StateMachineEventType eventType, UnityAction action);
    UnityAction RemoveListener(T state, StateMachineEventType eventType, UnityAction action);
    UnityAction<T> AddListener(T state, StateMachineEventType eventType, UnityAction<T> action);
    UnityAction<T> RemoveListener(T state, StateMachineEventType eventType, UnityAction<T> action);
  }

  public static class IStateMachineExtension {
    // TODO: echoed Add/Remove listener, once listener
    public static UnityAction OnEnter<T>(this IStateMachine<T> self, T state, UnityAction action) where T : Enum => self.AddListener(state, StateMachineEventType.OnEnter, action);
    public static UnityAction OnExit<T>(this IStateMachine<T> self, T state, UnityAction action) where T : Enum => self.AddListener(state, StateMachineEventType.OnExit, action);
    public static UnityAction<T> OnEnter<T>(this IStateMachine<T> self, T state, UnityAction<T> action) where T : Enum => self.AddListener(state, StateMachineEventType.OnEnter, action);
    public static UnityAction<T> OnExit<T>(this IStateMachine<T> self, T state, UnityAction<T> action) where T : Enum => self.AddListener(state, StateMachineEventType.OnExit, action);
    public static void SetState<T>(this IStateMachine<T> self, T state) where T : Enum => self.State = state;
    public static void Next<T>(this IStateMachine<T> self) where T : Enum {
      T[] values = Enum.GetValues(typeof(T)) as T[];
      int index = Array.IndexOf(values, self.State);
      index = (index + 1) % values.Length;
      self.SetState(values[index]);
    }
  }

  public class StateMachine<T> : IStateMachine<T> where T : Enum {
    public T State {
      get => this.state; set {
        if (this.state.Equals(value)) return;

        this.onExitEvents.GetOrDefault(this.state)?.Invoke(value);
        this.state = value;
        this.onEnterEvents.GetOrDefault(this.state)?.Invoke(value);
      }
    }

    T state;
    Dictionary<T, AdvancedEvent<T>> onEnterEvents;
    Dictionary<T, AdvancedEvent<T>> onExitEvents;

    public StateMachine(T initialState) {
      this.state = initialState;
      this.onEnterEvents = new Dictionary<T, AdvancedEvent<T>>();
      this.onExitEvents = new Dictionary<T, AdvancedEvent<T>>();
    }

    public UnityAction AddListener(T state, StateMachineEventType eventType, UnityAction action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          return this.onEnterEvents.GetOrAddNew(state).AddListener(action);
        case StateMachineEventType.OnExit:
          return this.onExitEvents.GetOrAddNew(state).AddListener(action);
        default:
          throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!");
      }
    }

    public UnityAction RemoveListener(T state, StateMachineEventType eventType, UnityAction action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          (this.onEnterEvents.GetOrDefault(state) as AdvancedEvent<T>)?.RemoveListener(action);
          return action;
        case StateMachineEventType.OnExit:
          (this.onExitEvents.GetOrDefault(state) as AdvancedEvent<T>)?.RemoveListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }

    public UnityAction<T> AddListener(T state, StateMachineEventType eventType, UnityAction<T> action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          return this.onEnterEvents.GetOrAddNew(state).AddListener(action);
        case StateMachineEventType.OnExit:
          return this.onExitEvents.GetOrAddNew(state).AddListener(action);
        default:
          throw new NotImplementedException($"StateMachine.AddListener for eventType: {eventType} not implemented!");
      }
    }

    public UnityAction<T> RemoveListener(T state, StateMachineEventType eventType, UnityAction<T> action) {
      switch (eventType) {
        case StateMachineEventType.OnEnter:
          (this.onEnterEvents.GetOrDefault(state) as AdvancedEvent<T>)?.RemoveListener(action);
          return action;
        case StateMachineEventType.OnExit:
          (this.onExitEvents.GetOrDefault(state) as AdvancedEvent<T>)?.RemoveListener(action);
          return action;
        default:
          throw new NotImplementedException($"StateMachine.RemoveListener for eventType: {eventType} not implemented!");
      }
    }
  }
}