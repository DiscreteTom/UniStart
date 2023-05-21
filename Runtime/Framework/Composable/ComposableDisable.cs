using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDisable : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDisable is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnDisable() {
      this.@event.Invoke();
    }
  }
}