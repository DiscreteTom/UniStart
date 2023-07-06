namespace DT.UniStart {
  public interface ICommandBus<K> {
    void Push(K key);
    void Push<T1>(K key, T1 arg1);
    void Push<T1, T2>(K key, T1 arg1, T2 arg2);
    void Push<T1, T2, T3>(K key, T1 arg1, T2 arg2, T3 arg3);
    void Push<T1, T2, T3, T4>(K key, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
  }

  public interface ICommandBus : ICommandBus<object> { }

  /// <summary>
  /// The basic command bus which will execute commands immediately.
  /// </summary>
  public class CommandBus<K> : ICommandBus<K> {
    ICommandRepo<K> repo;

    public CommandBus(ICommandRepo<K> repo) {
      this.repo = repo;
    }

    public void Push(K key) => this.repo.Get(key).Invoke();
    public void Push<T1>(K key, T1 arg1) => this.repo.Get(key, arg1).Invoke();
    public void Push<T1, T2>(K key, T1 arg1, T2 arg2) => this.repo.Get(key, arg1, arg2).Invoke();
    public void Push<T1, T2, T3>(K key, T1 arg1, T2 arg2, T3 arg3) => this.repo.Get(key, arg1, arg2, arg3).Invoke();
    public void Push<T1, T2, T3, T4>(K key, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => this.repo.Get(key, arg1, arg2, arg3, arg4).Invoke();
  }

  public class CommandBus : CommandBus<object>, ICommandBus {
    public CommandBus(ICommandRepo repo) : base(repo) { }
  }
}