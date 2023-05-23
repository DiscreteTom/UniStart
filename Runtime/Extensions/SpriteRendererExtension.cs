using UnityEngine;

namespace DT.UniStart {
  public static class SpriteRendererExtension {
    public static SpriteRenderer WithRed(this SpriteRenderer original, float value) {
      original.color = original.color.WithRed(value);
      return original;
    }
    public static SpriteRenderer WithGreen(this SpriteRenderer original, float value) {
      original.color = original.color.WithGreen(value);
      return original;
    }
    public static SpriteRenderer WithBlue(this SpriteRenderer original, float value) {
      original.color = original.color.WithBlue(value);
      return original;
    }
    public static SpriteRenderer WithAlpha(this SpriteRenderer original, float value) {
      original.color = original.color.WithAlpha(value);
      return original;
    }
  }
}