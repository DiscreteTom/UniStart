using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableBecameInvisible : MonoBehaviour {
    /// <summary>
    /// Called every time when OnBecameInvisible is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnBecameInvisible() {
      this.@event.Invoke();
    }
  }
}