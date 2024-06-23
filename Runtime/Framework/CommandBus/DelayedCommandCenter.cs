using UnityEngine.Events;

namespace DT.UniStart {
  public class DelayedCommandCenter : CommandCenter {
    readonly UnityEvent delayed = new();

    public override void Push<T>(T e) => this.delayed.AddListener(() => base.Push(e));

    public virtual void Execute() {
      this.delayed.Invoke();
      this.delayed.RemoveAllListeners();
    }
  }
}