using UnityEngine.Events;

namespace DT.UniStart {
  public class DelayedEventBus : EventBus {
    UnityEvent delayed = new();
    UnityEvent shadow = new();

    public override void Invoke<T>(T e) => this.delayed.AddListener(() => base.Invoke(e));

    public virtual void InvokeDelayed() {
      // swap delayed and shadow to prevent modifying the delayed list while executing
      (this.delayed, this.shadow) = (this.shadow, this.delayed);

      this.shadow.Invoke();
      this.shadow.RemoveAllListeners();
    }

    public DelayedEventBus Mount(IWatchable target) {
      target.AddListener(this.InvokeDelayed);
      return this;
    }
  }
}