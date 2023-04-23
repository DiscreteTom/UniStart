using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableParticleTrigger : MonoBehaviour {
    /// <summary>
    /// Called every time when OnParticleTrigger is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnParticleTrigger() {
      this.@event.Invoke();
    }
  }
}