using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseUp : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseUp is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnMouseUp() {
      this.@event.Invoke();
    }
  }
}