using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDrawGizmos : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDrawGizmos is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnDrawGizmos() {
      this.@event.Invoke();
    }
  }
}