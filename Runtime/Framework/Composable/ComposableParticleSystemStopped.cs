using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleSystemStopped : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleSystemStopped is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnParticleSystemStopped() {
      this.@event.Invoke();
    }
  }
}