using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseOver : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseOver is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnMouseOver() {
      this.@event.Invoke();
    }
  }
}