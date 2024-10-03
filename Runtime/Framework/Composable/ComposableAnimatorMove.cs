using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableAnimatorMove : MonoBehaviour {
    /// <summary>
    /// Called every time when OnAnimatorMove is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnAnimatorMove() {
      this.@event.Invoke();
    }
  }
}