using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseDown : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseDown is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnMouseDown() {
      this.@event.Invoke();
    }
  }
}