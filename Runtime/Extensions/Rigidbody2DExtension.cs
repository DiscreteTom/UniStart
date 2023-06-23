using UnityEngine;

namespace DT.UniStart {
  public static class Rigidbody2DExtension {
    public static Rigidbody2D SetVelocityX(this Rigidbody2D original, float value) {
      original.velocity = original.velocity.WithX(value);
      return original;
    }
    public static Rigidbody2D SetVelocityY(this Rigidbody2D original, float value) {
      original.velocity = original.velocity.WithY(value);
      return original;
    }
  }
}