using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionStay2D : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionStay2D is called.
    /// </summary>
    public UniEvent<Collision2D> @event { get; } = new UniEvent<Collision2D>();

    void OnCollisionStay2D(Collision2D arg0) {
      this.@event.Invoke(arg0);
    }
  }
}