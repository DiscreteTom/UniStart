using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableWillRenderObject : MonoBehaviour {
    /// <summary>
    /// Called every time when OnWillRenderObject is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnWillRenderObject() {
      this.@event.Invoke();
    }
  }
}