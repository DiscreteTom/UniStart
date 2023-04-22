using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDrawGizmosSelected : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDrawGizmosSelected is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnDrawGizmosSelected() {
      this.@event.Invoke();
    }
  }
}