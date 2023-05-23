using UnityEngine;

namespace DT.UniStart {
  public static class QuaternionExtension {
    public static Quaternion WithX(this Quaternion original, float value) {
      return new Quaternion(value, original.y, original.z, original.w);
    }
    public static Quaternion WithY(this Quaternion original, float value) {
      return new Quaternion(original.x, value, original.z, original.w);
    }
    public static Quaternion WithZ(this Quaternion original, float value) {
      return new Quaternion(original.x, original.y, value, original.w);
    }
    public static Quaternion WithW(this Quaternion original, float value) {
      return new Quaternion(original.x, original.y, original.z, value);
    }
  }
}