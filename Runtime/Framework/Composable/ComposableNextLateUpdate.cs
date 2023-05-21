using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableNextLateUpdate : MonoBehaviour {
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void LateUpdate() {
      this.@event.Invoke();
      this.@event.RemoveAllListeners();
    }
  }
}