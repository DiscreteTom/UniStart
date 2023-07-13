namespace DT.UniStart {
  public interface ICommandBus {
    void Push<T>(T arg);
    void Push<T>() where T : new();
  }
}