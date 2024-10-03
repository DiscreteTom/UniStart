using System;
using UnityEngine.Events;

namespace DT.UniStart.UniAction {
  interface IUniAction<T0> {
    void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1);
    R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1);
  }

  interface IUniAction<T0, T1> {
    void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2);
    R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2);
  }

  interface IUniAction<T0, T1, T2> {
    void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3);
    R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3);
  }

  interface IUniAction<T0, T1, T2, T3> {
    void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3, Action<UnityAction<T0, T1, T2, T3>> case4);
    R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3, Func<UnityAction<T0, T1, T2, T3>, R> case4);
  }

  class UniAction0<T0, T1, T2, T3> : IUniAction<T0>, IUniAction<T0, T1>, IUniAction<T0, T1, T2>, IUniAction<T0, T1, T2, T3> {
    UnityAction action;
    public UniAction0(UnityAction action) => this.action = action;
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1) => case0(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2) => case0(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3) => case0(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3, Action<UnityAction<T0, T1, T2, T3>> case4) => case0(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1) => case0(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2) => case0(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3) => case0(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3, Func<UnityAction<T0, T1, T2, T3>, R> case4) => case0(action);
  }
  class UniAction1<T0, T1, T2, T3> : IUniAction<T0>, IUniAction<T0, T1>, IUniAction<T0, T1, T2>, IUniAction<T0, T1, T2, T3> {
    UnityAction<T0> action;
    public UniAction1(UnityAction<T0> action) => this.action = action;
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1) => case1(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2) => case1(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3) => case1(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3, Action<UnityAction<T0, T1, T2, T3>> case4) => case1(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1) => case1(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2) => case1(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3) => case1(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3, Func<UnityAction<T0, T1, T2, T3>, R> case4) => case1(action);
  }
  class UniAction2<T0, T1, T2, T3> : IUniAction<T0, T1>, IUniAction<T0, T1, T2>, IUniAction<T0, T1, T2, T3> {
    UnityAction<T0, T1> action;
    public UniAction2(UnityAction<T0, T1> action) => this.action = action;
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2) => case2(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3) => case2(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3, Action<UnityAction<T0, T1, T2, T3>> case4) => case2(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2) => case2(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3) => case2(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3, Func<UnityAction<T0, T1, T2, T3>, R> case4) => case2(action);
  }
  class UniAction3<T0, T1, T2, T3> : IUniAction<T0, T1, T2>, IUniAction<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2> action;
    public UniAction3(UnityAction<T0, T1, T2> action) => this.action = action;
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3) => case3(action);
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3, Action<UnityAction<T0, T1, T2, T3>> case4) => case3(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3) => case3(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3, Func<UnityAction<T0, T1, T2, T3>, R> case4) => case3(action);
  }
  class UniAction4<T0, T1, T2, T3> : IUniAction<T0, T1, T2, T3> {
    UnityAction<T0, T1, T2, T3> action;
    public UniAction4(UnityAction<T0, T1, T2, T3> action) => this.action = action;
    public void Match(Action<UnityAction> case0, Action<UnityAction<T0>> case1, Action<UnityAction<T0, T1>> case2, Action<UnityAction<T0, T1, T2>> case3, Action<UnityAction<T0, T1, T2, T3>> case4) => case4(action);
    public R Match<R>(Func<UnityAction, R> case0, Func<UnityAction<T0>, R> case1, Func<UnityAction<T0, T1>, R> case2, Func<UnityAction<T0, T1, T2>, R> case3, Func<UnityAction<T0, T1, T2, T3>, R> case4) => case4(action);
  }
}
