using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableControllerColliderHit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnControllerColliderHit is called.
    /// </summary>
    public UniEvent<ControllerColliderHit> @event { get; } = new UniEvent<ControllerColliderHit>();

    void OnControllerColliderHit(ControllerColliderHit arg0) {
      this.@event.Invoke(arg0);
    }
  }
}