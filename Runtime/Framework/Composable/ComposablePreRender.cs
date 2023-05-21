using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePreRender : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPreRender is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnPreRender() {
      this.@event.Invoke();
    }
  }
}