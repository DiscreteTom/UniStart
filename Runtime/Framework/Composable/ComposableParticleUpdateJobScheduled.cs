using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleUpdateJobScheduled : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleUpdateJobScheduled is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnParticleUpdateJobScheduled() {
      this.@event.Invoke();
    }
  }
}