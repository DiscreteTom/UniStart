using System.Collections.Generic;
using UnityEngine.Events;
using DT.UniStart.UniAction;
using System;

namespace DT.UniStart {
  class UniEventCore<A> {
    abstract class AfterInvoke {
      public abstract void Invoke(UniEventCore<A> core);
      public class AddListener : AfterInvoke {
        A action;
        public AddListener(A action) => this.action = action;
        public override void Invoke(UniEventCore<A> core) => core.DoAddListener(this.action);
      }
      public class AddOnceListener : AfterInvoke {
        A action;
        public AddOnceListener(A action) => this.action = action;
        public override void Invoke(UniEventCore<A> core) => core.DoAddOnceListener(this.action);
      }
      public class RemoveListener : AfterInvoke {
        Predicate<A> p;
        public RemoveListener(Predicate<A> p) => this.p = p;
        public override void Invoke(UniEventCore<A> core) => core.DoRemoveListener(p);
      }
      public class RemoveAllListeners : AfterInvoke {
        public override void Invoke(UniEventCore<A> core) => core.DoRemoveAllListeners();
      }
    }

    readonly List<A> actions = new();
    List<AfterInvoke> after = new();
    bool invoking = false;

    void DoAddListener(A action) {
      this.actions.Add(action);
    }
    public void AddListener(A action) {
      if (this.invoking) {
        this.after.Add(new AfterInvoke.AddListener(action));
      } else {
        this.DoAddListener(action);
      }
    }

    void DoAddOnceListener(A action) {
      this.actions.Add(action);
      this.after.Add(new AfterInvoke.RemoveListener((a) => a.Equals(action)));
    }
    public void AddOnceListener(A action) {
      if (this.invoking) {
        this.after.Add(new AfterInvoke.AddOnceListener(action));
      } else {
        this.DoAddOnceListener(action);
      }
    }

    void DoRemoveListener(Predicate<A> p) {
      this.actions.RemoveAll(p);
    }
    public void RemoveListener(Predicate<A> p) {
      if (this.invoking) {
        this.after.Add(new AfterInvoke.RemoveListener(p));
      } else {
        this.DoRemoveListener(p);
      }
    }

    void DoRemoveAllListeners() {
      this.actions.Clear();
    }
    public void RemoveAllListeners() {
      if (this.invoking) {
        this.after.Add(new AfterInvoke.RemoveAllListeners());
      } else {
        this.DoRemoveAllListeners();
      }
    }

    public void Invoke(Action<A> invoker) {
      this.invoking = true;
      foreach (var a in this.actions) {
        invoker(a);
      }
      this.invoking = false;

      if (this.after.Count > 0) {
        // swap `this.after` so that it is mutable during the iteration
        var after = this.after;
        this.after = new();
        foreach (var a in after) {
          a.Invoke(this);
        }
      }
    }
  }

  public class UniEvent : IWatchable {
    readonly UniEventCore<UnityAction> core = new();

    public UnityAction AddListener(UnityAction action) {
      this.core.AddListener(action);
      return action;
    }

    public UnityAction AddOnceListener(UnityAction action) {
      this.core.AddOnceListener(action);
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      this.core.RemoveListener((x) => x == action);
      return action;
    }

    public void RemoveAllListeners() => this.core.RemoveAllListeners();

    public void Invoke() {
      this.core.Invoke((a) => a.Invoke());
    }
  }

  public class UniEvent<T0> : IWatchable<T0> {
    readonly UniEventCore<IUniAction<T0>> core = new();

    public UnityAction AddListener(UnityAction action) {
      this.core.AddListener(new UniAction0<T0, object, object, object>(action));
      return action;
    }
    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.core.AddListener(new UniAction1<T0, object, object, object>(action));
      return action;
    }

