using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableJointBreak2D : MonoBehaviour {
    /// <summary>
    /// Called every time when OnJointBreak2D is called.
    /// </summary>
    public UniEvent<Joint2D> @event { get; } = new UniEvent<Joint2D>();

    void OnJointBreak2D(Joint2D arg0) {
      this.@event.Invoke(arg0);
    }
  }
}