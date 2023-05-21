using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePreCull : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPreCull is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnPreCull() {
      this.@event.Invoke();
    }
  }
}