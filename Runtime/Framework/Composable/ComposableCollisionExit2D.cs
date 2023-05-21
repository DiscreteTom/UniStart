using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionExit2D : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionExit2D is called.
    /// </summary>
    public AdvancedEvent<Collision2D> @event { get; } = new AdvancedEvent<Collision2D>();

    void OnCollisionExit2D(Collision2D arg0) {
      this.@event.Invoke(arg0);
    }
  }
}