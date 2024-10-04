namespace DT.UniStart {
  public class DelayedCommandBus<Ctx> : CommandBus<Ctx> {
    // use UniEvent instead of UnityEvent to support stable invoke
    readonly UniEvent delayed = new();

    public DelayedCommandBus(Ctx ctx) : base(ctx) { }

    public override void Push<T>(T command) => this.delayed.AddListener(() => base.Push(command));

    public virtual void Execute() => this.delayed.Invoke();

    /// <summary>
    /// Mount this to a watchable object to auto execute the delayed commands.
    /// </summary>
    public DelayedCommandBus<Ctx> Mount(IWatchable target) {
      target.AddListener(this.Execute);
      return this;
    }
  }
}