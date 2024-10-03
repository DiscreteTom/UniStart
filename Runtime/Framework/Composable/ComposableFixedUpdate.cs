using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableFixedUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when FixedUpdate is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void FixedUpdate() {
      this.@event.Invoke();
    }
  }
}