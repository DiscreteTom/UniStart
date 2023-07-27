using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class Timer {
    public float duration { get; private set; }
    public float elapsed { get; private set; }
    public bool stopped { get; private set; }
    public AdvancedEvent onFinished { get; private set; }

    public float progress => Mathf.Clamp01(this.elapsed / this.duration);
    public bool finished => this.elapsed >= this.duration;

    public Timer(float duration) {
      this.duration = duration;
      this.elapsed = 0;
      this.stopped = false;
      this.onFinished = new AdvancedEvent();
    }

    public virtual void Update(float deltaTime) {
      if (this.stopped) return;

      this.elapsed += deltaTime;
      if (this.finished) {
        this.Stop();
        this.onFinished.Invoke();
      }
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
    public RepeatedTimer(float duration) : base(duration) { }

    public override void Update(float deltaTime) {
      base.Update(deltaTime);
      if (this.finished) {
        this.Reset();
      }
    }
  }
}