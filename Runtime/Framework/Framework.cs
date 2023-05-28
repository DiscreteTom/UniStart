using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {

  public class Entry<T> : ComposableBehaviour where T : class {
    public T core = null;

    public static T GetCore(GameObject obj) {
      T core = null;
      // first, try to find the core in the root object
      core = obj.transform.root.GetComponent<Entry<T>>()?.core;
      if (core != null) return core;

      // second, try to find the core in the parent object
      core = obj.GetComponentInParent<Entry<T>>()?.core;
      if (core != null) return core;

      // finally, try to find the core in the whole scene
      core = GameObject.FindObjectOfType<Entry<T>>()?.core;
      if (core != null) return core;

      // if we can't find the core, throw an error
      throw new System.Exception("Can't find core in the scene!");
    }

    #region re-expose Fn methods
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
  }

  public class Entry : ComposableBehaviour {
    public IIoCC core { get; private set; } = new IoCC();

    public static IIoCC GetCore(GameObject obj) {
      IIoCC core = null;
      // first, try to find the core in the root object
      core = obj.transform.root.GetComponent<Entry>()?.core;
      if (core != null) return core;

      // second, try to find the core in the parent object
      core = obj.GetComponentInParent<Entry>()?.core;
      if (core != null) return core;

      // finally, try to find the core in the whole scene
      core = GameObject.FindObjectOfType<Entry>()?.core;
      if (core != null) return core;

      // if we can't find the core, throw an error
      throw new System.Exception("Can't find core in the scene!");
    }

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    public T Add<T>(object key, T instance) => this.core.Add<T>(key, instance);
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.core.Add<T>(instance);
    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    public T Add<T>(object key) where T : new() => this.core.Add<T>(key);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.core.Add<T>();
    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    public T Get<T>(object key) => this.core.Get<T>(key);
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.core.Get<T>();
    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>(object key) => this.core.TryGet<T>(key);
    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>() => this.core.TryGet<T>();
    #endregion

    #region re-expose Fn methods
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
  }

  /// <summary>
  /// ComposableBehaviour with core injected.
  /// </summary>
  public class CBC<T> : ComposableBehaviour where T : class {
    // cache the core to avoid searching it every time
    T _core = null;
    protected T core {
      get {
        if (this._core == null)
          this._core = Entry<T>.GetCore(this.gameObject);
        return this._core;
      }
      set => this._core = value;
    }

    #region re-expose Fn methods
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
  }

  /// <summary>
  /// ComposableBehaviour with core injected.
  /// </summary>
  public class CBC : ComposableBehaviour {
    IIoCC _core = null;
    protected IIoCC core {
      get {
        if (this._core == null)
          this._core = Entry.GetCore(this.gameObject);
        return this._core;
      }
      set => this._core = value;
    }

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    public T Add<T>(object key, T instance) => this.core.Add<T>(key, instance);
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.core.Add<T>(instance);
    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    public T Add<T>(object key) where T : new() => this.core.Add<T>(key);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.core.Add<T>();
    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    public T Get<T>(object key) => this.core.Get<T>(key);
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.core.Get<T>();
    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>(object key) => this.core.TryGet<T>(key);
    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>() => this.core.TryGet<T>();
    #endregion

    #region re-expose Fn methods
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
  }
}