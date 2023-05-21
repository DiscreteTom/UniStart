using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableLateUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when LateUpdate is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void LateUpdate() {
      this.@event.Invoke();
    }
  }
}