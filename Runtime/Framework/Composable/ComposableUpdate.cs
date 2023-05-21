using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when Update is called.
    /// </summary>
    public AdvancedEvent @event { get; } = new AdvancedEvent();

    void Update() {
      this.@event.Invoke();
    }
  }
}