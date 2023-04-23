using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableApplicationQuit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnApplicationQuit is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnApplicationQuit() {
      this.@event.Invoke();
    }
  }
}