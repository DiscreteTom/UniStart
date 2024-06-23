using System;
using System.Collections.Generic;

namespace DT.UniStart {
  public class StepExecutor<S> : IStepExecutor<S> where S : IConvertible {
    readonly SortedList<int, AdvancedEvent> actions = new();

    public virtual AdvancedEvent On(S step) {
      return this.actions.GetOrAdd((int)(step as IConvertible), () => new());
    }

    public virtual void Invoke() => this.actions.ForEach((kv) => kv.Value.Invoke());
  }

  public class StepExecutor<S, T> : IStepExecutor<S, T> where S : IConvertible {
    readonly SortedList<int, AdvancedEvent<T>> actions = new();

    public virtual AdvancedEvent<T> On(S step) {
      return this.actions.GetOrAdd((int)(step as IConvertible), () => new());
    }

    public virtual void Invoke(T ctx) => this.actions.ForEach((kv) => kv.Value.Invoke(ctx));
  }
}
