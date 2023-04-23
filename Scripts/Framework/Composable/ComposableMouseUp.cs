using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseUp : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseUp is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnMouseUp() {
      this.@event.Invoke();
    }
  }
}