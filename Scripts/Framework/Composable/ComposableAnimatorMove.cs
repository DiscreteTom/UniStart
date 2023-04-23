using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableAnimatorMove : MonoBehaviour {
    /// <summary>
    /// Called every time when OnAnimatorMove is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnAnimatorMove() {
      this.@event.Invoke();
    }
  }
}