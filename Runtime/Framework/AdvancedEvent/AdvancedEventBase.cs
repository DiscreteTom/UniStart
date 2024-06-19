using System;
using System.Collections.Generic;
using UnityEngine.Events;

// users won't use this namespace directly, so we can use a more specific namespace name.
// in this namespace we will define the base classes for AdvancedEvent.

namespace DT.UniStart.AdvancedEventBase {
  // TODO: will `AdvancedEventParamCount : byte` be better?
  public enum AdvancedEventParamCount {
    _0,
    _1,
    _2,
    _3,
    _4,
  }

  public interface IActionItem {
    public AdvancedEventParamCount paramCount { get; }
    public UnityAction action0 { get; }
    public void _0(UnityAction a); // TODO: move this to another interface?
  }
  public interface IActionItem<T0> : IActionItem {
    public UnityAction<T0> action1 { get; }
    public void _1(UnityAction<T0> a);
  }
  public interface IActionItem<T0, T1> : IActionItem<T0> {
    public UnityAction<T0, T1> action2 { get; }
    public void _2(UnityAction<T0, T1> a);
  }
  public interface IActionItem<T0, T1, T2> : IActionItem<T0, T1> {
    public UnityAction<T0, T1, T2> action3 { get; }
    public void _3(UnityAction<T0, T1, T2> a);
  }
  public interface IActionItem<T0, T1, T2, T3> : IActionItem<T0, T1, T2> {
    public UnityAction<T0, T1, T2, T3> action4 { get; }
    public void _4(UnityAction<T0, T1, T2, T3> a);
  }

  // TODO: is there some way to use union type for ActionItem? then we could store only one action instead of at most 5.
  // currently we store at most 5 actions to avoid the cost of casting to the correct action type.
  // we are using space to save time for now, because for most cases user will use 0 to 2 parameters.
  public class ActionItem : IActionItem {
    public AdvancedEventParamCount paramCount { get; protected set; }
    public UnityAction action0 { get; private set; }
    public void _0(UnityAction a) {
      this.paramCount = AdvancedEventParamCount._0;
      this.action0 = a;
    }
  }
  public class ActionItem<T0> : ActionItem, IActionItem<T0> {
    public UnityAction<T0> action1 { get; private set; }
    public void _1(UnityAction<T0> a) {
      this.paramCount = AdvancedEventParamCount._1;
      this.action1 = a;
    }
  }
  public class ActionItem<T0, T1> : ActionItem<T0>, IActionItem<T0, T1> {
    public UnityAction<T0, T1> action2 { get; private set; }
    public void _2(UnityAction<T0, T1> a) {
      this.paramCount = AdvancedEventParamCount._2;
      this.action2 = a;
    }
  }
  public class ActionItem<T0, T1, T2> : ActionItem<T0, T1>, IActionItem<T0, T1, T2> {
    public UnityAction<T0, T1, T2> action3 { get; private set; }
    public void _3(UnityAction<T0, T1, T2> a) {
      this.paramCount = AdvancedEventParamCount._3;
      this.action3 = a;
    }
  }
  public class ActionItem<T0, T1, T2, T3> : ActionItem<T0, T1, T2>, IActionItem<T0, T1, T2, T3> {
    public UnityAction<T0, T1, T2, T3> action4 { get; private set; }
    public void _4(UnityAction<T0, T1, T2, T3> a) {
      this.paramCount = AdvancedEventParamCount._4;
      this.action4 = a;
    }
  }

  public class BaseAdvancedEvent<A> : IWatchable where A : IActionItem, new() {
    /// <summary>
    /// List of listeners that will be invoked every time the event is triggered.
    /// Including listeners that are added by `AddListener` and `AddOnceListener`.
    /// </summary>
    protected readonly List<A> e = new();
    /// <summary>
    /// List of listeners that will be invoked only once when the event is triggered.
    /// Subclasses should based on this to remove listeners from `e` after invoking.
    /// </summary>
    protected readonly List<A> once = new();

    protected A BaseAddListener(Action<A> decorator) {
      var a = new A();
      decorator(a);
      this.e.Add(a);
      return a;
    }
    protected void BaseAddOnceListener(Action<A> decorator) {
      this.once.Add(this.BaseAddListener(decorator));
    }

    public UnityAction AddListener(UnityAction action) {
      this.BaseAddListener(a => a._0(action));
      return action;
    }
    public UnityAction RemoveListener(UnityAction action) {
      this.e.RemoveAll((x) => x.action0 == action);
      return action;
    }
    public UnityAction AddOnceListener(UnityAction action) {
      this.BaseAddOnceListener(a => a._0(action));
      return action;
    }

    public void RemoveAllListeners() {
      this.e.Clear();
      this.once.Clear();
    }
  }

  public class BaseAdvancedEvent<T0, A> : BaseAdvancedEvent<A>, IWatchable, IWatchable<T0> where A : IActionItem<T0>, new() {
    public UnityAction<T0> AddListener(UnityAction<T0> action) {
      this.BaseAddListener(a => a._1(action));
      return action;
    }
    public UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      this.e.RemoveAll((x) => x.action1 == action);
      return action;
    }
    public UnityAction<T0> AddOnceListener(UnityAction<T0> action) {
      this.BaseAddOnceListener(a => a._1(action));
      return action;
    }
  }

  public class BaseAdvancedEvent<T0, T1, A> : BaseAdvancedEvent<T0, A>, IWatchable, IWatchable<T0>, IWatchable<T0, T1> where A : IActionItem<T0, T1>, new() {
    public UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      this.BaseAddListener(a => a._2(action));
      return action;
    }
    public UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      this.e.RemoveAll((x) => x.action2 == action);
      return action;
    }
    public UnityAction<T0, T1> AddOnceListener(UnityAction<T0, T1> action) {
      this.BaseAddOnceListener(a => a._2(action));
      return action;
    }
  }

  public class BaseAdvancedEvent<T0, T1, T2, A> : BaseAdvancedEvent<T0, T1, A>, IWatchable, IWatchable<T0>, IWatchable<T0, T1>, IWatchable<T0, T1, T2> where A : IActionItem<T0, T1, T2>, new() {
    public UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      this.BaseAddListener(a => a._3(action));
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      this.e.RemoveAll((x) => x.action3 == action);
      return action;
    }
    public UnityAction<T0, T1, T2> AddOnceListener(UnityAction<T0, T1, T2> action) {
      this.BaseAddOnceListener(a => a._3(action));
      return action;
    }
  }

  public class BaseAdvancedEvent<T0, T1, T2, T3, A> : BaseAdvancedEvent<T0, T1, T2, A>, IWatchable, IWatchable<T0>, IWatchable<T0, T1>, IWatchable<T0, T1, T2>, IWatchable<T0, T1, T2, T3> where A : IActionItem<T0, T1, T2, T3>, new() {
    public UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      this.BaseAddListener(a => a._4(action));
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      this.e.RemoveAll((x) => x.action4 == action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> AddOnceListener(UnityAction<T0, T1, T2, T3> action) {
      this.BaseAddOnceListener(a => a._4(action));
      return action;
    }
  }
}
