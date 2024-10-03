using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionStay : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionStay is called.
    /// </summary>
    public UniEvent<Collision> @event { get; } = new UniEvent<Collision>();

    void OnCollisionStay(Collision arg0) {
      this.@event.Invoke(arg0);
    }
  }
}