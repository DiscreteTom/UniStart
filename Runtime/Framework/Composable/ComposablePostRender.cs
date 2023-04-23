using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePostRender : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPostRender is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnPostRender() {
      this.@event.Invoke();
    }
  }
}