using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableBecameVisible : MonoBehaviour {
    /// <summary>
    /// Called every time when OnBecameVisible is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnBecameVisible() {
      this.@event.Invoke();
    }
  }
}