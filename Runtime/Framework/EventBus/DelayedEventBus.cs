using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// A wrapper around an IEventBus which delays all events until InvokeDelayed is called.
  /// </summary>
  public class DelayedEventBus : InterceptEventBus {
    UnityAction delayedActions;

    public DelayedEventBus(IEventBus bus = null) : base(bus, InterceptEventBusMode.Invoke) {
      this.delayedActions = () => { };
      this.OnInvoke((type, parameter, proceed) => this.delayedActions += proceed);
    }

    /// <summary>
    /// Invoke all delayed actions.
    /// </summary>
    public void InvokeDelayed() {
      this.delayedActions.Invoke();
      this.delayedActions = () => { };
    }
  }
}