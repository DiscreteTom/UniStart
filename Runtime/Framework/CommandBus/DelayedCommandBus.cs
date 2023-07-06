using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// A wrapper around an ICommandBus which delays all commands execution until InvokeDelayed is called.
  /// </summary>
  public class DelayedCommandBus<T> : ICommandBus<T> {
    // TODO: use UnityEvent instead of List<UnityAction>
    List<UnityAction> delayedActions;
    ICommandBus<T> bus;

    public DelayedCommandBus(ICommandBus<T> CommandBus) {
      this.bus = CommandBus;
      this.delayedActions = new List<UnityAction>();
    }

    /// <summary>
    /// Invoke all delayed commands execution.
    /// </summary>
    public void InvokeDelayed() {
      foreach (UnityAction action in this.delayedActions) {
        action.Invoke();
      }
      this.delayedActions.Clear();
    }

    public void Push(T key) => this.delayedActions.Add(() => this.bus.Push(key));
    public void Push<T0>(T key, T0 arg0) => this.delayedActions.Add(() => this.bus.Push(key, arg0));
    public void Push<T0, T1>(T key, T0 arg0, T1 arg1) => this.delayedActions.Add(() => this.bus.Push(key, arg0, arg1));
    public void Push<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2) => this.delayedActions.Add(() => this.bus.Push(key, arg0, arg1, arg2));
    public void Push<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => this.delayedActions.Add(() => this.bus.Push(key, arg0, arg1, arg2, arg3));
  }

  public class DelayedCommandBus : DelayedCommandBus<object>, ICommandBus<object>, ICommandBus {
    public DelayedCommandBus(ICommandRepo repo) : base(new CommandBus(repo)) { }
  }
}