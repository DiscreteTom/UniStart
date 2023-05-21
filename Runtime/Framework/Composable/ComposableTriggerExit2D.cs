using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTriggerExit2D : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTriggerExit2D is called.
    /// </summary>
    public AdvancedEvent<Collider2D> @event { get; } = new AdvancedEvent<Collider2D>();

    void OnTriggerExit2D(Collider2D arg0) {
      this.@event.Invoke(arg0);
    }
  }
}