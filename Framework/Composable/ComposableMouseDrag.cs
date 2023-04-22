using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseDrag : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseDrag is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnMouseDrag() {
      this.@event.Invoke();
    }
  }
}