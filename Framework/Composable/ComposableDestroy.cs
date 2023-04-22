using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDestroy : MonoBehaviour {
    /// <summary>
    /// Called when the game object is destroyed.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnDestroy() {
      this.@event.Invoke();
    }
  }
}