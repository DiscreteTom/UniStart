using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTriggerStay2D : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTriggerStay2D is called.
    /// </summary>
    public CascadeEvent<Collider2D> @event { get; } = new CascadeEvent<Collider2D>();

    void OnTriggerStay2D(Collider2D arg0) {
      this.@event.Invoke(arg0);
    }
  }
}