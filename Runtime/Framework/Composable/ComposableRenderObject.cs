using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableRenderObject : MonoBehaviour {
    /// <summary>
    /// Called every time when OnRenderObject is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnRenderObject() {
      this.@event.Invoke();
    }
  }
}