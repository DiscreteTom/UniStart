namespace DT.UniStart {
  /// <summary>
  /// Explicit box. Useful for passing by reference.
  /// </summary>
  public class Box<T> {
    public T Value;

    public Box(T value) {
      this.Value = value;
    }
  }
}