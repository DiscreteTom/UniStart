using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionEnter : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionEnter is called.
    /// </summary>
    public CascadeEvent<Collision> @event { get; } = new CascadeEvent<Collision>();

    void OnCollisionEnter(Collision arg0) {
      this.@event.Invoke(arg0);
    }
  }
}