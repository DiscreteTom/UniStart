using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableApplicationQuit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnApplicationQuit is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnApplicationQuit() {
      this.@event.Invoke();
    }
  }
}