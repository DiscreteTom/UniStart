using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableLateUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when LateUpdate is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void LateUpdate() {
      this.@event.Invoke();
    }
  }
}