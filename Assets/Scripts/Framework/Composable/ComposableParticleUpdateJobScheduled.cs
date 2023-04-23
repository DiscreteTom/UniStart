using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleUpdateJobScheduled : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleUpdateJobScheduled is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnParticleUpdateJobScheduled() {
      this.@event.Invoke();
    }
  }
}