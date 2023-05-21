using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableCollisionEnter : MonoBehaviour {
    /// <summary>
    /// Called every time when OnCollisionEnter is called.
    /// </summary>
    public AdvancedEvent<Collision> @event { get; } = new AdvancedEvent<Collision>();

    void OnCollisionEnter(Collision arg0) {
      this.@event.Invoke(arg0);
    }
  }
}