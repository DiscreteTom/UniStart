using UnityEngine.Events;

namespace DT.UniStart {
  public class DelayedCommandCenter : CommandCenter {
    UnityEvent delayed = new();
    UnityEvent shadow = new();

    public override void Push<T>(T e) => this.delayed.AddListener(() => base.Push(e));

    public virtual void Execute() {
      // swap delayed and shadow to prevent modifying the delayed list while executing
      (this.delayed, this.shadow) = (this.shadow, this.delayed);

      this.shadow.Invoke();
      this.shadow.RemoveAllListeners();
    }

    public DelayedCommandCenter Mount(IWatchable target) {
      target.AddListener(this.Execute);
      return this;
    }
  }
}