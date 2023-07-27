using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class TimerManager {
    HashSet<Timer> timers;

    public TimerManager(IComposable mountTarget = null) {
      this.timers = new HashSet<Timer>();
      if (mountTarget != null) this.Mount(mountTarget);
    }

    public TimerManager Mount(IComposable target) {
      target.onUpdate.AddListener(() => this.Update(Time.deltaTime));
      return this;
    }

    public void Update(float deltaTime) {
      foreach (var t in this.timers) {
        t.Update(deltaTime);
      }
    }

    T AddTimer<T>(T t, UnityAction cb, IComposable mountTarget) where T : Timer {
      if (cb != null) t.onFinished.AddListener(cb);
      this.timers.Add(t);
      if (mountTarget != null) mountTarget.onDestroy.AddListener(() => this.Remove(t));
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