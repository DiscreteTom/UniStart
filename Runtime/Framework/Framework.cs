using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// The base class for Entry and CBC.
  /// </summary>
  public abstract class UniStartBehaviour<Ctx> : ComposableBehaviour, IIoCC where Ctx : IIoCC {
    #region Re-expose Fn methods
    public static UnityAction Fn(UnityAction action) => action;
    public static UnityAction<T0> Fn<T0>(UnityAction<T0> action) => action;
    public static UnityAction<T0, T1> Fn<T0, T1>(UnityAction<T0, T1> action) => action;
    public static UnityAction<T0, T1, T2> Fn<T0, T1, T2>(UnityAction<T0, T1, T2> action) => action;
    public static UnityAction<T0, T1, T2, T3> Fn<T0, T1, T2, T3>(UnityAction<T0, T1, T2, T3> action) => action;
    public static Func<R> Fn<R>(Func<R> f) => f;
    public static Func<T0, R> Fn<T0, R>(Func<T0, R> f) => f;
    public static Func<T0, T1, R> Fn<T0, T1, R>(Func<T0, T1, R> f) => f;
    public static Func<T0, T1, T2, R> Fn<T0, T1, T2, R>(Func<T0, T1, T2, R> f) => f;
    public static Func<T0, T1, T2, T3, R> Fn<T0, T1, T2, T3, R>(Func<T0, T1, T2, T3, R> f) => f;
    #endregion

    #region Context Management
    protected abstract Ctx context { get; set; }
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.context.Add<T>(instance);
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.context.Get<T>();
    public bool TryGet<T>(out T instance) => this.context.TryGet<T>(out instance);
    #endregion
  }

  public class Entry<Ctx> : UniStartBehaviour<Ctx> where Ctx : class, IIoCC, new() {
    Ctx _context = new();
    protected override Ctx context {
      get => _context;
      set { _context = value; }
    }

    // helper method to get the context from an entry
    // this is because unity object should not be used with `?.`.
    static Ctx GetContextSafe(Entry<Ctx> entry) => entry == null ? null : entry.context;

    public static Ctx GetContext(GameObject obj) {
      Ctx context;
      // first, try to find the context in the root object
      context = GetContextSafe(obj.transform.root.GetComponent<Entry<Ctx>>());
      if (context != null) return context;

      // second, try to find the context in the parent object
      context = GetContextSafe(obj.GetComponentInParent<Entry<Ctx>>());
      if (context != null) return context;

      // finally, try to find the context in the whole scene
      context = GetContextSafe(FindObjectOfType<Entry<Ctx>>());
      if (context != null) return context;

      // if we can't find the context, throw an error
      throw new Exception("Can't find context in the scene!");
    }

#pragma warning disable UNT0001
    // show a warning if the user want's to write a Start method
    protected void Start() { }
#pragma warning restore UNT0001
  }

  public class Entry : Entry<IoCC> { }

  /// <summary>
  /// ComposableBehaviour with context injected.
  /// </summary>
  public class CBC<Ctx> : UniStartBehaviour<Ctx> where Ctx : class, IIoCC, new() {
    // cache the context to avoid searching it every time
    Ctx _context = null;
    protected override Ctx context {
      get {
        this._context ??= Entry<Ctx>.GetContext(this.gameObject);
        return this._context;
      }
      set => this._context = value;
    }
  }

  /// <summary>
  /// ComposableBehaviour with context injected.
  /// </summary>
  public class CBC : CBC<IoCC> { }
}