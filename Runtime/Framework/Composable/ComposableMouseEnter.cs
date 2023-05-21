using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseEnter : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseEnter is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnMouseEnter() {
      this.@event.Invoke();
    }
  }
}