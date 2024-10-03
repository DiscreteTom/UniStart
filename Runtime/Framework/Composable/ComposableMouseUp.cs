using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseUp : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseUp is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnMouseUp() {
      this.@event.Invoke();
    }
  }
}