    public UnityAction AddOnceListener(UnityAction action) {
      this.core.AddOnceListener(new UniAction0<T0, object, object, object>(action));
      return action;
    }
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.core.AddOnceListener(new UniAction1<T0, object, object, object>(action));
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      this.core.RemoveListener((x) => x.Match((a) => a == action, (a) => false));
      return action;
    }
    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => a == action));
      return action;
    }

    public void RemoveAllListeners() => this.core.RemoveAllListeners();

    public void Invoke(T0 arg0) {
      this.core.Invoke(action => action.Match(
        (a) => a.Invoke(),
        (a) => a.Invoke(arg0)
      ));
    }
  }

  public class UniEvent<T0, T1> : IWatchable<T0, T1> {
    readonly UniEventCore<IUniAction<T0, T1>> core = new();

    public UnityAction AddListener(UnityAction action) {
      this.core.AddListener(new UniAction0<T0, T1, object, object>(action));
      return action;
    }
    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.core.AddListener(new UniAction1<T0, T1, object, object>(action));
      return action;
    }
    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.core.AddListener(new UniAction2<T0, T1, object, object>(action));
      return action;
    }

    public UnityAction AddOnceListener(UnityAction action) {
      this.core.AddOnceListener(new UniAction0<T0, T1, object, object>(action));
      return action;
    }
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.core.AddOnceListener(new UniAction1<T0, T1, object, object>(action));
      return action;
    }
    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.core.AddOnceListener(new UniAction2<T0, T1, object, object>(action));
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      this.core.RemoveListener((x) => x.Match((a) => a == action, (a) => false, (a) => false));
      return action;
    }
    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => a == action, (a) => false));
      return action;
    }
    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => false, (a) => a == action));
      return action;
    }

    public void RemoveAllListeners() => this.core.RemoveAllListeners();

    public void Invoke(T0 arg0, T1 arg1) {
      this.core.Invoke(action => action.Match(
        (a) => a.Invoke(),
        (a) => a.Invoke(arg0),
        (a) => a.Invoke(arg0, arg1)
      ));
    }
  }

  public class UniEvent<T0, T1, T2> : IWatchable<T0, T1, T2> {
    readonly UniEventCore<IUniAction<T0, T1, T2>> core = new();

    public UnityAction AddListener(UnityAction action) {
      this.core.AddListener(new UniAction0<T0, T1, T2, object>(action));
      return action;
    }
    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.core.AddListener(new UniAction1<T0, T1, T2, object>(action));
      return action;
    }
    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.core.AddListener(new UniAction2<T0, T1, T2, object>(action));
      return action;
    }
    public UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      this.core.AddListener(new UniAction3<T0, T1, T2, object>(action));
      return action;
    }

    public UnityAction AddOnceListener(UnityAction action) {
      this.core.AddOnceListener(new UniAction0<T0, T1, T2, object>(action));
      return action;
    }
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.core.AddOnceListener(new UniAction1<T0, T1, T2, object>(action));
      return action;
    }
    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.core.AddOnceListener(new UniAction2<T0, T1, T2, object>(action));
      return action;
    }
    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.core.AddOnceListener(new UniAction3<T0, T1, T2, object>(action));
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      this.core.RemoveListener((x) => x.Match((a) => a == action, (a) => false, (a) => false, (a) => false));
      return action;
    }
    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => a == action, (a) => false, (a) => false));
      return action;
    }
    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => false, (a) => a == action, (a) => false));
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => false, (a) => false, (a) => a == action));
      return action;
    }

    public void RemoveAllListeners() => this.core.RemoveAllListeners();

    public void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      this.core.Invoke(action => action.Match(
        (a) => a.Invoke(),
        (a) => a.Invoke(arg0),
        (a) => a.Invoke(arg0, arg1),
        (a) => a.Invoke(arg0, arg1, arg2)
      ));
    }
  }

  public class UniEvent<T0, T1, T2, T3> : IWatchable<T0, T1, T2, T3> {
    readonly UniEventCore<IUniAction<T0, T1, T2, T3>> core = new();

    public UnityAction AddListener(UnityAction action) {
      this.core.AddListener(new UniAction0<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.core.AddListener(new UniAction1<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.core.AddListener(new UniAction2<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      this.core.AddListener(new UniAction3<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      this.core.AddListener(new UniAction4<T0, T1, T2, T3>(action));
      return action;
    }

    public UnityAction AddOnceListener(UnityAction action) {
      this.core.AddOnceListener(new UniAction0<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.core.AddOnceListener(new UniAction1<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.core.AddOnceListener(new UniAction2<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.core.AddOnceListener(new UniAction3<T0, T1, T2, T3>(action));
      return action;
    }
    public UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.core.AddOnceListener(new UniAction4<T0, T1, T2, T3>(action));
      return action;
    }

    public UnityAction RemoveListener(UnityAction action) {
      this.core.RemoveListener((x) => x.Match((a) => a == action, (a) => false, (a) => false, (a) => false, (a) => false));
      return action;
    }
    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => a == action, (a) => false, (a) => false, (a) => false));
      return action;
    }
    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => false, (a) => a == action, (a) => false, (a) => false));
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => false, (a) => false, (a) => a == action, a => false));
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      this.core.RemoveListener((x) => x.Match((a) => false, (a) => false, (a) => false, (a) => false, a => a == action));
      return action;
    }

    public void RemoveAllListeners() => this.core.RemoveAllListeners();

    public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      this.core.Invoke(action => action.Match(
        (a) => a.Invoke(),
        (a) => a.Invoke(arg0),
        (a) => a.Invoke(arg0, arg1),
        (a) => a.Invoke(arg0, arg1, arg2),
        (a) => a.Invoke(arg0, arg1, arg2, arg3)
      ));
    }
  }
}