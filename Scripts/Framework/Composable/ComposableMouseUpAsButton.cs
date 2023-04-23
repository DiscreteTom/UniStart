using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseUpAsButton : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseUpAsButton is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnMouseUpAsButton() {
      this.@event.Invoke();
    }
  }
}