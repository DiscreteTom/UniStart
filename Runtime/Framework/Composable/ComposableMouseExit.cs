using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseExit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseExit is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnMouseExit() {
      this.@event.Invoke();
    }
  }
}