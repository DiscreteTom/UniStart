namespace DT.UniStart {
  public interface IState<T> : IWatchable, IWatchable<T> {
    T Value { get; }
  }

  public interface IStateCommitter {
    IStateCommitter Commit<T>(IState<T> s, T value);
  }

  public interface IStateManager : IStateCommitter {
    IState<T> Add<T>(T value);
  }
}