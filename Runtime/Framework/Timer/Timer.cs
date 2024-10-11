using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class Timer {
    public readonly float duration;
    public float elapsed { get; private set; } = 0;
    public bool stopped { get; private set; } = false;
    public readonly UniEvent onFinished = new();

    public float progress => Mathf.Clamp01(this.elapsed / this.duration);
    public bool finished => this.elapsed >= this.duration;

    public Timer(float duration, UnityAction cb = null, bool stop = false) {
      this.duration = duration;
      if (cb != null) this.onFinished.AddListener(cb);
      if (stop) this.Stop();
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

    public Timer Mount(IWatchable target) {
      target.AddListener(this.UpdateWithDelta);
      return this;
    }

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
    public RepeatedTimer(float duration, UnityAction cb = null, bool stop = false) : base(duration, cb, stop) { }

    public override void Update(float deltaTime) {
      base.Update(deltaTime);
      if (this.finished) {
        this.Reset();
      }
    }

    public new RepeatedTimer Mount(IWatchable target) {
      base.Mount(target);
      return this;
    }
  }
}