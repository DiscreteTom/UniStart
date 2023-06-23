using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class AdvancedEvent : UnityEvent, IWatchable {
    public new UnityAction AddListener(UnityAction action) {
      base.AddListener(action);
      return action;
    }

    public new UnityAction RemoveListener(UnityAction action) {
      base.RemoveListener(action);
      return action;
    }
  }

  public class AdvancedEvent<T0> : UnityEvent<T0>, IWatchable, IWatchable<T0> {
    AdvancedEvent event0 = new AdvancedEvent();

    public UnityAction AddListener(UnityAction action) {
      return this.event0.AddListener(action);
    }

    public UnityAction RemoveListener(UnityAction action) {
      return this.event0.RemoveListener(action);
    }

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

    public new void Invoke(T0 arg0) {
      this.event0.Invoke();
      // don't forget to call base.Invoke!
      base.Invoke(arg0);
    }
  }

  public class AdvancedEvent<T0, T1> : UnityEvent<T0, T1>, IWatchable, IWatchable<T0, T1> {
    AdvancedEvent event0 = new AdvancedEvent();

    public UnityAction AddListener(UnityAction action) {
      return this.event0.AddListener(action);
    }

    public UnityAction RemoveListener(UnityAction action) {
      return this.event0.RemoveListener(action);
    }

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

    public new void Invoke(T0 arg0, T1 arg1) {
      this.event0.Invoke();
      // don't forget to call base.Invoke!
      base.Invoke(arg0, arg1);
    }
  }

  public class AdvancedEvent<T0, T1, T2> : UnityEvent<T0, T1, T2>, IWatchable, IWatchable<T0, T1, T2> {
    AdvancedEvent event0 = new AdvancedEvent();

    public UnityAction AddListener(UnityAction action) {
      return this.event0.AddListener(action);
    }

    public UnityAction RemoveListener(UnityAction action) {
      return this.event0.RemoveListener(action);
    }

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

    public new void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      this.event0.Invoke();
      // don't forget to call base.Invoke!
      base.Invoke(arg0, arg1, arg2);
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : UnityEvent<T0, T1, T2, T3>, IWatchable, IWatchable<T0, T1, T2, T3> {
    AdvancedEvent event0 = new AdvancedEvent();

    public UnityAction AddListener(UnityAction action) {
      return this.event0.AddListener(action);
    }

    public UnityAction RemoveListener(UnityAction action) {
      return this.event0.RemoveListener(action);
    }

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

    public new void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      this.event0.Invoke();
      // don't forget to call base.Invoke!
      base.Invoke(arg0, arg1, arg2, arg3);
    }
  }
}