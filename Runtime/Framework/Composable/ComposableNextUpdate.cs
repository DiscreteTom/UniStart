using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableNextUpdate : MonoBehaviour {
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void Update() {
      this.@event.Invoke();
      this.@event.RemoveAllListeners();
    }
  }
}