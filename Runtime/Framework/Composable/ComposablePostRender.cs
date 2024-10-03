using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePostRender : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPostRender is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnPostRender() {
      this.@event.Invoke();
    }
  }
}