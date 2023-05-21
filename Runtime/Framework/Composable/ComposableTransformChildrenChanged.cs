using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTransformChildrenChanged : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTransformChildrenChanged is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnTransformChildrenChanged() {
      this.@event.Invoke();
    }
  }
}