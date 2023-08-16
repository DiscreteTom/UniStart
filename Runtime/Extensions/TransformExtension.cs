using System;
using UnityEngine;

namespace DT.UniStart {
  public static class TransformExtension {
    public static Transform SetPositionX(this Transform t, float value) {
      t.position = t.position.WithX(value);
      return t;
    }
    public static Transform SetPositionY(this Transform t, float value) {
      t.position = t.position.WithY(value);
      return t;
    }
    public static Transform SetPositionZ(this Transform t, float value) {
      t.position = t.position.WithZ(value);
      return t;
    }
    public static Transform SetLocalPositionX(this Transform t, float value) {
      t.localPosition = t.localPosition.WithX(value);
      return t;
    }
    public static Transform SetLocalPositionY(this Transform t, float value) {
      t.localPosition = t.localPosition.WithY(value);
      return t;
    }
    public static Transform SetLocalPositionZ(this Transform t, float value) {
      t.localPosition = t.localPosition.WithZ(value);
      return t;
    }
    public static Transform SetLocalScaleX(this Transform t, float value) {
      t.localScale = t.localScale.WithX(value);
      return t;
    }
    public static Transform SetLocalScaleY(this Transform t, float value) {
      t.localScale = t.localScale.WithY(value);
      return t;
    }
    public static Transform SetLocalScaleZ(this Transform t, float value) {
      t.localScale = t.localScale.WithZ(value);
      return t;
    }

    public static Transform ForEachChild(this Transform t, Action<Transform, int> action) {
      for (var i = 0; i < t.childCount; i++) {
        action(t.GetChild(i), i);
      }
      return t;
    }
    public static Transform ForEachChild(this Transform t, Action<Transform> action) {
      return t.ForEachChild((t, i) => action(t));
    }
    public static T[] MapChildren<T>(this Transform t, Func<Transform, int, T> action) {
      var result = new T[t.childCount];
      for (var i = 0; i < t.childCount; i++) {
        result[i] = action(t.GetChild(i), i);
      }
      return result;
    }
    public static T[] MapChildren<T>(this Transform t, Func<Transform, T> action) {
      return t.MapChildren((t, i) => action(t));
    }
  }
}