using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// Watch a list-like type for changes.
  /// </summary>
  public class WatchIList<L, T> : IList<T>, IReadOnlyList<T>, IGetValue<ReadOnlyCollection<T>>, IWatchable<ReadOnlyCollection<T>> where L : IList<T> {
    protected readonly L value;
    public ReadOnlyCollection<T> Value { get; private set; }
    readonly UniEvent<ReadOnlyCollection<T>> onChange = new();

    public WatchIList(L value) {
      this.value = value;
      this.Value = new ReadOnlyCollection<T>(this.value);
    }
    public WatchIList(L value, T fill) : this(value) {
      this.value.Fill(fill);
    }
    public WatchIList(L value, Func<T> factory) : this(value) {
      this.value.Fill(factory);
    }

    public UnityAction AddListener(UnityAction f) => this.onChange.AddListener(f);
    public UnityAction RemoveListener(UnityAction f) => this.onChange.RemoveListener(f);
    public UnityAction AddOnceListener(UnityAction f) => this.onChange.AddOnceListener(f);
    public UnityAction<ReadOnlyCollection<T>> AddListener(UnityAction<ReadOnlyCollection<T>> f) => this.onChange.AddListener(f);
    public UnityAction<ReadOnlyCollection<T>> RemoveListener(UnityAction<ReadOnlyCollection<T>> f) => this.onChange.RemoveListener(f);
    public UnityAction<ReadOnlyCollection<T>> AddOnceListener(UnityAction<ReadOnlyCollection<T>> f) => this.onChange.AddOnceListener(f);

    public void InvokeEvent() => this.onChange.Invoke(this.Value);

    /// <summary>
    /// Make changes and trigger the onChange event once.
    /// </summary>
    public void Commit(UnityAction<L> f) {
      f.Invoke(this.value);
      this.InvokeEvent();
    }

    /// <summary>
    /// Make changes and trigger the onChange event once.
    /// </summary>
    public R Commit<R>(Func<L, R> f) {
      var result = f.Invoke(this.value);
      this.InvokeEvent();
      return result;
    }

    /// <summary>
    /// Make changes without trigger the onChange event.
    /// </summary>
    public void MutedCommit(UnityAction<L> f) => f.Invoke(this.value);

    /// <summary>
    /// Make changes without trigger the onChange event.
    /// </summary>
    public R MutedCommit<R>(Func<L, R> f) => f.Invoke(this.value);

    #region re-expose methods from the list interface
    // indexers
    public T this[int index] {
      get => this.value[index];
      set => this.Commit(l => l[index] = value);
    }
    // mutable methods
    public void Add(T item) => this.Commit(l => l.Add(item));
    public void Clear() => this.Commit(l => l.Clear());
    public bool Remove(T item) => this.Commit(l => l.Remove(item));
    public void Insert(int index, T item) => this.Commit(l => l.Insert(index, item));
    public void RemoveAt(int index) => this.Commit(l => l.RemoveAt(index));
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
  public class WatchIDictionary<D, K, V> : IDictionary<K, V>, IReadOnlyDictionary<K, V>, IGetValue<ReadOnlyDictionary<K, V>>, IWatchable<ReadOnlyDictionary<K, V>> where D : IDictionary<K, V> {
    protected readonly D value;
    public ReadOnlyDictionary<K, V> Value { get; private set; }
    readonly UniEvent<ReadOnlyDictionary<K, V>> onChange = new();

    public WatchIDictionary(D value) {
      this.value = value;
      this.Value = new ReadOnlyDictionary<K, V>(this.value);
    }

    public UnityAction AddListener(UnityAction f) => this.onChange.AddListener(f);
    public UnityAction RemoveListener(UnityAction f) => this.onChange.RemoveListener(f);
    public UnityAction AddOnceListener(UnityAction f) => this.onChange.AddOnceListener(f);
    public UnityAction<ReadOnlyDictionary<K, V>> AddListener(UnityAction<ReadOnlyDictionary<K, V>> f) => this.onChange.AddListener(f);
    public UnityAction<ReadOnlyDictionary<K, V>> RemoveListener(UnityAction<ReadOnlyDictionary<K, V>> f) => this.onChange.RemoveListener(f);
    public UnityAction<ReadOnlyDictionary<K, V>> AddOnceListener(UnityAction<ReadOnlyDictionary<K, V>> f) => this.onChange.AddOnceListener(f);

    public void InvokeEvent() => this.onChange.Invoke(this.Value);

    /// <summary>
    /// Make changes and trigger the onChange event once.
    /// </summary>
    public void Commit(UnityAction<D> f) {
      f.Invoke(this.value);
      this.InvokeEvent();
    }

    /// <summary>
    /// Make changes and trigger the onChange event once.
    /// </summary>
    public R Commit<R>(Func<D, R> f) {
      var result = f.Invoke(this.value);
      this.InvokeEvent();
      return result;
    }

    /// <summary>
    /// Make changes without trigger the onChange event.
    /// </summary>
    public void MutedCommit(UnityAction<D> f) => f.Invoke(this.value);

    /// <summary>
    /// Make changes without trigger the onChange event.
    /// </summary>
    public R MutedCommit<R>(Func<D, R> f) => f.Invoke(this.value);

    #region re-expose methods from the dictionary interface
    // indexers
    public V this[K key] {
      get => this.value[key];
      set => this.Commit(d => d[key] = value);
    }
    // mutable methods
    public void Add(K key, V value) => this.Commit(d => d.Add(key, value));
    public void Add(KeyValuePair<K, V> item) => this.Commit(d => d.Add(item));
    public void Clear() => this.Commit(d => d.Clear());
    public bool Remove(KeyValuePair<K, V> item) => this.Commit(d => d.Remove(item));
    public bool Remove(K key) => this.Commit(d => d.Remove(key));
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
  public class WatchList<T> : WatchIList<List<T>, T>, IWatchable, IWatchable<ReadOnlyCollection<T>> {
    public WatchList() : base(new()) { }
    public WatchList(int n) : base(new(n)) { }
    public WatchList(List<T> value) : base(value) { }
    public WatchList(int n, T fill) : base(new(n), fill) { }
    public WatchList(int n, Func<T> factory) : base(new(n), factory) { }

    // re-expose methods from the list
    public int BinarySearch(T item) => this.value.BinarySearch(item);
    public int BinarySearch(T item, IComparer<T> comparer) => this.value.BinarySearch(item, comparer);
    public int BinarySearch(int index, int count, T item, IComparer<T> comparer) => this.value.BinarySearch(index, count, item, comparer);
  }

  /// <summary>
  /// Watch an array for changes.
  /// </summary>
  [Serializable]
  public class WatchArray<T> : WatchIList<T[], T>, IWatchable, IWatchable<ReadOnlyCollection<T>> {
    public WatchArray(int n) : base(new T[n]) { }
    public WatchArray(T[] value) : base(value) { }
    public WatchArray(int n, T fill) : base(new T[n], fill) { }
    public WatchArray(int n, Func<T> factory) : base(new T[n], factory) { }

    // re-expose methods from the array
    public int BinarySearch(T item) => Array.BinarySearch(this.value, item);
    public int BinarySearch(T item, IComparer<T> comparer) => Array.BinarySearch(this.value, item, comparer);
    public int BinarySearch(int index, int count, T item, IComparer<T> comparer) => Array.BinarySearch(this.value, index, count, item, comparer);
  }

  /// <summary>
  /// Watch a dictionary for changes.
  /// </summary>
  public class WatchDictionary<K, V> : WatchIDictionary<Dictionary<K, V>, K, V>, IWatchable, IWatchable<ReadOnlyDictionary<K, V>> {
    public WatchDictionary() : base(new()) { }
    public WatchDictionary(Dictionary<K, V> value) : base(value) { }
  }
}