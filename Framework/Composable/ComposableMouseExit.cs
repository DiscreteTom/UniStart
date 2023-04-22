using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableMouseExit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnMouseExit is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnMouseExit() {
      this.@event.Invoke();
    }
  }
}