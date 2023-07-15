namespace DT.UniStart {
  public interface ICommandBus {
    void Push<T>(T arg);
  }

  public static class ICommandBusExtension {
    public static void Push<T>(this ICommandBus self) where T : new() {
      self.Push(new T());
    }
  }
}