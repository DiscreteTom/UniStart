using UnityEngine;

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
  }

  public class Entry : ComposableBehaviour {
    public IIoCC core { get; private set; } = new IoCC();

    public static IIoCC GetCore(GameObject obj) {
      return Entry<IIoCC>.GetCore(obj);
    }

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.core.Add<T>(instance);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.core.Add<T>();
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.core.Get<T>();
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
        if (this._core != null)
          this._core = Entry<T>.GetCore(this.gameObject);
        return this._core;
      }
      set => this._core = value;
    }
  }

  /// <summary>
  /// ComposableBehaviour with core injected.
  /// </summary>
  public class CBC : ComposableBehaviour {
    IIoCC _core = null;
    protected IIoCC core {
      get {
        if (this._core != null)
          this._core = Entry.GetCore(this.gameObject);
        return this._core;
      }
      set => this._core = value;
    }

    #region re-expose IIoCC methods
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) => this.core.Add<T>(instance);
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.core.Add<T>();
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => this.core.Get<T>();
    #endregion
  }
}