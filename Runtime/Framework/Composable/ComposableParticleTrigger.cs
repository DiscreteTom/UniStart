using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleTrigger : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleTrigger is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnParticleTrigger() {
      this.@event.Invoke();
    }
  }
}