using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableRenderObject : MonoBehaviour {
    /// <summary>
    /// Called every time when OnRenderObject is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnRenderObject() {
      this.@event.Invoke();
    }
  }
}