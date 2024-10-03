using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableValidate : MonoBehaviour {
    /// <summary>
    /// Called every time when OnValidate is called.
    /// </summary>
    public UniEvent @event { get; } = new UniEvent();

    void OnValidate() {
      this.@event.Invoke();
    }
  }
}