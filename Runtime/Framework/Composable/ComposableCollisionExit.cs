using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionExit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionExit is called.
    /// </summary>
    public UniEvent<Collision> @event { get; } = new UniEvent<Collision>();

    void OnCollisionExit(Collision arg0) {
      this.@event.Invoke(arg0);
    }
  }
}