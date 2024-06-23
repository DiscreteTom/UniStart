using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DT.UniStart {
  #region State
  public interface IValueState<T> : IWatchable<T, T>, IGetValue<T> { }
  public interface IEnumState<T> : IReadOnlyStateMachine<T> where T : Enum { }
  public interface IListState<T> : IReadOnlyList<T>, IWatchable, IWatchable<ReadOnlyCollection<T>>, IGetValue<ReadOnlyCollection<T>> {
    bool Contains(T item);
    int IndexOf(T item);
    void CopyTo(T[] array, int arrayIndex);
    bool IsReadOnly { get; }
    int BinarySearch(T item);
    int BinarySearch(T item, IComparer<T> comparer);
    int BinarySearch(int index, int count, T item, IComparer<T> comparer);
  }
  public interface IArrayState<T> : IListState<T> { }
  public interface IDictionaryState<K, V> : IReadOnlyDictionary<K, V>, IWatchable, IWatchable<ReadOnlyDictionary<K, V>>, IGetValue<ReadOnlyDictionary<K, V>> { }
  #endregion

  #region StateManager
  public class StateManager {
    protected Watch<T> Init<T>(ref IValueState<T> s, T value) => Assign(ref s, new Watch<T>(value));
    protected StateMachine<T> Init<T>(ref IEnumState<T> s, T value) where T : Enum => Assign(ref s, new StateMachine<T>(value));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, int count) => Assign(ref s, new WatchArray<T>(count));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, int count, T fill) => Assign(ref s, new WatchArray<T>(count, fill));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, int count, Func<T> factory) => Assign(ref s, new WatchArray<T>(count, factory));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, T[] value) => Assign(ref s, new WatchArray<T>(value));
    protected WatchList<T> Init<T>(ref IListState<T> s) => Assign(ref s, new WatchList<T>());
    protected WatchList<T> Init<T>(ref IListState<T> s, int count) => Assign(ref s, new WatchList<T>(count));
    protected WatchList<T> Init<T>(ref IListState<T> s, int count, T fill) => Assign(ref s, new WatchList<T>(count, fill));
    protected WatchList<T> Init<T>(ref IListState<T> s, int count, Func<T> factory) => Assign(ref s, new WatchList<T>(count, factory));
    protected WatchList<T> Init<T>(ref IListState<T> s, List<T> value) => Assign(ref s, new WatchList<T>(value));
    protected WatchDictionary<K, V> Init<K, V>(ref IDictionaryState<K, V> s) => Assign(ref s, new WatchDictionary<K, V>());
    protected WatchDictionary<K, V> Init<K, V>(ref IDictionaryState<K, V> s, Dictionary<K, V> value) => Assign(ref s, new WatchDictionary<K, V>(value));

    #region Const Collections
    protected T[] Init<T>(ref IReadOnlyList<T> s, int count) => Assign(ref s, new T[count]);
    protected T[] Init<T>(ref IReadOnlyList<T> s, int count, T fill) {
      var res = new T[count];
      res.Fill(fill);
      return Assign(ref s, res);
    }
    protected T[] Init<T>(ref IReadOnlyList<T> s, int count, Func<T> factory) {
      var res = new T[count];
      res.Fill(factory);
      return Assign(ref s, res);
    }
    protected Dictionary<K, V> Init<K, V>(ref IReadOnlyDictionary<K, V> s) => Assign(ref s, new Dictionary<K, V>());
    protected Watch<T>[] Init<T>(ref IReadOnlyList<IValueState<T>> s, int count) {
      var res = new Watch<T>[count];
      res.Fill(() => new Watch<T>(default));
      return Assign(ref s, res);
    }
    protected Watch<T>[] Init<T>(ref IReadOnlyList<IValueState<T>> s, int count, T fill) {
      var res = new Watch<T>[count];
      res.Fill(() => new Watch<T>(fill));
      return Assign(ref s, res);
    }
    protected StateMachine<T>[] Init<T>(ref IReadOnlyList<IEnumState<T>> s, int count) where T : Enum {
      var res = new StateMachine<T>[count];
      res.Fill(() => new StateMachine<T>(default));
      return Assign(ref s, res);
    }
    protected StateMachine<T>[] Init<T>(ref IReadOnlyList<IEnumState<T>> s, int count, T fill) where T : Enum {
      var res = new StateMachine<T>[count];
      res.Fill(() => new StateMachine<T>(fill));
      return Assign(ref s, res);
    }
    #endregion

    T Assign<T, S>(ref S state, T value) where T : S {
      state = value;
      return value;
    }
  }
  #endregion
}