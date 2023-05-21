using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTransformParentChanged : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTransformParentChanged is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnTransformParentChanged() {
      this.@event.Invoke();
    }
  }
}