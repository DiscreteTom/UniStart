using System;
using System.Collections.Generic;

namespace DT.UniStart {
  public static class IEnumerableExtension {
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action) {
      var i = 0;
      foreach (var item in enumerable) {
        action(item, i);
        i++;
      }
    }

    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action) {
      enumerable.ForEach((T item, int i) => action(item));
    }

    public static R[] Map<T, R>(this IEnumerable<T> enumerable, Func<T, int, R> action) {
      var list = new List<R>();
      var i = 0;
      foreach (var item in enumerable) {
        list.Add(action(item, i));
        i++;
      }
      return list.ToArray();
    }

    public static R[] Map<T, R>(this IEnumerable<T> enumerable, Func<T, R> action) {
      return enumerable.Map((T item, int i) => action(item));
    }

    public static T[] Shuffle<T>(this IEnumerable<T> enumerable) {
      var list = new List<T>(enumerable);
      for (var i = 0; i < list.Count; i++) {
        var j = UnityEngine.Random.Range(i, list.Count);
        (list[j], list[i]) = (list[i], list[j]);
      }
      return list.ToArray();
    }
  }
}