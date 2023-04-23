using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableApplicationFocus : MonoBehaviour {
    /// <summary>
    /// Called every time when OnApplicationFocus is called.
    /// </summary>
    public CascadeEvent<bool> @event { get; } = new CascadeEvent<bool>();

    void OnApplicationFocus(bool arg0) {
      this.@event.Invoke(arg0);
    }
  }
}