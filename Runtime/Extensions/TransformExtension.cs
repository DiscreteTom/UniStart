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
    public static Transform SetRotationX(this Transform t, float value) {
      t.rotation = t.rotation.WithX(value);
      return t;
    }
    public static Transform SetRotationY(this Transform t, float value) {
      t.rotation = t.rotation.WithY(value);
      return t;
    }
    public static Transform SetRotationZ(this Transform t, float value) {
      t.rotation = t.rotation.WithZ(value);
      return t;
    }
    public static Transform SetRotationW(this Transform t, float value) {
      t.rotation = t.rotation.WithW(value);
      return t;
    }
    public static Transform SetLocalRotationX(this Transform t, float value) {
      t.localRotation = t.localRotation.WithX(value);
      return t;
    }
    public static Transform SetLocalRotationY(this Transform t, float value) {
      t.localRotation = t.localRotation.WithY(value);
      return t;
    }
    public static Transform SetLocalRotationZ(this Transform t, float value) {
      t.localRotation = t.localRotation.WithZ(value);
      return t;
    }
    public static Transform SetLocalRotationW(this Transform t, float value) {
      t.localRotation = t.localRotation.WithW(value);
      return t;
    }

    public static Transform ForEachChild(this Transform t, Action<Transform, int> action) {
      for (int i = 0; i < t.childCount; i++) {
        action(t.GetChild(i), i);
      }
      return t;
    }
    public static Transform ForEachChild(this Transform t, Action<Transform> action) {
      return t.ForEachChild((t, i) => action(t));
    }
    public static T[] MapChildren<T>(this Transform t, Func<Transform, int, T> action) {
      T[] result = new T[t.childCount];
      for (int i = 0; i < t.childCount; i++) {
        result[i] = action(t.GetChild(i), i);
      }
      return result;
    }
    public static T[] MapChildren<T>(this Transform t, Func<Transform, T> action) {
      return t.MapChildren((t, i) => action(t));
    }
  }
}