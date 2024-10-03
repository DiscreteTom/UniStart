using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleTrigger : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleTrigger is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnParticleTrigger() {
      this.@event.Invoke();
    }
  }
}