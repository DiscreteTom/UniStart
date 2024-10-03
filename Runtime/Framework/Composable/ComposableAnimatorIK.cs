using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableAnimatorIK : MonoBehaviour {
    /// <summary>
    /// Called every time when OnAnimatorIK is called.
    /// </summary>
    public UniEvent<int> @event { get; } = new UniEvent<int>();

    void OnAnimatorIK(int arg0) {
      this.@event.Invoke(arg0);
    }
  }
}