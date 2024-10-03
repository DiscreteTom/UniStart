using System;
using System.Collections.Generic;

namespace DT.UniStart {
  public class StateMachine<T> : Watch<T>, IStateMachine<T>, IEnumState<T> where T : Enum {
    static readonly T[] values = Enum.GetValues(typeof(T)) as T[];
    readonly Dictionary<T, UniEvent<T, T>> onEnter = new();
    readonly Dictionary<T, UniEvent<T, T>> onExit = new();

    public StateMachine(T initialState) : base(initialState) { }

    public UniEvent<T, T> OnEnter(T value) => this.onEnter.GetOrAdd(value, () => new());
    public UniEvent<T, T> OnExit(T value) => this.onExit.GetOrAdd(value, () => new());

    public T GetNextState() => values[(values.IndexOf(this.value) + 1) % values.Length];

    protected override void InvokeEvent(T prev) {
      base.InvokeEvent(prev);

      if (this.value.Equals(prev)) return;
      this.onExit.GetOrDefault(prev)?.Invoke(value, prev);
      this.onEnter.GetOrDefault(value)?.Invoke(value, prev);
    }
  }
}