using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableBecameInvisible : MonoBehaviour {
    /// <summary>
    /// Called every time when OnBecameInvisible is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnBecameInvisible() {
      this.@event.Invoke();
    }
  }
}