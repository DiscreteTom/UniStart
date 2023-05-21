using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleUpdateJobScheduled : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleUpdateJobScheduled is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnParticleUpdateJobScheduled() {
      this.@event.Invoke();
    }
  }
}