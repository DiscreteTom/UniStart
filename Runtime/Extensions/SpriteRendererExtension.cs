using UnityEngine;

namespace DT.UniStart {
  public static class SpriteRendererExtension {
    public static SpriteRenderer SetColorRed(this SpriteRenderer original, float value) {
      original.color = original.color.WithRed(value);
      return original;
    }
    public static SpriteRenderer SetColorGreen(this SpriteRenderer original, float value) {
      original.color = original.color.WithGreen(value);
      return original;
    }
    public static SpriteRenderer SetColorBlue(this SpriteRenderer original, float value) {
      original.color = original.color.WithBlue(value);
      return original;
    }
    public static SpriteRenderer SetColorAlpha(this SpriteRenderer original, float value) {
      original.color = original.color.WithAlpha(value);
      return original;
    }
  }
}