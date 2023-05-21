using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableGUI : MonoBehaviour {
    /// <summary>
    /// Called every time when OnGUI is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnGUI() {
      this.@event.Invoke();
    }
  }
}