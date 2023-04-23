using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableNextFixedUpdate : MonoBehaviour {
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void FixedUpdate() {
      this.@event.Invoke();
      this.@event.RemoveAllListeners();
    }
  }
}