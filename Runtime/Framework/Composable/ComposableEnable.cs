using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableEnable : MonoBehaviour {
    /// <summary>
    /// Called every time when OnEnable is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnEnable() {
      this.@event.Invoke();
    }
  }
}