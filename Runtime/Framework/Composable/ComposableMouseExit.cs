using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseExit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseExit is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnMouseExit() {
      this.@event.Invoke();
    }
  }
}