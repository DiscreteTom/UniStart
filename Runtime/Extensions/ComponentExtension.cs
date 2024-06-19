using UnityEngine;

namespace DT.UniStart {
  public static class ComponentExtension {
    /// <summary>
    /// Try to get a component from the component's game object.
    /// If it doesn't exist, add it to the game object and return it.
    /// </summary>
    public static T GetOrAddComponent<T>(this Component comp) where T : Component {
      return comp.gameObject.GetOrAddComponent<T>();
    }
  }
}