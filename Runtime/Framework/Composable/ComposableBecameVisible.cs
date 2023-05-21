using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableBecameVisible : MonoBehaviour {
    /// <summary>
    /// Called every time when OnBecameVisible is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnBecameVisible() {
      this.@event.Invoke();
    }
  }
}