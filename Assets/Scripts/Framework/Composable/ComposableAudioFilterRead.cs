using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableAudioFilterRead : MonoBehaviour {
    /// <summary>
    /// Called every time when OnAudioFilterRead is called.
    /// </summary>
    public CascadeEvent<float[], int> @event { get; } = new CascadeEvent<float[], int>();

    void OnAudioFilterRead(float[] arg0, int arg1) {
      this.@event.Invoke(arg0, arg1);
    }
  }
}