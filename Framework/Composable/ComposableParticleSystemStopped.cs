using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleSystemStopped : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleSystemStopped is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnParticleSystemStopped() {
      this.@event.Invoke();
    }
  }
}