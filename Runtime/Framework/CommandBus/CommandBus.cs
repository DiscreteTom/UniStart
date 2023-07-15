namespace DT.UniStart {
  public class CommandBus : ICommandBus {
    ICommandRepo repo;

    public CommandBus(ICommandRepo repo) {
      this.repo = repo;
    }

    public void Push<T>(T arg) => this.repo.Invoke(arg);
  }
}