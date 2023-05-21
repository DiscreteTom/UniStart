using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableWillRenderObject : MonoBehaviour {
    /// <summary>
    /// Called every time when OnWillRenderObject is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnWillRenderObject() {
      this.@event.Invoke();
    }
  }
}