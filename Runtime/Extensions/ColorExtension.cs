using UnityEngine;

namespace DT.UniStart {
  public static class ColorExtension {
    public static Color WithRed(this Color original, float value) {
      return new Color(value, original.g, original.b, original.a);
    }
    public static Color WithGreen(this Color original, float value) {
      return new Color(original.r, value, original.b, original.a);
    }
    public static Color WithBlue(this Color original, float value) {
      return new Color(original.r, original.g, value, original.a);
    }
    public static Color WithAlpha(this Color original, float value) {
      return new Color(original.r, original.g, original.b, value);
    }
  }
}