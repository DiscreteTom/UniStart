using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTriggerExit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTriggerExit is called.
    /// </summary>
    public AdvancedEvent<Collider> @event { get; } = new AdvancedEvent<Collider>();

    void OnTriggerExit(Collider arg0) {
      this.@event.Invoke(arg0);
    }
  }
}