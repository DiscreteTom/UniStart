using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableFixedUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when FixedUpdate is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void FixedUpdate() {
      this.@event.Invoke();
    }
  }
}