using UnityEngine;

namespace DT.UniStart {
  public static class VectorExtension {
    public static Vector2 WithX(this Vector2 original, float value) {
      return new Vector2(value, original.y);
    }
    public static Vector2 WithY(this Vector2 original, float value) {
      return new Vector2(original.x, value);
    }
    public static Vector3 WithX(this Vector3 original, float value) {
      return new Vector3(value, original.y, original.z);
    }
    public static Vector3 WithY(this Vector3 original, float value) {
      return new Vector3(original.x, value, original.z);
    }
    public static Vector3 WithZ(this Vector3 original, float value) {
      return new Vector3(original.x, original.y, value);
    }
  }
}