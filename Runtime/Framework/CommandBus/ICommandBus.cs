namespace DT.UniStart {
  public interface ICommandBus<K> {
    void Push(K key);
    void Push<T1>(K key, T1 arg1);
    void Push<T1, T2>(K key, T1 arg1, T2 arg2);
    void Push<T1, T2, T3>(K key, T1 arg1, T2 arg2, T3 arg3);
    void Push<T1, T2, T3, T4>(K key, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
  }

  public interface ICommandBus : ICommandBus<object> { }
}