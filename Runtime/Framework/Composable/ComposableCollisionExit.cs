using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionExit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionExit is called.
    /// </summary>
    public AdvancedEvent<Collision> @event { get; } = new AdvancedEvent<Collision>();

    void OnCollisionExit(Collision arg0) {
      this.@event.Invoke(arg0);
    }
  }
}