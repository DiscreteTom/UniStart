using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePreRender : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPreRender is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnPreRender() {
      this.@event.Invoke();
    }
  }
}