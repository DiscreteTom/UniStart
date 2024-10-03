using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableDrawGizmos : MonoBehaviour {
    /// <summary>
    /// Called every time when OnDrawGizmos is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnDrawGizmos() {
      this.@event.Invoke();
    }
  }
}