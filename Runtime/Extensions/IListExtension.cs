using System.Collections.Generic;
using UnityEngine;

namespace DT.UniStart {
  public static class IListExtension {
    public static void Fill<T>(this IList<T> list, T value) {
      for (int i = 0; i < list.Count; i++) {
        list[i] = value;
      }
    }
  }
}