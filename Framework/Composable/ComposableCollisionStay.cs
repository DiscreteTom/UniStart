using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionStay : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionStay is called.
    /// </summary>
    public CascadeEvent<Collision> @event { get; } = new CascadeEvent<Collision>();

    void OnCollisionStay(Collision arg0) {
      this.@event.Invoke(arg0);
    }
  }
}