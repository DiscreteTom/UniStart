namespace DT.UniStart {
  /// <summary>
  /// A command bus which will execute the command immediately.
  /// </summary>
  public class CommandBus<T> : ICommandBus<T> {
    T context;

    public CommandBus(T context) {
      this.context = context;
    }

    public void Push(ICommand<T> command) {
      command.Exec(this.context);
    }
  }

  /// <summary>
  /// A command bus which will execute the command immediately.
  /// </summary>
  public class CommandBus : CommandBus<IIoCC>, ICommandBus {
    public CommandBus(IIoCC context) : base(context) { }
  }
}