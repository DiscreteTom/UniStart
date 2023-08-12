using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;

namespace DT.UniStart {
  #region State
  public interface IState<T> : IWatchable<T, T>, IGetValue<T> { }
  public interface IEnumState<T> : IReadonlyStateMachine<T> where T : Enum { }
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
    public static IEnumState<T> AddEnum<T>(this IStateManager manager, T value) where T : Enum => new StateMachine<T>(value);
    public static IListState<T> AddArray<T>(this IStateManager manager, int count) => new WatchArray<T>(count);
    public static IListState<T> AddArray<T>(this IStateManager manager, int count, T fill) {
      var array = new WatchArray<T>(count);
      array.Fill(fill);
      return array;
    }
    public static IListState<T> AddArray<T>(this IStateManager manager, T[] value) => new WatchArray<T>(value);
    public static IListState<T> AddList<T>(this IStateManager manager) => new WatchList<T>();
    public static IListState<T> AddList<T>(this IStateManager manager, int count, T fill) {
      var list = new WatchList<T>();
      for (var i = 0; i < count; i++) {
        list.Add(fill);
      }
      return list;
    }
    public static IListState<T> AddList<T>(this IStateManager manager, List<T> value) => new WatchList<T>(value);
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager manager) => new WatchDictionary<K, V>();
    public static IDictionaryState<K, V> AddDictionary<K, V>(this IStateManager manager, Dictionary<K, V> value) => new WatchDictionary<K, V>(value);

    #region Echoed
    public static IState<T> Add<T>(this IStateManager manager, out Watch<T> echoed, T value) {
      var state = new Watch<T>(value);
      echoed = state;
      return state;
    }
    public static IEnumState<T> AddEnum<T>(this IStateManager manager, out StateMachine<T> echoed, T value) where T : Enum {
      var state = new StateMachine<T>(value);
      echoed = state;
      return state;
    }
    public static IListState<T> AddArray<T>(this IStateManager manager, out WatchArray<T> echoed, int count) {
      var state = new WatchArray<T>(count);
      echoed = state;
      return state;
    }
    public static IListState<T> AddArray<T>(this IStateManager manager, out WatchArray<T> echoed, int count, T fill) {
      var state = new WatchArray<T>(count);
      state.Fill(fill);
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
    public static IListState<T> AddList<T>(this IStateManager manager, out WatchList<T> echoed, int count, T fill) {
      var state = new WatchList<T>();
      for (var i = 0; i < count; i++) {
        state.Add(fill);
      }
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
    #endregion

    #region Const Array
    public static IReadOnlyList<T> AddConstArray<T>(this IStateManager manager, int count) {
      return new T[count];
    }
    public static IReadOnlyList<T> AddConstArray<T>(this IStateManager manager, int count, T fill) {
      var res = new T[count];
      res.Fill(fill);
      return res;
    }
    public static IReadOnlyList<T> AddConstArray<T>(this IStateManager manager, out T[] echoed, int count) {
      echoed = new T[count];
      return echoed;
    }
    public static IReadOnlyList<T> AddConstArray<T>(this IStateManager manager, out T[] echoed, int count, T fill) {
      echoed = new T[count];
      echoed.Fill(fill);
      return echoed;
    }
    public static IReadOnlyDictionary<K, V> AddConstDictionary<K, V>(this IStateManager manager) {
      return new Dictionary<K, V>();
    }
    public static IReadOnlyDictionary<K, V> AddConstDictionary<K, V>(this IStateManager manager, out Dictionary<K, V> echoed) {
      echoed = new();
      return echoed;
    }
    public static IReadOnlyList<IState<T>> AddStateArray<T>(this IStateManager manager, int count, T fill = default) {
      var res = new Watch<T>[count];
      res.Fill(new Watch<T>(fill));
      return res;
    }
    public static IReadOnlyList<IState<T>> AddStateArray<T>(this IStateManager manager, out Watch<T>[] echoed, int count, T fill = default) {
      echoed = new Watch<T>[count];
      echoed.Fill(new Watch<T>(fill));
      return echoed;
    }
    public static IReadOnlyList<IEnumState<T>> AddEnumArray<T>(this IStateManager manager, int count, T fill = default) where T : Enum {
      var res = new StateMachine<T>[count];
      res.Fill(new StateMachine<T>(default));
      return res;
    }
    public static IReadOnlyList<IEnumState<T>> AddEnumArray<T>(this IStateManager manager, out StateMachine<T>[] echoed, int count, T fill = default) where T : Enum {
      echoed = new StateMachine<T>[count];
      echoed.Fill(new StateMachine<T>(fill));
      return echoed;
    }
    #endregion
  }
  #endregion
}