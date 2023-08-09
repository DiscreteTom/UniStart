using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class AdvancedEvent : IWatchable {
    readonly UnityEvent e = new();
    readonly UnityEvent once = new();

    public void AddListener(UnityAction action) => this.e.AddListener(action);
    public void RemoveListener(UnityAction action) => this.e.RemoveListener(action);
    public void AddOnceListener(UnityAction action) => this.once.AddListener(action);
    public void RemoveOnceListener(UnityAction action) => this.once.RemoveListener(action);

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
    readonly UnityEvent<T0> e = new();
    readonly UnityEvent<T0> once = new();

    public void AddListener(UnityAction<T0> action) => this.e.AddListener(action);
    public void RemoveListener(UnityAction<T0> action) => this.e.RemoveListener(action);
    public void AddOnceListener(UnityAction<T0> action) => this.once.AddListener(action);
    public void RemoveOnceListener(UnityAction<T0> action) => this.once.RemoveListener(action);

    public void RemoveAllListeners() {
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0) {
      this.e.Invoke(arg0);
      this.once.Invoke(arg0);
      this.once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1> : IWatchable<T0, T1> {
    readonly UnityEvent<T0, T1> e = new();
    readonly UnityEvent<T0, T1> once = new();

    public void AddListener(UnityAction<T0, T1> action) => this.e.AddListener(action);
    public void RemoveListener(UnityAction<T0, T1> action) => this.e.RemoveListener(action);
    public void AddOnceListener(UnityAction<T0, T1> action) => this.once.AddListener(action);
    public void RemoveOnceListener(UnityAction<T0, T1> action) => this.once.RemoveListener(action);

    public void RemoveAllListeners() {
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0, T1 arg1) {
      this.e.Invoke(arg0, arg1);
      this.once.Invoke(arg0, arg1);
      this.once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1, T2> : IWatchable<T0, T1, T2> {
    readonly UnityEvent<T0, T1, T2> e = new();
    readonly UnityEvent<T0, T1, T2> once = new();

    public void AddListener(UnityAction<T0, T1, T2> action) => this.e.AddListener(action);
    public void RemoveListener(UnityAction<T0, T1, T2> action) => this.e.RemoveListener(action);
    public void AddOnceListener(UnityAction<T0, T1, T2> action) => this.once.AddListener(action);
    public void RemoveOnceListener(UnityAction<T0, T1, T2> action) => this.once.RemoveListener(action);

    public void RemoveAllListeners() {
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      this.e.Invoke(arg0, arg1, arg2);
      this.once.Invoke(arg0, arg1, arg2);
      this.once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : IWatchable<T0, T1, T2, T3> {
    readonly UnityEvent<T0, T1, T2, T3> e = new();
    readonly UnityEvent<T0, T1, T2, T3> once = new();

    public void AddListener(UnityAction<T0, T1, T2, T3> action) => this.e.AddListener(action);
    public void RemoveListener(UnityAction<T0, T1, T2, T3> action) => this.e.RemoveListener(action);
    public void AddOnceListener(UnityAction<T0, T1, T2, T3> action) => this.once.AddListener(action);
    public void RemoveOnceListener(UnityAction<T0, T1, T2, T3> action) => this.once.RemoveListener(action);

    public void RemoveAllListeners() {
      this.e.RemoveAllListeners();
      this.once.RemoveAllListeners();
    }

    public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      this.e.Invoke(arg0, arg1, arg2, arg3);
      this.once.Invoke(arg0, arg1, arg2, arg3);
      this.once.RemoveAllListeners();
    }
  }
}