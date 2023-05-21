using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableApplicationPause : MonoBehaviour {
    /// <summary>
    /// Called every time when OnApplicationPause is called.
    /// </summary>
    public AdvancedEvent<bool> @event { get; } = new AdvancedEvent<bool>();

    void OnApplicationPause(bool arg0) {
      this.@event.Invoke(arg0);
    }
  }
}