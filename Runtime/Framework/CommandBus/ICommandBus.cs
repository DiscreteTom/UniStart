namespace DT.UniStart {
  public interface ICommand<Ctx> {
    void Invoke(Ctx ctx);
  }

  public interface ICommandBus<Ctx> {
    void Push<T>(T command) where T : ICommand<Ctx>;
    void Push<T>() where T : ICommand<Ctx>, new() => this.Push(new T());
  }
}