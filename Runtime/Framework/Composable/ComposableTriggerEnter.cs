using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTriggerEnter : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTriggerEnter is called.
    /// </summary>
    public UniEvent<Collider> @event { get; } = new UniEvent<Collider>();

    void OnTriggerEnter(Collider arg0) {
      this.@event.Invoke(arg0);
    }
  }
}