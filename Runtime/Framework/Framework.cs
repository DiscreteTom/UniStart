using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// The base class for Entry and CBC.
  /// </summary>
  public abstract class UniStartBehaviour<Ctx> : ComposableBehaviour, IIoCC where Ctx : IIoCC {
    #region Helper Methods for IWatchable
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch(IWatchable watchable, UnityAction action) {
      watchable.AddListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0> Watch<T0>(IWatchable<T0> watchable, UnityAction<T0> action) {
      watchable.AddListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1> Watch<T0, T1>(IWatchable<T0, T1> watchable, UnityAction<T0, T1> action) {
      watchable.AddListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2> Watch<T0, T1, T2>(IWatchable<T0, T1, T2> watchable, UnityAction<T0, T1, T2> action) {
      watchable.AddListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(IWatchable<T0, T1, T2, T3> watchable, UnityAction<T0, T1, T2, T3> action) {
      watchable.AddListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction OnceWatch(IOnceWatchable watchable, UnityAction action) {
      watchable.AddOnceListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0> OnceWatch<T0>(IOnceWatchable<T0> watchable, UnityAction<T0> action) {
      watchable.AddOnceListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1> OnceWatch<T0, T1>(IOnceWatchable<T0, T1> watchable, UnityAction<T0, T1> action) {
      watchable.AddOnceListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2> OnceWatch<T0, T1, T2>(IOnceWatchable<T0, T1, T2> watchable, UnityAction<T0, T1, T2> action) {
      watchable.AddOnceListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2, T3> OnceWatch<T0, T1, T2, T3>(IOnceWatchable<T0, T1, T2, T3> watchable, UnityAction<T0, T1, T2, T3> action) {
      watchable.AddOnceListener(action);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(action));
      return action;
    }
    #endregion

    #region Helper Methods for IEventListener
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T> Watch<T>(IEventListener eventBus, UnityAction<T> action) {
      eventBus.AddListener(action);
      this.onDestroy.AddOnceListener(() => eventBus.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T> OnceWatch<T>(IEventListener eventBus, UnityAction<T> action) {
      eventBus.AddOnceListener(action);
      this.onDestroy.AddOnceListener(() => eventBus.RemoveOnceListener(action));
      return action;
    }
    #endregion

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
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.context.Add<T>();
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.context.Get<T>();
    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T GetOrDefault<T>() => this.context.GetOrDefault<T>();
    #endregion
  }

  public class Entry<Ctx> : UniStartBehaviour<Ctx> where Ctx : class, IIoCC, new() {
    Ctx _context = new Ctx();
    protected override Ctx context {
      get { return _context; }
      set { _context = value; }
    }

    public static Ctx GetContext(GameObject obj) {
      Ctx context = null;
      // first, try to find the context in the root object
      context = obj.transform.root.GetComponent<Entry<Ctx>>()?.context;
      if (context != null) return context;

      // second, try to find the context in the parent object
      context = obj.GetComponentInParent<Entry<Ctx>>()?.context;
      if (context != null) return context;

      // finally, try to find the context in the whole scene
      context = GameObject.FindObjectOfType<Entry<Ctx>>()?.context;
      if (context != null) return context;

      // if we can't find the context, throw an error
      throw new System.Exception("Can't find context in the scene!");
    }

    // show a warning if the user want's to write a Start method
    protected void Start() { }
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
        if (this._context == null)
          this._context = Entry<Ctx>.GetContext(this.gameObject);
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