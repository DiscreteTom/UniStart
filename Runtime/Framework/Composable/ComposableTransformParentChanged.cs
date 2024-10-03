using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTransformParentChanged : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTransformParentChanged is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnTransformParentChanged() {
      this.@event.Invoke();
    }
  }
}