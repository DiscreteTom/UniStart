using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionEnter2D : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionEnter2D is called.
    /// </summary>
    public AdvancedEvent<Collision2D> @event { get; } = new AdvancedEvent<Collision2D>();

    void OnCollisionEnter2D(Collision2D arg0) {
      this.@event.Invoke(arg0);
    }
  }
}