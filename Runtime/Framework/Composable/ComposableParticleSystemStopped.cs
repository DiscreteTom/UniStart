using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleSystemStopped : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleSystemStopped is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnParticleSystemStopped() {
      this.@event.Invoke();
    }
  }
}