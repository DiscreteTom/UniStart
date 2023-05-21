using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableFixedUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when FixedUpdate is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void FixedUpdate() {
      this.@event.Invoke();
    }
  }
}