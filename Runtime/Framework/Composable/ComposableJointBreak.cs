using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableJointBreak : MonoBehaviour {
    /// <summary>
    /// Called every time when OnJointBreak is called.
    /// </summary>
    public AdvancedEvent<float> @event { get; } = new AdvancedEvent<float>();

    void OnJointBreak(float arg0) {
      this.@event.Invoke(arg0);
    }
  }
}