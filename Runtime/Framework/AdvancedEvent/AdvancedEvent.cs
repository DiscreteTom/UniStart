using System;
using UnityEngine.Events;

namespace DT.UniStart {
  public class BaseAdvancedEvent<Event, Action> where Event : UnityEventBase, new() {
    protected readonly Event E = new();
    protected readonly Event Once = new();

    readonly Action<Event, Action> addListenerFunc;
    readonly Action<Event, Action> removeListenerFunc;

    public BaseAdvancedEvent(Action<Event, Action> addListenerFunc, Action<Event, Action> removeListenerFunc) {
      this.addListenerFunc = addListenerFunc;
      this.removeListenerFunc = removeListenerFunc;
    }

    public void AddListener(Action action) => this.addListenerFunc.Invoke(E, action);
    public void RemoveListener(Action action) => this.removeListenerFunc.Invoke(E, action);
    public void AddOnceListener(Action action) => this.addListenerFunc.Invoke(Once, action);
    public void RemoveOnceListener(Action action) => this.removeListenerFunc.Invoke(Once, action);

    public void RemoveAllListeners() {
      this.E.RemoveAllListeners();
      this.Once.RemoveAllListeners();
    }

    protected void AfterInvoke() {
      this.Once.RemoveAllListeners();
    }
  }

  public class AdvancedEvent : BaseAdvancedEvent<UnityEvent, UnityAction>, IWatchable {
    public AdvancedEvent() : base((e, a) => e.AddListener(a), (e, a) => e.RemoveListener(a)) { }

    public void Invoke() {
      this.E.Invoke();
      this.Once.Invoke();
      this.AfterInvoke();
    }
  }

  public class AdvancedEvent<T0> : BaseAdvancedEvent<UnityEvent<T0>, UnityAction<T0>>, IWatchable<T0> {
    public AdvancedEvent() : base((e, a) => e.AddListener(a), (e, a) => e.RemoveListener(a)) { }

    public void Invoke(T0 t0) {
      this.E.Invoke(t0);
      this.Once.Invoke(t0);
      this.AfterInvoke();
    }
  }

  public class AdvancedEvent<T0, T1> : BaseAdvancedEvent<UnityEvent<T0, T1>, UnityAction<T0, T1>>, IWatchable<T0, T1> {
    public AdvancedEvent() : base((e, a) => e.AddListener(a), (e, a) => e.RemoveListener(a)) { }

    public void Invoke(T0 t0, T1 t1) {
      this.E.Invoke(t0, t1);
      this.Once.Invoke(t0, t1);
      this.AfterInvoke();
    }
  }

  public class AdvancedEvent<T0, T1, T2> : BaseAdvancedEvent<UnityEvent<T0, T1, T2>, UnityAction<T0, T1, T2>>, IWatchable<T0, T1, T2> {
    public AdvancedEvent() : base((e, a) => e.AddListener(a), (e, a) => e.RemoveListener(a)) { }

    public void Invoke(T0 t0, T1 t1, T2 t2) {
      this.E.Invoke(t0, t1, t2);
      this.Once.Invoke(t0, t1, t2);
      this.AfterInvoke();
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : BaseAdvancedEvent<UnityEvent<T0, T1, T2, T3>, UnityAction<T0, T1, T2, T3>>, IWatchable<T0, T1, T2, T3> {
    public AdvancedEvent() : base((e, a) => e.AddListener(a), (e, a) => e.RemoveListener(a)) { }

    public void Invoke(T0 t0, T1 t1, T2 t2, T3 t3) {
      this.E.Invoke(t0, t1, t2, t3);
      this.Once.Invoke(t0, t1, t2, t3);
      this.AfterInvoke();
    }
  }
}