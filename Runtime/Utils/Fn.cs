using UnityEngine.Events;

namespace DT.UniStart {
  public static class FnHelper {
    public static UnityAction Fn(UnityAction action) {
      return action;
    }
    public static UnityAction<T0> Fn<T0>(UnityAction<T0> action) {
      return action;
    }
    public static UnityAction<T0, T1> Fn<T0, T1>(UnityAction<T0, T1> action) {
      return action;
    }
    public static UnityAction<T0, T1, T2> Fn<T0, T1, T2>(UnityAction<T0, T1, T2> action) {
      return action;
    }
    public static UnityAction<T0, T1, T2, T3> Fn<T0, T1, T2, T3>(UnityAction<T0, T1, T2, T3> action) {
      return action;
    }
  }
}