using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableAnimatorIK : MonoBehaviour {
    /// <summary>
    /// Called every time when OnAnimatorIK is called.
    /// </summary>
    public AdvancedEvent<int> @event { get; } = new AdvancedEvent<int>();

    void OnAnimatorIK(int arg0) {
      this.@event.Invoke(arg0);
    }
  }
}