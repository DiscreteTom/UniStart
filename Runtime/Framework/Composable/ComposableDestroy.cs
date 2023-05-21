using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDestroy : MonoBehaviour {
    /// <summary>
    /// Called when the game object is destroyed.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnDestroy() {
      this.@event.Invoke();
    }
  }
}