using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// A wrapper around an IEventBus which will always accept actions with no params.
  /// </summary>
  public class CompatibleEventBus<Bus, T> : IEventBus<T> where Bus : IEventBus<T> {
    Dictionary<T, AdvancedEvent> compatibleEvents;
    Bus bus;

    public CompatibleEventBus(Bus eventBus) {
      this.bus = eventBus;
      this.compatibleEvents = new Dictionary<T, AdvancedEvent>();
    }

    public UnityAction AddListener(T key, UnityAction action) {
      if (this.compatibleEvents.TryGetValue(key, out AdvancedEvent advancedEvent))
        return advancedEvent.AddListener(action);

      advancedEvent = new AdvancedEvent();
      advancedEvent.AddListener(action);
      this.compatibleEvents.Add(key, advancedEvent);
      return action;
    }
    public UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action) {
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      return this.bus.AddListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      return this.bus.AddListener(key, action);
    }

    public UnityAction RemoveListener(T key, UnityAction action) {
      if (this.compatibleEvents.TryGetValue(key, out AdvancedEvent advancedEvent))
        return advancedEvent.RemoveListener(action);

      return action;
    }
    public UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action) {
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      return this.bus.RemoveListener(key, action);
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      return this.bus.RemoveListener(key, action);
    }

    public void Invoke(T key) {
      if (this.compatibleEvents.TryGetValue(key, out AdvancedEvent advancedEvent))
        advancedEvent.Invoke();
    }
    public void Invoke<T0>(T key, T0 arg0) {
      this.Invoke(key);
      this.bus.Invoke(key, arg0);
    }
    public void Invoke<T0, T1>(T key, T0 arg0, T1 arg1) {
      this.Invoke(key);
      this.bus.Invoke(key, arg0, arg1);
    }
    public void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2) {
      this.Invoke(key);
      this.bus.Invoke(key, arg0, arg1, arg2);
    }
    public void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      this.Invoke(key);
      this.bus.Invoke(key, arg0, arg1, arg2, arg3);
    }
  }

  public class CompatibleEventBus<T> : CompatibleEventBus<EventBus<T>, T>, IEventBus<T> {
    public CompatibleEventBus() : base(new EventBus<T>()) { }
  }

  public class CompatibleEventBus : CompatibleEventBus<object>, IEventBus<object>, IEventBus { }
}