using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTransformChildrenChanged : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTransformChildrenChanged is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnTransformChildrenChanged() {
      this.@event.Invoke();
    }
  }
}