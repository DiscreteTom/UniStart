using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDisable : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDisable is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnDisable() {
      this.@event.Invoke();
    }
  }
}