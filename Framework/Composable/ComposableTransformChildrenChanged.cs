using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTransformChildrenChanged : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTransformChildrenChanged is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnTransformChildrenChanged() {
      this.@event.Invoke();
    }
  }
}