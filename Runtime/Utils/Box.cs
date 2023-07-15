namespace DT.UniStart {
  /// <summary>
  /// Explicit box. Useful for passing by reference.
  /// </summary>
  public class Box<T> : IGetSetValue<T> {
    public T Value { get; set; }

    public Box(T value) {
      this.Value = value;
    }
  }
}