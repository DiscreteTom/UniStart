using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableWillRenderObject : MonoBehaviour {
    /// <summary>
    /// Called every time when OnWillRenderObject is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnWillRenderObject() {
      this.@event.Invoke();
    }
  }
}