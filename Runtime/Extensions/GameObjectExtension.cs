using UnityEngine;

namespace DT.UniStart {
  public static class GameObjectExtension {
    /// <summary>
    /// Try to get a component from the game object.
    /// If it doesn't exist, add it to the game object and return it.
    /// </summary>
    public static T GetOrAddComponent<T>(this GameObject obj) where T : Component {
      // IMPORTANT: don't use `??` to check for null, because Unity overrides the == operator
      if (obj.TryGetComponent<T>(out var res)) return res;
      return obj.AddComponent<T>();
    }
  }
}