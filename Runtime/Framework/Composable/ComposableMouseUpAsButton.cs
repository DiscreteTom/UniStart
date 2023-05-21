using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseUpAsButton : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseUpAsButton is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnMouseUpAsButton() {
      this.@event.Invoke();
    }
  }
}