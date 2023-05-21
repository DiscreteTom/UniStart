using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDrawGizmos : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDrawGizmos is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnDrawGizmos() {
      this.@event.Invoke();
    }
  }
}