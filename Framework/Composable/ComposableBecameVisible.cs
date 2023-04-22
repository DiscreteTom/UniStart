using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableBecameVisible : MonoBehaviour {
    /// <summary>
    /// Called every time when OnBecameVisible is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnBecameVisible() {
      this.@event.Invoke();
    }
  }
}