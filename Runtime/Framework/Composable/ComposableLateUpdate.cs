using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableLateUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when LateUpdate is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void LateUpdate() {
      this.@event.Invoke();
    }
  }
}