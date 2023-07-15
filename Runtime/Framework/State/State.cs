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
  }
}