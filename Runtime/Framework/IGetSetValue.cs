namespace DT.UniStart {
  public interface IGetValue<T> {
    T Value { get; }
  }

  public interface ISetValue<T> {
    T Value { set; }
  }

  public static class ISetValueExtension {
    public static void SetValue<T>(this ISetValue<T> value, T newValue) => value.Value = newValue;
  }

  public interface IGetSetValue<T> : IGetValue<T>, ISetValue<T> { }
}