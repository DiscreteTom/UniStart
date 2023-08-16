using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public enum StateMachineEventType {
    OnEnter,
    OnExit,
  }

  public interface IReadOnlyStateMachine<T> : IGetValue<T> where T : Enum {
    UnityAction AddListener(T value, StateMachineEventType eventType, UnityAction action);
    UnityAction RemoveListener(T value, StateMachineEventType eventType, UnityAction action);
    UnityAction AddOnceListener(T value, StateMachineEventType eventType, UnityAction action);
    UnityAction RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction action);
    UnityAction<T> AddListener(T value, StateMachineEventType eventType, UnityAction<T> action);
    UnityAction<T> RemoveListener(T value, StateMachineEventType eventType, UnityAction<T> action);
    UnityAction<T> AddOnceListener(T value, StateMachineEventType eventType, UnityAction<T> action);
    UnityAction<T> RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction<T> action);
    UnityAction<T, T> AddListener(T value, StateMachineEventType eventType, UnityAction<T, T> action);
    UnityAction<T, T> RemoveListener(T value, StateMachineEventType eventType, UnityAction<T, T> action);
    UnityAction<T, T> AddOnceListener(T value, StateMachineEventType eventType, UnityAction<T, T> action);
    UnityAction<T, T> RemoveOnceListener(T value, StateMachineEventType eventType, UnityAction<T, T> action);
  }

  public static class IReadOnlyStateMachineExtension {
    public static UnityAction OnEnter<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction action) where T : Enum => self.AddListener(value, StateMachineEventType.OnEnter, action);
    public static UnityAction OnExit<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction action) where T : Enum => self.AddListener(value, StateMachineEventType.OnExit, action);
    public static UnityAction OnceEnter<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction action) where T : Enum => self.AddOnceListener(value, StateMachineEventType.OnEnter, action);
    public static UnityAction OnceExit<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction action) where T : Enum => self.AddOnceListener(value, StateMachineEventType.OnExit, action);
    public static UnityAction<T> OnEnter<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T> action) where T : Enum => self.AddListener(value, StateMachineEventType.OnEnter, action);
    public static UnityAction<T> OnExit<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T> action) where T : Enum => self.AddListener(value, StateMachineEventType.OnExit, action);
    public static UnityAction<T> OnceEnter<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T> action) where T : Enum => self.AddOnceListener(value, StateMachineEventType.OnEnter, action);
    public static UnityAction<T> OnceExit<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T> action) where T : Enum => self.AddOnceListener(value, StateMachineEventType.OnExit, action);
    public static UnityAction<T, T> OnEnter<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T, T> action) where T : Enum => self.AddListener(value, StateMachineEventType.OnEnter, action);
    public static UnityAction<T, T> OnExit<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T, T> action) where T : Enum => self.AddListener(value, StateMachineEventType.OnExit, action);
    public static UnityAction<T, T> OnceEnter<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T, T> action) where T : Enum => self.AddOnceListener(value, StateMachineEventType.OnEnter, action);
    public static UnityAction<T, T> OnceExit<T>(this IReadOnlyStateMachine<T> self, T value, UnityAction<T, T> action) where T : Enum => self.AddOnceListener(value, StateMachineEventType.OnExit, action);
  }

  public interface IStateMachine<T> : IGetSetValue<T>, IReadOnlyStateMachine<T> where T : Enum { }

  public static class IStateMachineExtension {
    public static T GetNextState<T>(this IStateMachine<T> self) where T : Enum {
      var values = Enum.GetValues(typeof(T)) as T[];
      var index = Array.IndexOf(values, (self as IGetValue<T>).Value);
      index = (index + 1) % values.Length;
      return values[index];
    }

    public static void ToNextState<T>(this IStateMachine<T> self) where T : Enum => self.SetValue(self.GetNextState());
  }
}