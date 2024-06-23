using UnityEngine.Events;

namespace DT.UniStart {
  public class DelayedEventBus : EventBus {
    readonly UnityEvent delayed = new();

    public override void Invoke<T>(T e) => this.delayed.AddListener(() => base.Invoke(e));

    public void InvokeDelayed() {
      this.delayed.Invoke();
      this.delayed.RemoveAllListeners();
    }
  }
}