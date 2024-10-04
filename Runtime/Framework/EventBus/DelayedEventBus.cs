namespace DT.UniStart {
  public class DelayedEventBus : EventBus {
    // use UniEvent instead of UnityEvent to support stable invoke
    UniEvent delayed = new();

    public override void Invoke<T>(T e) => this.delayed.AddListener(() => base.Invoke(e));

    public virtual void InvokeDelayed() => this.delayed.Invoke();

    /// <summary>
    /// Mount this to a watchable object to auto invoke the delayed events.
    /// </summary>
    public DelayedEventBus Mount(IWatchable target) {
      target.AddListener(this.InvokeDelayed);
      return this;
    }
  }
}