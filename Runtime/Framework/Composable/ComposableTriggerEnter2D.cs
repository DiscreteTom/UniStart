using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTriggerEnter2D : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTriggerEnter2D is called.
    /// </summary>
    public UniEvent<Collider2D> @event { get; } = new UniEvent<Collider2D>();

    void OnTriggerEnter2D(Collider2D arg0) {
      this.@event.Invoke(arg0);
    }
  }
}