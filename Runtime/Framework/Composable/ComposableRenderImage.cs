using UnityEngine;

namespace DT.UniStart.Composable {
  public class ComposableRenderImage : MonoBehaviour {
    /// <summary>
    /// Called every time when OnRenderImage is called.
    /// </summary>
    public AdvancedEvent<RenderTexture, RenderTexture> @event { get; } = new AdvancedEvent<RenderTexture, RenderTexture>();

    void OnRenderImage(RenderTexture arg0, RenderTexture arg1) {
      this.@event.Invoke(arg0, arg1);
    }
  }
}