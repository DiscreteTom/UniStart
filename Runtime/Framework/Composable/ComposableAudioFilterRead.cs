using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableAudioFilterRead : MonoBehaviour {
    /// <summary>
    /// Called every time when OnAudioFilterRead is called.
    /// </summary>
    public UniEvent<float[], int> @event { get; } = new UniEvent<float[], int>();

    void OnAudioFilterRead(float[] arg0, int arg1) {
      this.@event.Invoke(arg0, arg1);
    }
  }
}