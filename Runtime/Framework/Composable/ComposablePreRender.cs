using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposablePreRender : MonoBehaviour {
    /// <summary>
    /// Called every time when OnPreRender is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnPreRender() {
      this.@event.Invoke();
    }
  }
}