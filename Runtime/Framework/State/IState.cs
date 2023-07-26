using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;

namespace DT.UniStart {
  #region State
  public interface IState<T> : IWatchable, IWatchable<T>, IWatchable<T, T>, IGetValue<T> { }
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

  #region StateManager
  public interface IStateManager { }

  public static class IStateManagerExtension {
    public static IState<T> Add<T>(this IStateManager manager, T value) => new Watch<T>(value);
    public static IListState<T> AddArray<T>(this IStateManager manager, int count) => new WatchArray<T>(count);
    public static IListState<T> AddArray<T>(this IStateManager manager, T[] value) => new WatchArray<T>(value);
    public static IListState<T> AddList<T>(this IStateManager manager) => new WatchList<T>();
    public static IListState<T> AddList<T>(this IStateManager manager, List<T> value) => new WatchList<T>(value);
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager manager) => new WatchDictionary<K, V>();
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager manager, Dictionary<K, V> value) => new WatchDictionary<K, V>(value);
    public static IState<T> Add<T>(this IStateManager manager, out Watch<T> echoed, T value) {
      var state = new Watch<T>(value);
      echoed = state;
      return state;
    }
    public static IListState<T> AddArray<T>(this IStateManager manager, out WatchArray<T> echoed, int count) {
      var state = new WatchArray<T>(count);
      echoed = state;
      return state;
    }
    public static IListState<T> AddArray<T>(this IStateManager manager, out WatchArray<T> echoed, T[] value) {
      var state = new WatchArray<T>(value);
      echoed = state;
      return state;
    }
    public static IListState<T> AddList<T>(this IStateManager manager, out WatchList<T> echoed) {
      var state = new WatchList<T>();
      echoed = state;
      return state;
    }
    public static IListState<T> AddList<T>(this IStateManager manager, out WatchList<T> echoed, List<T> value) {
      var state = new WatchList<T>(value);
      echoed = state;
      return state;
    }
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager manager, out WatchDictionary<K, V> echoed) {
      var state = new WatchDictionary<K, V>();
      echoed = state;
      return state;
    }
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager manager, out WatchDictionary<K, V> echoed, Dictionary<K, V> value) {
      var state = new WatchDictionary<K, V>(value);
      echoed = state;
      return state;
    }
    #region Reversed
    public static IState<T> Add<T>(this IStateManager manager, T value, out Watch<T> echoed) => manager.Add(out echoed, value);
    public static IListState<T> AddArray<T>(this IStateManager manager, int count, out WatchArray<T> echoed) => manager.AddArray(out echoed, count);
    public static IListState<T> AddArray<T>(this IStateManager manager, T[] value, out WatchArray<T> echoed) => manager.AddArray(out echoed, value);
    public static IListState<T> AddList<T>(this IStateManager manager, List<T> value, out WatchList<T> echoed) => manager.AddList(out echoed, value);
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager manager, Dictionary<K, V> value, out WatchDictionary<K, V> echoed) => manager.AddDictionary(out echoed, value);
    #endregion
  }
  #endregion
}