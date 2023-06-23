using UnityEngine;

namespace DT.UniStart {
  public static class RigidbodyExtension {
    public static Rigidbody SetVelocityX(this Rigidbody original, float value) {
      original.velocity = original.velocity.WithX(value);
      return original;
    }
    public static Rigidbody SetVelocityY(this Rigidbody original, float value) {
      original.velocity = original.velocity.WithY(value);
      return original;
    }
    public static Rigidbody SetVelocityZ(this Rigidbody original, float value) {
      original.velocity = original.velocity.WithZ(value);
      return original;
    }
  }
}