using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class StateManager : IStateManager {
    public IStateCommitter Commit<T>(IState<T> item, T value) {
      (item as Watch<T>).Value = value;
      return this;
    }

    public IStateCommitter Commit<T>(IListState<T> item, UnityAction<WatchList<T>> f) {
      f.Invoke(item as WatchList<T>);
      return this;
    }

    public IStateCommitter Commit<T>(IArrayState<T> item, UnityAction<WatchArray<T>> f) {
      f.Invoke(item as WatchArray<T>);
      return this;
    }

    public IStateCommitter Commit<K, V>(IDictionaryState<K, V> item, UnityAction<WatchDictionary<K, V>> f) {
      f.Invoke(item as WatchDictionary<K, V>);
      return this;
    }

    public IStateCommitter Apply<T>(IListState<T> item, UnityAction<List<T>> f) {
      (item as WatchList<T>).Apply(f);
      return this;
    }

    public IStateCommitter Apply<T>(IArrayState<T> item, UnityAction<T[]> f) {
      (item as WatchArray<T>).Apply(f);
      return this;
    }

    public IStateCommitter Apply<K, V>(IDictionaryState<K, V> item, UnityAction<Dictionary<K, V>> f) {
      (item as WatchDictionary<K, V>).Apply(f);
      return this;
    }
  }
}