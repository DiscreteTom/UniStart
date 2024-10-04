namespace DT.UniStart {
  public class CommandBus<Ctx> : ICommandBus<Ctx> {
    readonly Ctx ctx;

    public CommandBus(Ctx ctx) => this.ctx = ctx;

    public virtual void Push<T>(T command) where T : ICommand<Ctx> => command.Invoke(this.ctx);
  }
}