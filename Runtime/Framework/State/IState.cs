using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;

namespace DT.UniStart {
  #region State
  public interface IState<T> : IWatchable, IWatchable<T>, IGetValue<T> { }
  public interface IListState<T> : IReadOnlyList<T>, IWatchable, IWatchable<ReadOnlyCollection<T>>, IGetValue<ReadOnlyCollection<T>> {
    bool Contains(T item);
    int IndexOf(T item);
    void CopyTo(T[] array, int arrayIndex);
    bool IsReadOnly { get; }
    int BinarySearch(T item);
    int BinarySearch(T item, IComparer<T> comparer);
    int BinarySearch(int index, int count, T item, IComparer<T> comparer);
  }
  public interface IDictionaryState<K, V> : IReadOnlyDictionary<K, V>, IWatchable, IWatchable<ReadOnlyDictionary<K, V>>, IGetValue<ReadOnlyDictionary<K, V>> { }
  #endregion

  #region State Manager
  public interface ICommittableList<T> {
    void Commit(UnityAction<IList<T>> action);
  }
  public interface ICommittableDictionary<K, V> {
    void Commit(UnityAction<IDictionary<K, V>> action);
  }
  public interface IStateCommitter {
    // Commit will trigger change event once.
    IStateCommitter Commit<T>(IState<T> s, T value);
    IStateCommitter Commit<T>(IListState<T> s, UnityAction<IList<T>> f);
    IStateCommitter Commit<K, V>(IDictionaryState<K, V> s, UnityAction<IDictionary<K, V>> f);

    // Apply may trigger change event multiple times.
    IStateCommitter Apply<T>(IListState<T> s, UnityAction<IList<T>> f);
    IStateCommitter Apply<K, V>(IDictionaryState<K, V> s, UnityAction<IDictionary<K, V>> f);
  }

  public interface IStateManager : IStateCommitter { }

  public static class IStateManagerExtension {
    public static IState<T> Add<T>(this IStateManager _, T value) => new Watch<T>(value);
    public static IListState<T> AddList<T>(this IStateManager _) => new WatchList<T>();
    public static IListState<T> AddList<T>(this IStateManager _, List<T> value) => new WatchList<T>(value);
    public static IListState<T> AddArray<T>(this IStateManager _, int n) => new WatchArray<T>(n);
    public static IListState<T> AddArray<T>(this IStateManager _, T[] value) => new WatchArray<T>(value);
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager _) => new WatchDictionary<K, V>();
  }
  #endregion
}