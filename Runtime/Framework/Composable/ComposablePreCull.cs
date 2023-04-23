using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePreCull : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPreCull is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnPreCull() {
      this.@event.Invoke();
    }
  }
}