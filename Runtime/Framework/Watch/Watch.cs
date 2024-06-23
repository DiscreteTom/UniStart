using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// Watch a **value** type for changes.
  /// This class should be used for immutable types (int, float, bool, string, etc) only.
  /// </summary>
  [Serializable]
  public class Watch<T> : IWatchable<T, T>, IGetSetValue<T>, IValueState<T> {
    [SerializeField] protected T value;
    readonly AdvancedEvent<T, T> onChange = new();

    public Watch(T value) {
      this.value = value;
    }

    public T Value {
      get => this.value;
      set {
        var previous = this.value;
        this.value = value;
        this.InvokeEvent(previous);
      }
    }

    public virtual UnityAction AddListener(UnityAction f) => this.onChange.AddListener(f);
    public virtual UnityAction RemoveListener(UnityAction f) => this.onChange.RemoveListener(f);
    public virtual UnityAction AddOnceListener(UnityAction f) => this.onChange.AddOnceListener(f);
    public virtual UnityAction<T> AddListener(UnityAction<T> f) => this.onChange.AddListener(f);
    public virtual UnityAction<T> RemoveListener(UnityAction<T> f) => this.onChange.RemoveListener(f);
    public virtual UnityAction<T> AddOnceListener(UnityAction<T> f) => this.onChange.AddOnceListener(f);
    public virtual UnityAction<T, T> AddListener(UnityAction<T, T> f) => this.onChange.AddListener(f);
    public virtual UnityAction<T, T> RemoveListener(UnityAction<T, T> f) => this.onChange.RemoveListener(f);
    public virtual UnityAction<T, T> AddOnceListener(UnityAction<T, T> f) => this.onChange.AddOnceListener(f);

    protected virtual void InvokeEvent(T previous) => this.onChange.Invoke(this.value, previous);
  }

  /// <summary>
  /// Watch a **reference** type for changes.
  /// </summary>
  [Serializable]
  public class WatchRef<T> : IWatchable<WatchRef<T>>, ISetValue<T> {
    [SerializeField] protected T value;
    readonly AdvancedEvent<WatchRef<T>> onChange = new();

    public WatchRef(T value) {
      this.value = value;
    }

    public T Value {
      set {
        this.value = value;
        this.InvokeEvent();
      }
    }

    /// <summary>
    /// Make changes and trigger the onChange event once.
    /// </summary>
    public void Commit(UnityAction<T> f) {
      f.Invoke(this.value);
      this.InvokeEvent();
    }

    /// <summary>
    /// Make changes and trigger the onChange event once.
    /// </summary>
    public R Commit<R>(Func<T, R> f) {
      var result = f.Invoke(this.value);
      this.InvokeEvent();
      return result;
    }

    /// <summary>
    /// Make changes without trigger the onChange event.
    /// </summary>
    public void MutedCommit(UnityAction<T> f) => f.Invoke(this.value);

    /// <summary>
    /// Make changes without trigger the onChange event.
    /// </summary>
    public R MutedCommit<R>(Func<T, R> f) => f.Invoke(this.value);

    public UnityAction AddListener(UnityAction f) => this.onChange.AddListener(f);
    public UnityAction RemoveListener(UnityAction f) => this.onChange.RemoveListener(f);
    public UnityAction AddOnceListener(UnityAction f) => this.onChange.AddOnceListener(f);
    public UnityAction<WatchRef<T>> AddListener(UnityAction<WatchRef<T>> f) => this.onChange.AddListener(f);
    public UnityAction<WatchRef<T>> RemoveListener(UnityAction<WatchRef<T>> f) => this.onChange.RemoveListener(f);
    public UnityAction<WatchRef<T>> AddOnceListener(UnityAction<WatchRef<T>> f) => this.onChange.AddOnceListener(f);

    /// <summary>
    /// Invoke all events.
    /// </summary>
    public virtual void InvokeEvent() => this.onChange.Invoke(this);
  }

  /// <summary>
  /// Immediately calculate a value when a watchable changes.
  /// The result should be immutable.
  /// </summary>
  [Serializable]
  public class Computed<T> : IWatchable<T, T>, IGetValue<T>, IValueState<T> {
    readonly Func<T> compute;
    readonly Watch<T> value;

    public T Value {
      get => this.value.Value;
    }

    public Computed(Func<T> compute) {
      this.compute = compute;
      this.value = new Watch<T>(this.compute.Invoke());
    }

    public Computed<T> Watch(IWatchable target) {
      target.AddListener(this.Update);
      return this;
    }

    public Computed<T> UnWatch(IWatchable target) {
      target.RemoveListener(this.Update);
      return this;
    }

    // trigger value's events
    void Update() => this.value.Value = this.compute();

    public UnityAction AddListener(UnityAction f) => this.value.AddListener(f);
    public UnityAction RemoveListener(UnityAction f) => this.value.RemoveListener(f);
    public UnityAction AddOnceListener(UnityAction f) => this.value.AddOnceListener(f);
    public UnityAction<T> AddListener(UnityAction<T> f) => this.value.AddListener(f);
    public UnityAction<T> RemoveListener(UnityAction<T> f) => this.value.RemoveListener(f);
    public UnityAction<T> AddOnceListener(UnityAction<T> f) => this.value.AddOnceListener(f);
    public UnityAction<T, T> AddListener(UnityAction<T, T> f) => this.value.AddListener(f);
    public UnityAction<T, T> RemoveListener(UnityAction<T, T> f) => this.value.RemoveListener(f);
    public UnityAction<T, T> AddOnceListener(UnityAction<T, T> f) => this.value.AddOnceListener(f);
  }

  /// <summary>
  /// Auto calculate a value when the value is used after a watchable changes.
  /// The result should be immutable.
  /// </summary>
  [Serializable]
  public class LazyComputed<T> : IGetValue<T> {
    [SerializeField] T value;
    [SerializeField] bool dirty = true;
    Func<T> compute { get; set; }

    public T Value {
      get {
        if (this.dirty) {
          this.value = this.compute.Invoke();
          this.dirty = false;
        }
        return this.value;
      }
    }

    public LazyComputed(Func<T> compute) {
      this.compute = compute;
    }

    /// <summary>
    /// Mark current value as dirty when a watchable changes.
    /// </summary>
    public LazyComputed<T> Watch(IWatchable target) {
      target.AddListener(this.Update);
      return this;
    }

    public LazyComputed<T> UnWatch(IWatchable target) {
      target.RemoveListener(this.Update);
      return this;
    }

    void Update() => this.dirty = true;
  }
}