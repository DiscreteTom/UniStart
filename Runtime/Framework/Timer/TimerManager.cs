using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class TimerManager {
    readonly HashSet<Timer> timers = new();

    public TimerManager(IComposable mountTarget = null) {
      if (mountTarget != null) this.Mount(mountTarget);
    }

    public TimerManager Mount(IComposable target) {
      target.onUpdate.AddListener(this.UpdateWithDelta);
      return this;
    }

    public TimerManager Unmount(IComposable target) {
      target.onUpdate.RemoveListener(this.UpdateWithDelta);
      return this;
    }

    public void UpdateWithDelta() {
      this.Update(Time.deltaTime);
    }

    public virtual void Update(float deltaTime) => this.timers.ForEach(t => t.Update(deltaTime));

    T AddTimer<T>(T t, UnityAction cb, IComposable mountTarget) where T : Timer {
      if (cb != null) t.onFinished.AddListener(cb);
      this.timers.Add(t);
      mountTarget?.onDestroy.AddListener(() => this.Remove(t));
      return t;
    }

    public Timer Add(IComposable mountTarget, float duration, UnityAction cb = null) => this.AddTimer(new Timer(duration), cb, mountTarget);
    public Timer Add(float duration, UnityAction cb = null) => this.Add(null, duration, cb);
    public RepeatedTimer AddRepeated(IComposable mountTarget, float duration, UnityAction cb = null) => this.AddTimer(new RepeatedTimer(duration), cb, mountTarget);
    public RepeatedTimer AddRepeated(float duration, UnityAction cb = null) => this.AddRepeated(null, duration, cb);

    public T Remove<T>(T t) where T : Timer {
      this.timers.Remove(t);
      return t;
    }

    public void Clear() {
      this.timers.Clear();
    }
  }
}