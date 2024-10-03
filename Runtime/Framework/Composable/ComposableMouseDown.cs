using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseDown : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseDown is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnMouseDown() {
      this.@event.Invoke();
    }
  }
}