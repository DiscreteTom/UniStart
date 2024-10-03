using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseEnter : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseEnter is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnMouseEnter() {
      this.@event.Invoke();
    }
  }
}