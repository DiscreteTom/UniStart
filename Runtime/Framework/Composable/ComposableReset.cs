using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableReset : MonoBehaviour {
    /// <summary>
    /// Called every time when Reset is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void Reset() {
      this.@event.Invoke();
    }
  }
}