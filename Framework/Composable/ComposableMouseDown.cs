using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseDown : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseDown is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnMouseDown() {
      this.@event.Invoke();
    }
  }
}