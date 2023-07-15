using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class AdvancedEvent : UnityEvent, IWatchable, IOnceWatchable {
    public new UnityAction AddListener(UnityAction action) {
      base.AddListener(action);
      return action;
    }

    public new UnityAction RemoveListener(UnityAction action) {
      base.RemoveListener(action);
      return action;
    }

    /// <summary>
    /// Add a listener that will be invoked only once.
    /// </summary>
    public UnityAction AddOnceListener(UnityAction action) {
      this.AddListener(action);
      this.AddListener(() => this.RemoveListener(action));
      return action;
    }

    public new void Invoke() => base.Invoke();
  }

  public class AdvancedEvent<T0> : AdvancedEvent, IWatchable<T0>, IOnceWatchable<T0> {
    UnityEvent<T0> e = new UnityEvent<T0>();

    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.e.RemoveListener(action);
      return action;
    }

    /// <summary>
    /// Add a listener that will be invoked only once.
    /// </summary>
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.AddListener(action);
      this.AddListener(() => this.RemoveListener(action));
      return action;
    }

    public void Invoke(T0 arg0) {
      base.Invoke();
      this.e.Invoke(arg0);
    }
  }

  public class AdvancedEvent<T0, T1> : AdvancedEvent, IWatchable<T0, T1>, IOnceWatchable<T0, T1> {
    UnityEvent<T0, T1> e = new UnityEvent<T0, T1>();

    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.e.RemoveListener(action);
      return action;
    }

    /// <summary>
    /// Add a listener that will be invoked only once.
    /// </summary>
    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.AddListener(action);
      this.AddListener(() => this.RemoveListener(action));
      return action;
    }

    public void Invoke(T0 arg0, T1 arg1) {
      base.Invoke();
      this.e.Invoke(arg0, arg1);
    }
  }

  public class AdvancedEvent<T0, T1, T2> : AdvancedEvent, IWatchable<T0, T1, T2>, IOnceWatchable<T0, T1, T2> {
    UnityEvent<T0, T1, T2> e = new UnityEvent<T0, T1, T2>();

    public UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      this.e.RemoveListener(action);
      return action;
    }

    /// <summary>
    /// Add a listener that will be invoked only once.
    /// </summary>
    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.AddListener(action);
      this.AddListener(() => this.RemoveListener(action));
      return action;
    }

    public void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      base.Invoke();
      this.e.Invoke(arg0, arg1, arg2);
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : AdvancedEvent, IWatchable<T0, T1, T2, T3>, IOnceWatchable<T0, T1, T2, T3> {
    UnityEvent<T0, T1, T2, T3> e = new UnityEvent<T0, T1, T2, T3>();

    public UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      this.e.RemoveListener(action);
      return action;
    }

    /// <summary>
    /// Add a listener that will be invoked only once.
    /// </summary>
    public UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.AddListener(action);
      this.AddListener(() => this.RemoveListener(action));
      return action;
    }

    public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      base.Invoke();
      this.e.Invoke(arg0, arg1, arg2, arg3);
    }
  }
}