using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableEnable : MonoBehaviour {
    /// <summary>
    /// Called every time when OnEnable is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnEnable() {
      this.@event.Invoke();
    }
  }
}