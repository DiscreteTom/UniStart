using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableValidate : MonoBehaviour {
    /// <summary>
    /// Called every time when OnValidate is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void OnValidate() {
      this.@event.Invoke();
    }
  }
}