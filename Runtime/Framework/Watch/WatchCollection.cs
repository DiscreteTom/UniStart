using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// Watch a list-like type for changes.
  /// </summary>
  public class WatchIList<L, T> : WatchRef<L>, IList<T>, IReadOnlyList<T>, IWatchable, IWatchable<ReadOnlyCollection<T>>, IGetValue<ReadOnlyCollection<T>>, IListApply<T> where L : IList<T> {
    ReadOnlyCollection<T> readOnlyList;
    AdvancedEvent<ReadOnlyCollection<T>> onChange;

    public WatchIList(L value) : base(value) {
      this.readOnlyList = new ReadOnlyCollection<T>(this.value);
      this.onChange = new AdvancedEvent<ReadOnlyCollection<T>>();
    }

    /// <summary>
    /// Get the list as a read-only list and cache it for future calls.
    /// </summary>
    public ReadOnlyCollection<T> Value => this.readOnlyList;

    public UnityAction<ReadOnlyCollection<T>> AddListener(UnityAction<ReadOnlyCollection<T>> f) => this.onChange.AddListener(f);
    public UnityAction<ReadOnlyCollection<T>> AddOnceListener(UnityAction<ReadOnlyCollection<T>> f) => this.onChange.AddOnceListener(f);
    public UnityAction<ReadOnlyCollection<T>> RemoveListener(UnityAction<ReadOnlyCollection<T>> f) => this.onChange.RemoveListener(f);

    public override void InvokeEvent() {
      base.InvokeEvent();
      this.onChange.Invoke(this.Value);
    }

    // IListApply
    public void Apply(UnityAction<IList<T>> f) => base.Apply((v) => f.Invoke(v));

    #region re-expose methods from the list interface
    public void Add(T item) {
      this.value.Add(item);
      this.InvokeEvent();
    }
    public void Clear() {
      this.value.Clear();
      this.InvokeEvent();
    }
    public bool Remove(T item) {
      var result = this.value.Remove(item);
      this.InvokeEvent();
      return result;
    }
    public T this[int index] {
      get => this.value[index];
      set {
        this.value[index] = value;
        this.InvokeEvent();
      }
    }
    public void Insert(int index, T item) {
      this.value.Insert(index, item);
      this.InvokeEvent();
    }
    public void RemoveAt(int index) {
      this.value.RemoveAt(index);
      this.InvokeEvent();
    }

    // readonly properties & methods
    public bool Contains(T item) => this.value.Contains(item);
    public int IndexOf(T item) => this.value.IndexOf(item);
    public void CopyTo(T[] array, int arrayIndex) => this.value.CopyTo(array, arrayIndex);
    public IEnumerator<T> GetEnumerator() => this.value.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.value.GetEnumerator();
    public int Count => this.value.Count;
    public bool IsReadOnly => this.value.IsReadOnly;
    #endregion
  }

  /// <summary>
  /// Watch a dictionary-like type for changes.
  /// </summary>
  public class WatchIDictionary<D, K, V> : WatchRef<D>, IDictionary<K, V>, IReadOnlyDictionary<K, V>, IWatchable, IWatchable<ReadOnlyDictionary<K, V>>, IGetValue<ReadOnlyDictionary<K, V>>, IDictionaryState<K, V>, IDictionaryApply<K, V> where D : IDictionary<K, V> {
    ReadOnlyDictionary<K, V> readOnlyDictionary;
    AdvancedEvent<ReadOnlyDictionary<K, V>> onChange;

    public WatchIDictionary(D value) : base(value) {
      this.readOnlyDictionary = new ReadOnlyDictionary<K, V>(this.value);
      this.onChange = new AdvancedEvent<ReadOnlyDictionary<K, V>>();
    }

    /// <summary>
    /// Get the dictionary as a read-only dictionary and cache it for future calls.
    /// </summary>
    public ReadOnlyDictionary<K, V> Value => this.readOnlyDictionary;

    public UnityAction<ReadOnlyDictionary<K, V>> AddListener(UnityAction<ReadOnlyDictionary<K, V>> f) => this.onChange.AddListener(f);
    public UnityAction<ReadOnlyDictionary<K, V>> AddOnceListener(UnityAction<ReadOnlyDictionary<K, V>> f) => this.onChange.AddOnceListener(f);
    public UnityAction<ReadOnlyDictionary<K, V>> RemoveListener(UnityAction<ReadOnlyDictionary<K, V>> f) => this.onChange.RemoveListener(f);

    public override void InvokeEvent() {
      base.InvokeEvent();
      this.onChange.Invoke(this.Value);
    }

    // IDictionaryApply
    public void Apply(UnityAction<IDictionary<K, V>> f) => base.Apply((v) => f.Invoke(v));

    #region re-expose methods from the dictionary interface
    public void Add(K key, V value) {
      this.value.Add(key, value);
      this.InvokeEvent();
    }
    public void Add(KeyValuePair<K, V> item) {
      this.value.Add(item);
      this.InvokeEvent();
    }
    public void Clear() {
      this.value.Clear();
      this.InvokeEvent();
    }
    public bool Remove(KeyValuePair<K, V> item) {
      var result = this.value.Remove(item);
      this.InvokeEvent();
      return result;
    }
    public bool Remove(K key) {
      var result = this.value.Remove(key);
      this.InvokeEvent();
      return result;
    }
    public V this[K key] {
      get => this.value[key];
      set {
        this.value[key] = value;
        this.InvokeEvent();
      }
    }

    // readonly properties & methods
    public int Count => this.value.Count;
    public bool TryGetValue(K key, out V value) => this.value.TryGetValue(key, out value);
    public bool ContainsKey(K key) => this.value.ContainsKey(key);
    public bool Contains(KeyValuePair<K, V> item) => this.value.Contains(item);
    public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex) => this.value.CopyTo(array, arrayIndex);
    public IEnumerator<KeyValuePair<K, V>> GetEnumerator() => this.value.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.value.GetEnumerator();
    public ICollection<K> Keys => this.value.Keys;
    public ICollection<V> Values => this.value.Values;
    IEnumerable<K> IReadOnlyDictionary<K, V>.Keys { get; }
    IEnumerable<V> IReadOnlyDictionary<K, V>.Values { get; }
    public bool IsReadOnly => this.value.IsReadOnly;
    #endregion
  }

  /// <summary>
  /// Watch a list for changes.
  /// </summary>
  [Serializable]
  public class WatchList<T> : WatchIList<List<T>, T>, IWatchable, IWatchable<ReadOnlyCollection<T>>, IListState<T> {
    public WatchList() : base(new List<T>()) { }
    public WatchList(List<T> value) : base(value) { }

    // re-expose methods from the list
    public int BinarySearch(T item) => this.value.BinarySearch(item);
    public int BinarySearch(T item, IComparer<T> comparer) => this.value.BinarySearch(item, comparer);
    public int BinarySearch(int index, int count, T item, IComparer<T> comparer) => this.value.BinarySearch(index, count, item, comparer);
  }

  /// <summary>
  /// Watch an array for changes.
  /// </summary>
  [Serializable]
  public class WatchArray<T> : WatchIList<T[], T>, IWatchable, IWatchable<ReadOnlyCollection<T>>, IListState<T> {
    public WatchArray(int n) : base(new T[n]) { }
    public WatchArray(T[] value) : base(value) { }

    // re-expose methods from the array
    public int BinarySearch(T item) => Array.BinarySearch(this.value, item);
    public int BinarySearch(T item, IComparer<T> comparer) => Array.BinarySearch(this.value, item, comparer);
    public int BinarySearch(int index, int count, T item, IComparer<T> comparer) => Array.BinarySearch(this.value, index, count, item, comparer);
  }

  /// <summary>
  /// Watch a dictionary for changes.
  /// </summary>
  public class WatchDictionary<K, V> : WatchIDictionary<Dictionary<K, V>, K, V>, IWatchable, IWatchable<ReadOnlyDictionary<K, V>>, IDictionaryState<K, V> {
    public WatchDictionary() : base(new Dictionary<K, V>()) { }
    public WatchDictionary(Dictionary<K, V> value) : base(value) { }
  }
}