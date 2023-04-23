using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableTransformParentChanged : MonoBehaviour {
    /// <summary>
    /// Called every time when OnTransformParentChanged is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnTransformParentChanged() {
      this.@event.Invoke();
    }
  }
}