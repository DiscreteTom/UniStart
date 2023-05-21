using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseDrag : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseDrag is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnMouseDrag() {
      this.@event.Invoke();
    }
  }
}