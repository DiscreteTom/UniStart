using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionEnter : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionEnter is called.
    /// </summary>
    public UniEvent<Collision> @event { get; } = new UniEvent<Collision>();

    void OnCollisionEnter(Collision arg0) {
      this.@event.Invoke(arg0);
    }
  }
}