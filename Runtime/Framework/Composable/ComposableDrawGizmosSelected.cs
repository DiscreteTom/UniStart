using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDrawGizmosSelected : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDrawGizmosSelected is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnDrawGizmosSelected() {
      this.@event.Invoke();
    }
  }
}