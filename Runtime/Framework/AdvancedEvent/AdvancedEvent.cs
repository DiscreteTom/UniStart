using System;
using UnityEngine.Events;

namespace DT.UniStart {
  public class BaseAdvancedEvent<EventType, ActionType> where EventType : UnityEventBase, new() {
    protected readonly EventType E = new();
    protected readonly EventType Once = new();

    readonly Action<EventType, ActionType> addListenerAction;
    readonly Action<EventType, ActionType> removeListenerAction;

    public BaseAdvancedEvent(Action<EventType, ActionType> addListenerFunc, Action<EventType, ActionType> removeListenerFunc) {
      this.addListenerAction = addListenerFunc;
      this.removeListenerAction = removeListenerFunc;
    }

    public ActionType AddListener(ActionType action) {
      this.addListenerAction.Invoke(E, action);
      return action;
    }
    public ActionType RemoveListener(ActionType action) {
      this.removeListenerAction.Invoke(E, action);
      return action;
    }
    public ActionType AddOnceListener(ActionType action) {
      this.addListenerAction.Invoke(Once, action);
      return action;
    }
    public ActionType RemoveOnceListener(ActionType action) {
      this.removeListenerAction.Invoke(Once, action);
      return action;
    }

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