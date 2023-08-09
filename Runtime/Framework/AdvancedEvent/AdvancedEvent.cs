using UnityEngine.Events;

namespace DT.UniStart {
  public class BaseAdvancedEvent : IWatchable {
    protected UnityEvent e0 = new();
    protected UnityEvent once0 = new();

    public UnityAction AddListener(UnityAction action) {
      this.e0.AddListener(action);
      return action;
    }
    public UnityAction RemoveListener(UnityAction action) {
      this.e0.RemoveListener(action);
      return action;
    }
    public UnityAction AddOnceListener(UnityAction action) {
      this.once0.AddListener(action);
      return action;
    }
    public UnityAction RemoveOnceListener(UnityAction action) {
      this.once0.RemoveListener(action);
      return action;
    }

    public virtual void RemoveAllListeners() {
      this.e0.RemoveAllListeners();
      this.once0.RemoveAllListeners();
    }
  }

  public class BaseAdvancedEvent<T0> : BaseAdvancedEvent, IWatchable<T0> {
    protected UnityEvent<T0> e1 = new();
    protected UnityEvent<T0> once1 = new();

    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.e1.AddListener(action);
      return action;
    }
    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.e1.RemoveListener(action);
      return action;
    }
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.once1.AddListener(action);
      return action;
    }
    public UnityAction<T0> RemoveOnceListener(UnityAction<T0> action) {
      this.once1.RemoveListener(action);
      return action;
    }

    public override void RemoveAllListeners() {
      base.RemoveAllListeners();
      this.e1.RemoveAllListeners();
      this.once1.RemoveAllListeners();
    }
  }

  public class BaseAdvancedEvent<T0, T1> : BaseAdvancedEvent<T0>, IWatchable<T0, T1> {
    protected UnityEvent<T0, T1> e2 = new();
    protected UnityEvent<T0, T1> once2 = new();

    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.e2.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.e2.RemoveListener(action);
      return action;
    }
    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.once2.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1> RemoveOnceListener(UnityAction<T0, T1> action) {
      this.once2.RemoveListener(action);
      return action;
    }

    public override void RemoveAllListeners() {
      base.RemoveAllListeners();
      this.e2.RemoveAllListeners();
      this.once2.RemoveAllListeners();
    }
  }

  public class BaseAdvancedEvent<T0, T1, T2> : BaseAdvancedEvent<T0, T1>, IWatchable<T0, T1, T2> {
    protected UnityEvent<T0, T1, T2> e3 = new();
    protected UnityEvent<T0, T1, T2> once3 = new();

    public UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      this.e3.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      this.e3.RemoveListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.once3.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveOnceListener(UnityAction<T0, T1, T2> action) {
      this.once3.RemoveListener(action);
      return action;
    }

    public override void RemoveAllListeners() {
      base.RemoveAllListeners();
      this.e3.RemoveAllListeners();
      this.once3.RemoveAllListeners();
    }
  }

  public class BaseAdvancedEvent<T0, T1, T2, T3> : BaseAdvancedEvent<T0, T1, T2>, IWatchable<T0, T1, T2, T3> {
    protected UnityEvent<T0, T1, T2, T3> e4 = new();
    protected UnityEvent<T0, T1, T2, T3> once4 = new();

    public UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      this.e4.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      this.e4.RemoveListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.once4.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.once4.RemoveListener(action);
      return action;
    }

    public override void RemoveAllListeners() {
      base.RemoveAllListeners();
      this.e4.RemoveAllListeners();
      this.once4.RemoveAllListeners();
    }
  }

  public class AdvancedEvent : BaseAdvancedEvent {
    public void Invoke() {
      this.e0.Invoke();
      this.once0.Invoke();
      this.once0.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0> : BaseAdvancedEvent<T0> {
    public void Invoke(T0 arg0) {
      this.e0.Invoke();
      this.e1.Invoke(arg0);
      this.once0.Invoke();
      this.once1.Invoke(arg0);
      this.once0.RemoveAllListeners();
      this.once1.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1> : BaseAdvancedEvent<T0, T1> {
    public void Invoke(T0 arg0, T1 arg1) {
      this.e0.Invoke();
      this.e1.Invoke(arg0);
      this.e2.Invoke(arg0, arg1);
      this.once0.Invoke();
      this.once1.Invoke(arg0);
      this.once2.Invoke(arg0, arg1);
      this.once0.RemoveAllListeners();
      this.once1.RemoveAllListeners();
      this.once2.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1, T2> : BaseAdvancedEvent<T0, T1, T2> {
    public void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      this.e0.Invoke();
      this.e1.Invoke(arg0);
      this.e2.Invoke(arg0, arg1);
      this.e3.Invoke(arg0, arg1, arg2);
      this.once0.Invoke();
      this.once1.Invoke(arg0);
      this.once2.Invoke(arg0, arg1);
      this.once3.Invoke(arg0, arg1, arg2);
      this.once0.RemoveAllListeners();
      this.once1.RemoveAllListeners();
      this.once2.RemoveAllListeners();
      this.once3.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : BaseAdvancedEvent<T0, T1, T2, T3> {
    public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      this.e0.Invoke();
      this.e1.Invoke(arg0);
      this.e2.Invoke(arg0, arg1);
      this.e3.Invoke(arg0, arg1, arg2);
      this.e4.Invoke(arg0, arg1, arg2, arg3);
      this.once0.Invoke();
      this.once1.Invoke(arg0);
      this.once2.Invoke(arg0, arg1);
      this.once3.Invoke(arg0, arg1, arg2);
      this.once4.Invoke(arg0, arg1, arg2, arg3);
      this.once0.RemoveAllListeners();
      this.once1.RemoveAllListeners();
      this.once2.RemoveAllListeners();
      this.once3.RemoveAllListeners();
      this.once4.RemoveAllListeners();
    }
  }
}