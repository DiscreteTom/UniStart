using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTriggerExit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTriggerExit is called.
    /// </summary>
    public CascadeEvent<Collider> @event { get; } = new CascadeEvent<Collider>();

    void OnTriggerExit(Collider arg0) {
      this.@event.Invoke(arg0);
    }
  }
}