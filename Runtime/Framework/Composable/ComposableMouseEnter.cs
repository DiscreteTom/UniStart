using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseEnter : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseEnter is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnMouseEnter() {
      this.@event.Invoke();
    }
  }
}