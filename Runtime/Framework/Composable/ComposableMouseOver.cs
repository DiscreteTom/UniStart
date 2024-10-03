using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseOver : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseOver is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnMouseOver() {
      this.@event.Invoke();
    }
  }
}