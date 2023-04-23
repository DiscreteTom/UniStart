using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTriggerStay : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTriggerStay is called.
    /// </summary>
    public CascadeEvent<Collider> @event { get; } = new CascadeEvent<Collider>();

    void OnTriggerStay(Collider arg0) {
      this.@event.Invoke(arg0);
    }
  }
}