using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableRenderObject : MonoBehaviour {
    /// <summary>
    /// Called every time when OnRenderObject is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnRenderObject() {
      this.@event.Invoke();
    }
  }
}