using System;

namespace DT.UniStart {
  public interface IReadOnlyStateMachine<T> : IWatchable<T, T>, IGetValue<T> where T : Enum {
    /// <summary>
    /// Get the next state round-robin.
    /// </summary>
    T GetNextState();

    UniEvent<T, T> OnEnter(T value);
    UniEvent<T, T> OnExit(T value);
  }

  public interface IStateMachine<T> : IGetSetValue<T>, IReadOnlyStateMachine<T> where T : Enum { }

  public static class IStateMachineExtension {
    /// <summary>
    /// Set the state to the next state round-robin.
    /// </summary>
    public static void ToNextState<T>(this IStateMachine<T> self) where T : Enum => self.SetValue(self.GetNextState());
  }
}