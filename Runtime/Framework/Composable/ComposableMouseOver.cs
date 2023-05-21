using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseOver : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseOver is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnMouseOver() {
      this.@event.Invoke();
    }
  }
}