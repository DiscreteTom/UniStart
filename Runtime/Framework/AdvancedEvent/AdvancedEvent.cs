using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class AdvancedEvent : IWatchable {
    UnityEvent e;
    UnityEvent once;
    public UnityAction AddListener(UnityAction action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      this.e.RemoveListener(action);
      return action;
    }

    public UnityAction AddOnceListener(UnityAction action) {
      this.once.AddListener(action);
      return action;
    }

    public UnityAction RemoveOnceListener(UnityAction action) {
      this.once.RemoveListener(action);
      return action;
    }

    public void RemoveAllListeners() {
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }
    public void Invoke() {
      this.e.Invoke();
      this.once.Invoke();
      this.once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0> : IWatchable<T0> {
    AdvancedEvent e0 = new AdvancedEvent();
    UnityEvent<T0> e = new UnityEvent<T0>();
    UnityEvent<T0> once = new UnityEvent<T0>();

    public UnityAction AddListener(UnityAction action) => this.e0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.e0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.e0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.e0.RemoveOnceListener(action);

    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.e.RemoveListener(action);
      return action;
    }

    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.once.AddListener(action);
      return action;
    }

    public UnityAction<T0> RemoveOnceListener(UnityAction<T0> action) {
      this.once.RemoveListener(action);
      return action;
    }

    public void RemoveAllListeners() {
      this.e0.RemoveAllListeners();
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0) {
      this.e0.Invoke();
      this.e.Invoke(arg0);
      this.once.Invoke(arg0);
      this.once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1> : IWatchable<T0, T1> {
    AdvancedEvent e0 = new AdvancedEvent();
    UnityEvent<T0, T1> e = new UnityEvent<T0, T1>();
    UnityEvent<T0, T1> once = new UnityEvent<T0, T1>();

    public UnityAction AddListener(UnityAction action) => this.e0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.e0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.e0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.e0.RemoveOnceListener(action);

    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.e.RemoveListener(action);
      return action;
    }

    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.once.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1> RemoveOnceListener(UnityAction<T0, T1> action) {
      this.once.RemoveListener(action);
      return action;
    }

    public void RemoveAllListeners() {
      this.e0.RemoveAllListeners();
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0, T1 arg1) {
      this.e0.Invoke();
      this.e.Invoke(arg0, arg1);
      this.once.Invoke(arg0, arg1);
      this.once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1, T2> : IWatchable<T0, T1, T2> {
    AdvancedEvent e0 = new AdvancedEvent();
    UnityEvent<T0, T1, T2> e = new UnityEvent<T0, T1, T2>();
    UnityEvent<T0, T1, T2> once = new UnityEvent<T0, T1, T2>();

    public UnityAction AddListener(UnityAction action) => this.e0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.e0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.e0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.e0.RemoveOnceListener(action);

    public UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      this.e.RemoveListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.once.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2> RemoveOnceListener(UnityAction<T0, T1, T2> action) {
      this.once.RemoveListener(action);
      return action;
    }

    public void RemoveAllListeners() {
      this.e0.RemoveAllListeners();
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      this.e0.Invoke();
      this.e.Invoke(arg0, arg1, arg2);
      this.once.Invoke(arg0, arg1, arg2);
      this.once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : IWatchable<T0, T1, T2, T3> {
    AdvancedEvent e0 = new AdvancedEvent();
    UnityEvent<T0, T1, T2, T3> e = new UnityEvent<T0, T1, T2, T3>();
    UnityEvent<T0, T1, T2, T3> once = new UnityEvent<T0, T1, T2, T3>();

    public UnityAction AddListener(UnityAction action) => this.e0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.e0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.e0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.e0.RemoveOnceListener(action);

    public UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      this.e.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      this.e.RemoveListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.once.AddListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2, T3> RemoveOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.once.RemoveListener(action);
      return action;
    }

    public void RemoveAllListeners() {
      this.e0.RemoveAllListeners();
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      this.e0.Invoke();
      this.e.Invoke(arg0, arg1, arg2, arg3);
      this.once.Invoke(arg0, arg1, arg2, arg3);
      this.once.RemoveAllListeners();
    }
  }
}