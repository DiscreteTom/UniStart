using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableGUI : MonoBehaviour {
    /// <summary>
    /// Called every time when OnGUI is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnGUI() {
      this.@event.Invoke();
    }
  }
}