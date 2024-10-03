using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseUpAsButton : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseUpAsButton is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnMouseUpAsButton() {
      this.@event.Invoke();
    }
  }
}