using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// The base class for Entry and CBC.
  /// </summary>
  public abstract class UniStartBehaviour<CtxKey, Ctx> : ComposableBehaviour where Ctx : IIoCC<CtxKey> {
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
      watchable.AddOnceListener(wrapper);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(wrapper));
      return wrapper;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0> OnceWatch<T0>(IOnceWatchable<T0> watchable, UnityAction<T0> action) {
      watchable.AddOnceListener(wrapper);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(wrapper));
      return wrapper;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1> OnceWatch<T0, T1>(IOnceWatchable<T0, T1> watchable, UnityAction<T0, T1> action) {
      watchable.AddOnceListener(wrapper);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(wrapper));
      return wrapper;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2> OnceWatch<T0, T1, T2>(IOnceWatchable<T0, T1, T2> watchable, UnityAction<T0, T1, T2> action) {
      watchable.AddOnceListener(wrapper);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(wrapper));
      return wrapper;
    }
    /// <summary>
    /// Watch a watchable for changes once.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2, T3> OnceWatch<T0, T1, T2, T3>(IOnceWatchable<T0, T1, T2, T3> watchable, UnityAction<T0, T1, T2, T3> action) {
      watchable.AddOnceListener(wrapper);
      this.onDestroy.AddOnceListener(() => watchable.RemoveOnceListener(wrapper));
      return wrapper;
    }
    #endregion

    #region Helper Methods for IEventBus
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch<K>(IEventBus<K> eventBus, K key, UnityAction action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddOnceListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0> Watch<K, T0>(IEventBus<K> eventBus, K key, UnityAction<T0> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddOnceListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1> Watch<K, T0, T1>(IEventBus<K> eventBus, K key, UnityAction<T0, T1> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddOnceListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2> Watch<K, T0, T1, T2>(IEventBus<K> eventBus, K key, UnityAction<T0, T1, T2> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddOnceListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2, T3> Watch<K, T0, T1, T2, T3>(IEventBus<K> eventBus, K key, UnityAction<T0, T1, T2, T3> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddOnceListener(() => eventBus.RemoveListener(key, action));
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
    protected abstract IIoCC<CtxKey> context { get; set; }
    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    public T Add<T>(CtxKey key, T instance) => this.context.Add<T>(key, instance);
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.context.Add<T>(instance);
    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    public T Add<T>(CtxKey key) where T : new() => this.context.Add<T>(key);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.context.Add<T>();
    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    public T Get<T>(CtxKey key) => this.context.Get<T>(key);
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.context.Get<T>();
    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>(CtxKey key) => this.context.TryGet<T>(key);
    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>() => this.context.TryGet<T>();
    #endregion
  }

  public class Entry<CtxKey, Ctx> : UniStartBehaviour<CtxKey, Ctx> where Ctx : IIoCC<CtxKey>, new() {
    IIoCC<CtxKey> _context = new Ctx();
    protected override IIoCC<CtxKey> context {
      get { return _context; }
      set { _context = value; }
    }

    public static IIoCC<CtxKey> GetContext(GameObject obj) {
      IIoCC<CtxKey> context = null;
      // first, try to find the context in the root object
      context = obj.transform.root.GetComponent<Entry<CtxKey, Ctx>>()?.context;
      if (context != null) return context;

      // second, try to find the context in the parent object
      context = obj.GetComponentInParent<Entry<CtxKey, Ctx>>()?.context;
      if (context != null) return context;

      // finally, try to find the context in the whole scene
      context = GameObject.FindObjectOfType<Entry<CtxKey, Ctx>>()?.context;
      if (context != null) return context;

      // if we can't find the context, throw an error
      throw new System.Exception("Can't find context in the scene!");
    }

    // show a warning if the user want's to write a Start method
    public void Start() { }
  }

  public class Entry : Entry<object, IoCC> { }

  /// <summary>
  /// ComposableBehaviour with context injected.
  /// </summary>
  public class CBC<CtxKey, Ctx> : UniStartBehaviour<CtxKey, Ctx> where Ctx : IIoCC<CtxKey>, new() {
    // cache the context to avoid searching it every time
    IIoCC<CtxKey> _context = null;
    protected override IIoCC<CtxKey> context {
      get {
        if (this._context == null)
          this._context = Entry<CtxKey, Ctx>.GetContext(this.gameObject);
        return this._context;
      }
      set => this._context = value;
    }
  }

  /// <summary>
  /// ComposableBehaviour with context injected.
  /// </summary>
  public class CBC : CBC<object, IoCC> { }
}