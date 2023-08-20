using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart.AdvancedEventBase {
  // TODO: will `AdvancedEventParamCount : byte` be better?
  public enum AdvancedEventParamCount {
    _0,
    _1,
    _2,
    _3,
    _4,
  }

  // TODO: is there some way to use union type for ActionItem? then we could store only one action instead of 4.
  // currently we store 4 actions to avoid the cost of casting to the correct action type
  public interface IActionItem {
    public AdvancedEventParamCount paramCount { get; set; }
    public UnityAction action0 { get; set; }
  }
  public interface IActionItem<T0> : IActionItem {
    public UnityAction<T0> action1 { get; set; }
  }
  public interface IActionItem<T0, T1> : IActionItem<T0> {
    public UnityAction<T0, T1> action2 { get; set; }
  }
  public interface IActionItem<T0, T1, T2> : IActionItem<T0, T1> {
    public UnityAction<T0, T1, T2> action3 { get; set; }
  }
  public interface IActionItem<T0, T1, T2, T3> : IActionItem<T0, T1, T2> {
    public UnityAction<T0, T1, T2, T3> action4 { get; set; }
  }

  public struct ActionItem : IActionItem {
    public AdvancedEventParamCount paramCount { get; set; }
    public UnityAction action0 { get; set; }
  }
  public struct ActionItem<T0> : IActionItem<T0> {
    public AdvancedEventParamCount paramCount { get; set; }
    public UnityAction action0 { get; set; }
    public UnityAction<T0> action1 { get; set; }
  }
  public struct ActionItem<T0, T1> : IActionItem<T0, T1> {
    public AdvancedEventParamCount paramCount { get; set; }
    public UnityAction action0 { get; set; }
    public UnityAction<T0> action1 { get; set; }
    public UnityAction<T0, T1> action2 { get; set; }
  }
  public struct ActionItem<T0, T1, T2> : IActionItem<T0, T1, T2> {
    public AdvancedEventParamCount paramCount { get; set; }
    public UnityAction action0 { get; set; }
    public UnityAction<T0> action1 { get; set; }
    public UnityAction<T0, T1> action2 { get; set; }
    public UnityAction<T0, T1, T2> action3 { get; set; }
  }
  public struct ActionItem<T0, T1, T2, T3> : IActionItem<T0, T1, T2, T3> {
    public AdvancedEventParamCount paramCount { get; set; }
    public UnityAction action0 { get; set; }
    public UnityAction<T0> action1 { get; set; }
    public UnityAction<T0, T1> action2 { get; set; }
    public UnityAction<T0, T1, T2> action3 { get; set; }
    public UnityAction<T0, T1, T2, T3> action4 { get; set; }
  }

  public class BaseAdvancedEvent<A> : IWatchable where A : IActionItem, new() {
    protected readonly List<A> e = new();
    protected readonly List<A> once = new();

    public UnityAction AddListener(UnityAction action) {
      this.e.Add(new A {
        paramCount = AdvancedEventParamCount._0,
        action0 = action
      });
      return action;
    }
    public UnityAction RemoveListener(UnityAction action) {
      this.e.RemoveAll((x) => x.action0 == action);
      return action;
    }
    public UnityAction AddOnceListener(UnityAction action) {
      this.once.Add(new A {
        paramCount = AdvancedEventParamCount._0,
        action0 = action
      });
      return action;
    }
    public UnityAction RemoveOnceListener(UnityAction action) {
      this.once.RemoveAll((x) => x.action0 == action);
      return action;
    }

    public void RemoveAllListeners() {
      this.e.Clear();
      this.once.Clear();
    }
  }

  public class BaseAdvancedEvent<T0, A> : BaseAdvancedEvent<A>, IWatchable, IWatchable<T0> where A : IActionItem<T0>, new() {
    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.e.Add(new A {
        paramCount = AdvancedEventParamCount._1,
        action1 = action
      });
      return action;
    }
    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.e.RemoveAll((x) => x.action1 == action);
      return action;
    }
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.once.Add(new A {
        paramCount = AdvancedEventParamCount._1,
        action1 = action
      });
      return action;
    }
    public UnityAction<T0> RemoveOnceListener(UnityAction<T0> action) {
      this.once.RemoveAll((x) => x.action1 == action);
      return action;
    }
  }

  public class BaseAdvancedEvent<T0, T1, A> : BaseAdvancedEvent<T0, A>, IWatchable, IWatchable<T0>, IWatchable<T0, T1> where A : IActionItem<T0, T1>, new() {
    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.e.Add(new A {
        paramCount = AdvancedEventParamCount._2,
        action2 = action
      });
      return action;
    }
    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.e.RemoveAll((x) => x.action2 == action);
      return action;
    }
    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.once.Add(new A {
        paramCount = AdvancedEventParamCount._2,
        action2 = action
      });
      return action;
    }
    public UnityAction<T0, T1> RemoveOnceListener(UnityAction<T0, T1> action) {
      this.once.RemoveAll((x) => x.action2 == action);
      return action;
    }
  }

  public class BaseAdvancedEvent<T0, T1, T2, A> : BaseAdvancedEvent<T0, T1, A>, IWatchable, IWatchable<T0>, IWatchable<T0, T1>, IWatchable<T0, T1, T2> where A : IActionItem<T0, T1, T2>, new() {
    public UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      this.e.Add(new A {
        paramCount = AdvancedEventParamCount._3,
        action3 = action
      });
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      this.e.RemoveAll((x) => x.action3 == action);
      return action;
    }
    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.once.Add(new A {
        paramCount = AdvancedEventParamCount._3,
        action3 = action
      });
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveOnceListener(UnityAction<T0, T1, T2> action) {
      this.once.RemoveAll((x) => x.action3 == action);
      return action;
    }
  }

  public class BaseAdvancedEvent<T0, T1, T2, T3, A> : BaseAdvancedEvent<T0, T1, T2, A>, IWatchable, IWatchable<T0>, IWatchable<T0, T1>, IWatchable<T0, T1, T2>, IWatchable<T0, T1, T2, T3> where A : IActionItem<T0, T1, T2, T3>, new() {
    public UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      this.e.Add(new A {
        paramCount = AdvancedEventParamCount._4,
        action4 = action
      });
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      this.e.RemoveAll((x) => x.action4 == action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.once.Add(new A {
        paramCount = AdvancedEventParamCount._4,
        action4 = action
      });
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.once.RemoveAll((x) => x.action4 == action);
      return action;
    }
  }
}
