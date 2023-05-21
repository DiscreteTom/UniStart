using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableAnimatorMove : MonoBehaviour {
    /// <summary>
    /// Called every time when OnAnimatorMove is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnAnimatorMove() {
      this.@event.Invoke();
    }
  }
}