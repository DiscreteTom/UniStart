using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableUpdate : MonoBehaviour {
    /// <summary>
    /// Called every time when Update is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void Update() {
      this.@event.Invoke();
    }
  }
}