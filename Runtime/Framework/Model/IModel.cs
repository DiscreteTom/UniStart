namespace DT.UniStart {
  public interface IReadonlyModel : IEventListener {
    T Get<T>();
  }
  public interface IModel : IReadonlyModel {
    IModel Add<T>(T value);
    IModel Commit<T>(T value);
  }
}