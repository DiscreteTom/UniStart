namespace DT.UniStart {
  public interface IGetValue<T> {
    T Value { get; }
  }

  public interface ISetValue<T> {
    T Value { set; }
  }

  public interface IGetSetValue<T> : IGetValue<T>, ISetValue<T> { }
}