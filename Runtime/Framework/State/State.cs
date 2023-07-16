using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class StateManager : IStateManager {
    public IStateCommitter Commit<T>(IState<T> item, T value) {
      (item as ISetValue<T>).Value = value;
      return this;
    }

    public IStateCommitter Commit<T>(IListState<T> item, UnityAction<IList<T>> f) {
      f.Invoke(item as IList<T>);
      return this;
    }

    public IStateCommitter Commit<K, V>(IDictionaryState<K, V> item, UnityAction<IDictionary<K, V>> f) {
      f.Invoke(item as IDictionary<K, V>);
      return this;
    }

    public IStateCommitter Apply<T>(IListState<T> item, UnityAction<IList<T>> f) {
      (item as IListApply<T>).Apply(f);
      return this;
    }

    public IStateCommitter Apply<K, V>(IDictionaryState<K, V> item, UnityAction<IDictionary<K, V>> f) {
      (item as IDictionaryApply<K, V>).Apply(f);
      return this;
    }
  }
}