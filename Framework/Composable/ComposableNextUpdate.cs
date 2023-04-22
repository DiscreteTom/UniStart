using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableNextUpdate : MonoBehaviour {
    /// <summary>
    /// Called once on the next Update.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void Update() {
      this.@event.Invoke();
      this.@event.RemoveAllListeners();
    }
  }
}