namespace DT.UniStart {
  public class DelayedCommandCenter : CommandCenter {
    // use UniEvent instead of UnityEvent to support stable invoke
    readonly UniEvent delayed = new();

    public override void Push<T>(T e) => this.delayed.AddListener(() => base.Push(e));

    public virtual void Execute() => this.delayed.Invoke();

    /// <summary>
    /// Mount this to a watchable object to auto execute the delayed commands.
    /// </summary>
    public DelayedCommandCenter Mount(IWatchable target) {
      target.AddListener(this.Execute);
      return this;
    }
  }
}