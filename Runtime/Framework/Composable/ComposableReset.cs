using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableReset : MonoBehaviour {
    /// <summary>
    /// Called every time when Reset is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void Reset() {
      this.@event.Invoke();
    }
  }
}