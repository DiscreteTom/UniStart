using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePostRender : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPostRender is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnPostRender() {
      this.@event.Invoke();
    }
  }
}