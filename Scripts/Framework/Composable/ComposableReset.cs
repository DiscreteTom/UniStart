using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableReset : MonoBehaviour {
    /// <summary>
    /// Called every time when Reset is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void Reset() {
      this.@event.Invoke();
    }
  }
}