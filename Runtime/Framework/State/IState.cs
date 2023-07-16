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

  public interface IStateCommitter { }

  public static class IStateCommitterExtension {
    // Commit will trigger change event once.
    public static IStateCommitter Commit<T>(this IStateCommitter self, IState<T> item, T value) {
      (item as ISetValue<T>).Value = value;
      return self;
    }
    public static IStateCommitter Commit<T>(this IStateCommitter self, IListState<T> item, UnityAction<IList<T>> f) {
      (item as ICommittableList<T>).Commit(f);
      return self;
    }
    public static IStateCommitter Commit<K, V>(this IStateCommitter self, IDictionaryState<K, V> item, UnityAction<IDictionary<K, V>> f) {
      (item as ICommittableDictionary<K, V>).Commit(f);
      return self;
    }

    // Apply may trigger change event multiple times.
    public static IStateCommitter Apply<T>(this IStateCommitter self, IListState<T> item, UnityAction<IList<T>> f) {
      f.Invoke(item as IList<T>);
      return self;
    }
    public static IStateCommitter Apply<K, V>(this IStateCommitter self, IDictionaryState<K, V> item, UnityAction<IDictionary<K, V>> f) {
      f.Invoke(item as IDictionary<K, V>);
      return self;
    }
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