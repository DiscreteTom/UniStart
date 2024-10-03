using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDrawGizmosSelected : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDrawGizmosSelected is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnDrawGizmosSelected() {
      this.@event.Invoke();
    }
  }
}