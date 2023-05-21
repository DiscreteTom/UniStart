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
    Dictionary<UnityAction, UnityAction<T0>> actionDict = new Dictionary<UnityAction, UnityAction<T0>>();

    public UnityAction AddListener(UnityAction action) {
      var wrapped = FnHelper.Fn((T0 _) => action.Invoke());
      this.actionDict[action] = wrapped;
      base.AddListener(wrapped);
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      if (this.actionDict.TryGetValue(action, out UnityAction<T0> wrapped)) {
        base.RemoveListener(wrapped);
        this.actionDict.Remove(action);
      }
      return action;
    }

    public new UnityAction<T0> AddListener(UnityAction<T0> action) {
      base.AddListener(action);
      return action;
    }

    public new UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      base.RemoveListener(action);
      return action;
    }
  }

  public class AdvancedEvent<T0, T1> : UnityEvent<T0, T1>, IWatchable, IWatchable<T0, T1> {
    Dictionary<UnityAction, UnityAction<T0, T1>> actionDict = new Dictionary<UnityAction, UnityAction<T0, T1>>();

    public UnityAction AddListener(UnityAction action) {
      var wrapped = FnHelper.Fn((T0 _, T1 __) => action.Invoke());
      this.actionDict[action] = wrapped;
      base.AddListener(wrapped);
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      if (this.actionDict.TryGetValue(action, out UnityAction<T0, T1> wrapped)) {
        base.RemoveListener(wrapped);
        this.actionDict.Remove(action);
      }
      return action;
    }

    public new UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      base.AddListener(action);
      return action;
    }

    public new UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      base.RemoveListener(action);
      return action;
    }
  }

  public class AdvancedEvent<T0, T1, T2> : UnityEvent<T0, T1, T2>, IWatchable, IWatchable<T0, T1, T2> {
    Dictionary<UnityAction, UnityAction<T0, T1, T2>> actionDict = new Dictionary<UnityAction, UnityAction<T0, T1, T2>>();

    public UnityAction AddListener(UnityAction action) {
      var wrapped = FnHelper.Fn((T0 _, T1 __, T2 ___) => action.Invoke());
      this.actionDict[action] = wrapped;
      base.AddListener(wrapped);
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      if (this.actionDict.TryGetValue(action, out UnityAction<T0, T1, T2> wrapped)) {
        base.RemoveListener(wrapped);
        this.actionDict.Remove(action);
      }
      return action;
    }

    public new UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      base.AddListener(action);
      return action;
    }

    public new UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      base.RemoveListener(action);
      return action;
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : UnityEvent<T0, T1, T2, T3>, IWatchable, IWatchable<T0, T1, T2, T3> {
    Dictionary<UnityAction, UnityAction<T0, T1, T2, T3>> actionDict = new Dictionary<UnityAction, UnityAction<T0, T1, T2, T3>>();

    public UnityAction AddListener(UnityAction action) {
      var wrapped = FnHelper.Fn((T0 _, T1 __, T2 ___, T3 ____) => action.Invoke());
      this.actionDict[action] = wrapped;
      base.AddListener(wrapped);
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      if (this.actionDict.TryGetValue(action, out UnityAction<T0, T1, T2, T3> wrapped)) {
        base.RemoveListener(wrapped);
        this.actionDict.Remove(action);
      }
      return action;
    }

    public new UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      base.AddListener(action);
      return action;
    }

    public new UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      base.RemoveListener(action);
      return action;
    }
  }
}