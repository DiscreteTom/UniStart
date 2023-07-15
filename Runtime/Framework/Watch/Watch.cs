using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// Watch a **value** type for changes.
  /// This class should be used for immutable types (int, float, bool, string, etc) only.
  /// </summary>
  [Serializable]
  public class Watch<T> : IWatchable, IWatchable<T>, IWatchable<T, T> {
    [SerializeField] protected T value;
    AdvancedEvent<T> onChange1;
    AdvancedEvent<T, T> onChange2;

    public Watch(T value) {
      this.value = value;
      this.onChange1 = new AdvancedEvent<T>();
      this.onChange2 = new AdvancedEvent<T, T>();
    }

    public T Value {
      get => this.value;
      set {
        var previous = this.value;
        this.value = value;
        this.onChange1.Invoke(value);
        this.onChange2.Invoke(value, previous);
      }
    }

    /// <summary>
    /// Add a listener that will be called when the value changes.
    /// </summary>
    public UnityAction AddListener(UnityAction f) => this.onChange1.AddListener(f);
    public UnityAction AddOnceListener(UnityAction f) => this.onChange1.AddOnceListener(f);
    public UnityAction RemoveListener(UnityAction f) => this.onChange1.RemoveListener(f);
    /// <summary>
    /// Add a listener that will be called when the value changes.
    /// The parameter is the new value.
    /// </summary>
    public UnityAction<T> AddListener(UnityAction<T> f) => this.onChange1.AddListener(f);
    public UnityAction<T> AddOnceListener(UnityAction<T> f) => this.onChange1.AddOnceListener(f);
    public UnityAction<T> RemoveListener(UnityAction<T> f) => this.onChange1.RemoveListener(f);
    /// <summary>
    /// Add a listener that will be called when the value changes.
    /// The parameter is the new value and the previous value.
    /// </summary>
    public UnityAction<T, T> AddListener(UnityAction<T, T> f) => this.onChange2.AddListener(f);
    public UnityAction<T, T> AddOnceListener(UnityAction<T, T> f) => this.onChange2.AddOnceListener(f);
    public UnityAction<T, T> RemoveListener(UnityAction<T, T> f) => this.onChange2.RemoveListener(f);
  }

  /// <summary>
  /// Watch a **reference** type for changes.
  /// </summary>
  [Serializable]
  public class WatchRef<T> : IWatchable, IWatchable<WatchRef<T>> {
    [SerializeField] protected T value;
    AdvancedEvent<WatchRef<T>> onChange;

    public WatchRef(T value) {
      this.value = value;
      this.onChange = new AdvancedEvent<WatchRef<T>>();
    }

    /// <summary>
    /// Set the value and trigger the onChange event.
    /// </summary>
    public void SetValue(T value) {
      this.value = value;
      this.InvokeEvent();
    }

    /// <summary>
    /// Apply a function to the value and trigger the onChange event.
    /// </summary>
    public void Apply(UnityAction<T> f) {
      f(this.value);
      this.InvokeEvent();
    }

    /// <summary>
    /// Apply a function to the value and trigger the onChange event.
    /// </summary>
    public R Apply<R>(Func<T, R> f) {
      var result = f(this.value);
      this.InvokeEvent();
      return result;
    }

    /// <summary>
    /// Apply a function to the value without trigger the onChange event.
    /// </summary>
    public void ReadOnlyApply(UnityAction<T> f) => f(this.value);

    /// <summary>
    /// Apply a function to the value without trigger the onChange event.
    /// </summary>
    public R ReadOnlyApply<R>(Func<T, R> f) => f(this.value);

    /// <summary>
    /// Add a listener that will be called when the value changes.
    /// </summary>
    public UnityAction<WatchRef<T>> AddListener(UnityAction<WatchRef<T>> f) => this.onChange.AddListener(f);
    public UnityAction<WatchRef<T>> AddOnceListener(UnityAction<WatchRef<T>> f) => this.onChange.AddOnceListener(f);
    public UnityAction<WatchRef<T>> RemoveListener(UnityAction<WatchRef<T>> f) => this.onChange.RemoveListener(f);
    /// <summary>
    /// Add a listener that will be called when the value changes.
    /// </summary>
    public UnityAction AddListener(UnityAction f) => this.onChange.AddListener(f);
    public UnityAction AddOnceListener(UnityAction f) => this.onChange.AddOnceListener(f);
    public UnityAction RemoveListener(UnityAction f) => this.onChange.RemoveListener(f);

    /// <summary>
    /// Invoke all events.
    /// </summary>
    protected void InvokeEvent() => this.onChange.Invoke(this);
  }

  /// <summary>
  /// Immediately calculate a value when a watchable changes.
  /// The result should be immutable.
  /// </summary>
  [Serializable]
  public class Computed<T> : Watch<T>, IWatchable, IWatchable<T>, IWatchable<T, T> {
    Func<T> compute;

    // use new Value to block write access
    public new T Value {
      get => this.value;
    }

    public Computed(Func<T> compute) : base(compute()) {
      this.compute = compute;
      this.value = this.compute.Invoke();
    }

    /// <summary>
    /// Compute the value when a watchable changes.
    /// </summary>
    public Computed<T> Watch(IWatchable target) {
      target.AddListener(this.Update);
      return this;
    }

    public Computed<T> UnWatch(IWatchable target) {
      target.RemoveListener(this.Update);
      return this;
    }

    // use parent class's value setter to trigger events
    void Update() => base.Value = this.compute();
  }

  /// <summary>
  /// Auto calculate a value when the value is used after a watchable changes.
  /// The result should be immutable.
  /// </summary>
  [Serializable]
  public class LazyComputed<T> {
    [SerializeField] T value;
    [SerializeField] bool needUpdate = true;
    Func<T> compute { get; set; }

    public T Value {
      get {
        if (this.needUpdate) {
          this.value = this.compute.Invoke();
          this.needUpdate = false;
        }
        return this.value;
      }
    }

    public LazyComputed(Func<T> compute) {
      this.compute = compute;
      this.needUpdate = true;
    }

    /// <summary>
    /// Mark current value as dirty when a watchable changes.
    /// </summary>
    public LazyComputed<T> Watch(IWatchable target) {
      target.AddListener(this.Update);
      return this;
    }

    void Update() => this.needUpdate = true;
  }
}