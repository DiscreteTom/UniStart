using System;
using System.Collections.Generic;

namespace DT.UniStart {
  public static class IListExtension {
    public static void Fill<T>(this IList<T> list, T value) {
      for (var i = 0; i < list.Count; i++) {
        list[i] = value;
      }
    }
    public static void Fill<T>(this IList<T> list, Func<T> factory) {
      for (var i = 0; i < list.Count; i++) {
        list[i] = factory.Invoke();
      }
    }
  }
}