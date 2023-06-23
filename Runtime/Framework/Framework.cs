using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// The base class for Entry and CBC.
  /// </summary>
  public class UniStartBehaviour : ComposableBehaviour {
    #region Helper Methods for IWatchable
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch(IWatchable watchable, UnityAction action) {
      watchable.AddListener(action);
      this.onDestroy.AddListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0> Watch<T0>(IWatchable<T0> watchable, UnityAction<T0> action) {
      watchable.AddListener(action);
      this.onDestroy.AddListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1> Watch<T0, T1>(IWatchable<T0, T1> watchable, UnityAction<T0, T1> action) {
      watchable.AddListener(action);
      this.onDestroy.AddListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2> Watch<T0, T1, T2>(IWatchable<T0, T1, T2> watchable, UnityAction<T0, T1, T2> action) {
      watchable.AddListener(action);
      this.onDestroy.AddListener(() => watchable.RemoveListener(action));
      return action;
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(IWatchable<T0, T1, T2, T3> watchable, UnityAction<T0, T1, T2, T3> action) {
      watchable.AddListener(action);
      this.onDestroy.AddListener(() => watchable.RemoveListener(action));
      return action;
    }
    #endregion

    #region Helper Methods for IEventBus
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch<K>(IEventBus<K> eventBus, K key, UnityAction action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0> Watch<K, T0>(IEventBus<K> eventBus, K key, UnityAction<T0> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1> Watch<K, T0, T1>(IEventBus<K> eventBus, K key, UnityAction<T0, T1> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2> Watch<K, T0, T1, T2>(IEventBus<K> eventBus, K key, UnityAction<T0, T1, T2> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
    /// <summary>
    /// Watch an event bus for events.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction<T0, T1, T2, T3> Watch<K, T0, T1, T2, T3>(IEventBus<K> eventBus, K key, UnityAction<T0, T1, T2, T3> action) {
      eventBus.AddListener(key, action);
      this.onDestroy.AddListener(() => eventBus.RemoveListener(key, action));
      return action;
    }
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

  public class Entry<T> : UniStartBehaviour where T : class {
    public T context = null;

    // TODO: add generic GetContext<T> method?
    public static T GetContext(GameObject obj) {
      T context = null;
      // first, try to find the context in the root object
      context = obj.transform.root.GetComponent<Entry<T>>()?.context;
      if (context != null) return context;

      // second, try to find the context in the parent object
      context = obj.GetComponentInParent<Entry<T>>()?.context;
      if (context != null) return context;

      // finally, try to find the context in the whole scene
      context = GameObject.FindObjectOfType<Entry<T>>()?.context;
      if (context != null) return context;

      // if we can't find the context, throw an error
      throw new System.Exception("Can't find context in the scene!");
    }
  }

  public class Entry : UniStartBehaviour {
    public IIoCC context { get; private set; } = new IoCC();

    public static IIoCC GetContext(GameObject obj) {
      IIoCC context = null;
      // first, try to find the context in the root object
      context = obj.transform.root.GetComponent<Entry>()?.context;
      if (context != null) return context;

      // second, try to find the context in the parent object
      context = obj.GetComponentInParent<Entry>()?.context;
      if (context != null) return context;

      // finally, try to find the context in the whole scene
      context = GameObject.FindObjectOfType<Entry>()?.context;
      if (context != null) return context;

      // if we can't find the context, throw an error
      throw new System.Exception("Can't find context in the scene!");
    }

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    public T Add<T>(object key, T instance) => this.context.Add<T>(key, instance);
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.context.Add<T>(instance);
    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    public T Add<T>(object key) where T : new() => this.context.Add<T>(key);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.context.Add<T>();
    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    public T Get<T>(object key) => this.context.Get<T>(key);
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.context.Get<T>();
    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>(object key) => this.context.TryGet<T>(key);
    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>() => this.context.TryGet<T>();
    #endregion
  }

  /// <summary>
  /// ComposableBehaviour with context injected.
  /// </summary>
  public class CBC<T> : UniStartBehaviour where T : class {
    // cache the context to avoid searching it every time
    T _context = null;
    protected T context {
      get {
        if (this._context == null)
          this._context = Entry<T>.GetContext(this.gameObject);
        return this._context;
      }
      set => this._context = value;
    }
  }

  /// <summary>
  /// ComposableBehaviour with context injected.
  /// </summary>
  public class CBC : UniStartBehaviour {
    IIoCC _context = null;
    protected IIoCC context {
      get {
        if (this._context == null)
          this._context = Entry.GetContext(this.gameObject);
        return this._context;
      }
      set => this._context = value;
    }

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    public T Add<T>(object key, T instance) => this.context.Add<T>(key, instance);
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.context.Add<T>(instance);
    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    public T Add<T>(object key) where T : new() => this.context.Add<T>(key);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.context.Add<T>();
    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    public T Get<T>(object key) => this.context.Get<T>(key);
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.context.Get<T>();
    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>(object key) => this.context.TryGet<T>(key);
    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>() => this.context.TryGet<T>();
    #endregion
  }
}