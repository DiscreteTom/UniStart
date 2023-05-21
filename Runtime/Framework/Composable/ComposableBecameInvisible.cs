using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableBecameInvisible : MonoBehaviour {
    /// <summary>
    /// Called every time when OnBecameInvisible is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnBecameInvisible() {
      this.@event.Invoke();
    }
  }
}