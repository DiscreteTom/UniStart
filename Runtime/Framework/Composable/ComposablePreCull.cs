using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePreCull : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPreCull is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnPreCull() {
      this.@event.Invoke();
    }
  }
}