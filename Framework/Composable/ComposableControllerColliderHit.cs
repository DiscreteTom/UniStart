using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableControllerColliderHit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnControllerColliderHit is called.
    /// </summary>
    public CascadeEvent<ControllerColliderHit> @event { get; } = new CascadeEvent<ControllerColliderHit>();

    void OnControllerColliderHit(ControllerColliderHit arg0) {
      this.@event.Invoke(arg0);
    }
  }
}