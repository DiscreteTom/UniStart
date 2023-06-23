using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class AdvancedEvent : UnityEvent, IWatchable {
    UnityEvent onceEvent = new UnityEvent();

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
      this.onceEvent.AddListener(action);
      return action;
    }
    public UnityAction RemoveOnceListener(UnityAction action) {
      this.onceEvent.RemoveListener(action);
      return action;
    }

    public new void Invoke() {
      base.Invoke();
      this.onceEvent.Invoke();
      this.onceEvent.RemoveAllListeners();
    }
  }

  public class AdvancedEvent<T0> : UnityEvent<T0>, IWatchable, IWatchable<T0> {
    AdvancedEvent event0 = new AdvancedEvent();
    UnityEvent<T0> onceEvent = new UnityEvent<T0>();

    public UnityAction AddListener(UnityAction action) => this.event0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.event0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.event0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.event0.RemoveOnceListener(action);

    public new UnityAction<T0> AddListener(UnityAction<T0> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.AddListener(action);
      return action;
    }
    public new UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.RemoveListener(action);
      return action;
    }

    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.onceEvent.AddListener(action);
      return action;
    }
    public UnityAction<T0> RemoveOnceListener(UnityAction<T0> action) {
      this.onceEvent.RemoveListener(action);
      return action;
    }

    public new void Invoke(T0 arg0) {
      // don't forget to call base.Invoke!
      base.Invoke(arg0);
      this.onceEvent.Invoke(arg0);
      this.onceEvent.RemoveAllListeners();
      this.event0.Invoke();
    }
  }

  public class AdvancedEvent<T0, T1> : UnityEvent<T0, T1>, IWatchable, IWatchable<T0, T1> {
    AdvancedEvent event0 = new AdvancedEvent();
    UnityEvent<T0, T1> onceEvent = new UnityEvent<T0, T1>();

    public UnityAction AddListener(UnityAction action) => this.event0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.event0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.event0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.event0.RemoveOnceListener(action);

    public new UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.AddListener(action);
      return action;
    }
    public new UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.RemoveListener(action);
      return action;
    }

    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.onceEvent.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1> RemoveOnceListener(UnityAction<T0, T1> action) {
      this.onceEvent.RemoveListener(action);
      return action;
    }

    public new void Invoke(T0 arg0, T1 arg1) {
      // don't forget to call base.Invoke!
      base.Invoke(arg0, arg1);
      this.onceEvent.Invoke(arg0, arg1);
      this.onceEvent.RemoveAllListeners();
      this.event0.Invoke();
    }
  }

  public class AdvancedEvent<T0, T1, T2> : UnityEvent<T0, T1, T2>, IWatchable, IWatchable<T0, T1, T2> {
    AdvancedEvent event0 = new AdvancedEvent();
    UnityEvent<T0, T1, T2> onceEvent = new UnityEvent<T0, T1, T2>();

    public UnityAction AddListener(UnityAction action) => this.event0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.event0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.event0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.event0.RemoveOnceListener(action);

    public new UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.AddListener(action);
      return action;
    }
    public new UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.RemoveListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.onceEvent.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveOnceListener(UnityAction<T0, T1, T2> action) {
      this.onceEvent.RemoveListener(action);
      return action;
    }

    public new void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      // don't forget to call base.Invoke!
      base.Invoke(arg0, arg1, arg2);
      this.onceEvent.Invoke(arg0, arg1, arg2);
      this.onceEvent.RemoveAllListeners();
      this.event0.Invoke();
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : UnityEvent<T0, T1, T2, T3>, IWatchable, IWatchable<T0, T1, T2, T3> {
    AdvancedEvent event0 = new AdvancedEvent();
    UnityEvent<T0, T1, T2, T3> onceEvent = new UnityEvent<T0, T1, T2, T3>();

    public UnityAction AddListener(UnityAction action) => this.event0.AddListener(action);
    public UnityAction RemoveListener(UnityAction action) => this.event0.RemoveListener(action);
    public UnityAction AddOnceListener(UnityAction action) => this.event0.AddOnceListener(action);
    public UnityAction RemoveOnceListener(UnityAction action) => this.event0.RemoveOnceListener(action);

    public new UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.AddListener(action);
      return action;
    }
    public new UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      // IMPORTANT: use base.AddListener instead of this.event0.AddListener
      base.RemoveListener(action);
      return action;
    }

    public UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.onceEvent.AddListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.onceEvent.RemoveListener(action);
      return action;
    }

    public new void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      // don't forget to call base.Invoke!
      base.Invoke(arg0, arg1, arg2, arg3);
      this.onceEvent.Invoke(arg0, arg1, arg2, arg3);
      this.onceEvent.RemoveAllListeners();
      this.event0.Invoke();
    }
  }
}