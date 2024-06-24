using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class Timer {
    public readonly float duration;
    public float elapsed { get; private set; } = 0;
    public bool stopped { get; private set; } = false;
    public readonly AdvancedEvent onFinished = new();

    public float progress => Mathf.Clamp01(this.elapsed / this.duration);
    public bool finished => this.elapsed >= this.duration;

    public Timer(float duration, UnityAction cb = null) {
      this.duration = duration;
      if (cb != null) this.onFinished.AddListener(cb);
    }

    public virtual void Update(float deltaTime) {
      if (this.stopped) return;

      this.elapsed += deltaTime;
      if (this.finished) {
        this.Stop();
        this.onFinished.Invoke();
      }
    }

    public void UpdateWithDelta() => this.Update(Time.deltaTime);

    public void Mount(IWatchable target) => target.AddListener(this.UpdateWithDelta);

    public void Stop() {
      this.stopped = true;
    }

    public void Start() {
      this.stopped = false;
    }

    public void Reset() {
      this.elapsed = 0;
      this.stopped = false;
    }
  }

  public class RepeatedTimer : Timer {
    public RepeatedTimer(float duration, UnityAction cb = null) : base(duration, cb) { }

    public override void Update(float deltaTime) {
      base.Update(deltaTime);
      if (this.finished) {
        this.Reset();
      }
    }
  }
}