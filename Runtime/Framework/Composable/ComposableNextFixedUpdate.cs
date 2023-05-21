using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableNextFixedUpdate : MonoBehaviour {
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void FixedUpdate() {
      this.@event.Invoke();
      this.@event.RemoveAllListeners();
    }
  }
}