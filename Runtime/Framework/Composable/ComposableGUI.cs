using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableGUI : MonoBehaviour {
    /// <summary>
    /// Called every time when OnGUI is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnGUI() {
      this.@event.Invoke();
    }
  }
}