using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when Update is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void Update() {
      this.@event.Invoke();
    }
  }
}