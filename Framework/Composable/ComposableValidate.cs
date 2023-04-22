using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableValidate : MonoBehaviour {
    /// <summary>
    /// Called every time when OnValidate is called.
    /// </summary>
    public CascadeEvent @event { get; } = new CascadeEvent();

    void OnValidate() {
      this.@event.Invoke();
    }
  }
}