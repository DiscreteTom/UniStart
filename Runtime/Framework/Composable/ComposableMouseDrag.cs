using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseDrag : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseDrag is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnMouseDrag() {
      this.@event.Invoke();
    }
  }
}