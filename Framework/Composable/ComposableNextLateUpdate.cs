using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableNextLateUpdate : MonoBehaviour {
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void LateUpdate() {
      this.@event.Invoke();
      this.@event.RemoveAllListeners();
    }
  }
}