using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleCollision : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleCollision is called.
    /// </summary>
    public CascadeEvent<GameObject> @event { get; } = new CascadeEvent<GameObject>();

    void OnParticleCollision(GameObject arg0) {
      this.@event.Invoke(arg0);
    }
  }
}