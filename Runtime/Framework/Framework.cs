using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// The base class for Entry and CBC.
  /// </summary>
  public abstract class UniStartBehaviour<Ctx> : ComposableBehaviour, IReadonlyIoC where Ctx : IIoCC {
    #region Re-expose Fn methods
    // see https://github.com/DiscreteTom/UniStart/issues/5
    // use these for auto type inference
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
    protected abstract Ctx context { get; }
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.context.Get<T>();
    public bool TryGet<T>(out T instance) => this.context.TryGet(out instance);
    #endregion
  }

  public class Entry<Ctx> : UniStartBehaviour<Ctx>, IIoCC where Ctx : class, IIoCC, new() {
    protected override Ctx context { get; } = new();

    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.context.Add(instance);

    /// <summary>
    /// Get the global context in the scene.
    /// Throw an error if the context is not found.
    /// </summary>
    public static Ctx GetContext(GameObject obj) {
      // first, try to find the context in the parent object
      // so that we can have different contexts for different parts of the scene
      var entry = obj.GetComponentInParent<Entry<Ctx>>();
      if (entry != null) return entry.context;

      // second, try to find the context in the root object
      if (obj.transform.root.TryGetComponent(out entry)) {
        return entry.context;
      }

      Debug.LogWarning("Can't find context in the parent or root object!");

      // finally, try to find the context in the whole scene
      entry = FindObjectOfType<Entry<Ctx>>();
      if (entry != null) return entry.context;

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
    }
  }

  /// <summary>
  /// ComposableBehaviour with context injected.
  /// </summary>
  public class CBC : CBC<IoCC> { }
}