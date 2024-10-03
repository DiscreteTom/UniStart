using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableApplicationQuit : MonoBehaviour {
    /// <summary>
    /// Called every time when OnApplicationQuit is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnApplicationQuit() {
      this.@event.Invoke();
    }
  }
}