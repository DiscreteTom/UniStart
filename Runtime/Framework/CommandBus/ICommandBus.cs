namespace DT.UniStart {
  /// <summary>
  /// A command will change the state of the context.
  /// </summary>
  public interface ICommand<T> {
    void Exec(T context);
  }

  /// <summary>
  /// A command will change the state of the context.
  /// </summary>
  public interface ICommand : ICommand<IIoCC> { }

  public interface ICommandBus<T> {
    void Push(ICommand<T> command);
  }

  public interface ICommandBus : ICommandBus<IIoCC> { }
}