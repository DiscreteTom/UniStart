using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus<T> : IEventBus<T> {
    Dictionary<T, object> dict;

    public EventBus() {
      this.dict = new Dictionary<T, object>();
    }

    /// <summary>
    /// Get or create a new event of type E for the given key.
    /// </summary>
    E GetOrNew<E>(T key) where E : new() {
      if (this.dict.TryGetValue(key, out object o))
        return (E)o;

      var e = new E();
      this.dict.Add(key, e);
      return e;
    }

    /// <summary>
    /// Get the event of type E for the given key. Return null if it doesn't exist.
    /// </summary>
    E TryGet<E>(T key) where E : class {
      if (this.dict.TryGetValue(key, out object o))
        return (E)o;

      return null;
    }

    public UnityAction AddListener(T key, UnityAction action) => this.GetOrNew<AdvancedEvent>(key).AddListener(action);
    public UnityAction AddOnceListener(T key, UnityAction action) => this.GetOrNew<AdvancedEvent>(key).AddOnceListener(action);
    public UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action) => this.GetOrNew<AdvancedEvent<T0>>(key).AddListener(action);
    public UnityAction<T0> AddOnceListener<T0>(T key, UnityAction<T0> action) => this.GetOrNew<AdvancedEvent<T0>>(key).AddOnceListener(action);
    public UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action) => this.GetOrNew<AdvancedEvent<T0, T1>>(key).AddListener(action);
    public UnityAction<T0, T1> AddOnceListener<T0, T1>(T key, UnityAction<T0, T1> action) => this.GetOrNew<AdvancedEvent<T0, T1>>(key).AddOnceListener(action);
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) => this.GetOrNew<AdvancedEvent<T0, T1, T2>>(key).AddListener(action);
    public UnityAction<T0, T1, T2> AddOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) => this.GetOrNew<AdvancedEvent<T0, T1, T2>>(key).AddOnceListener(action);
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) => this.GetOrNew<AdvancedEvent<T0, T1, T2, T3>>(key).AddListener(action);
    public UnityAction<T0, T1, T2, T3> AddOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) => this.GetOrNew<AdvancedEvent<T0, T1, T2, T3>>(key).AddOnceListener(action);

    public UnityAction RemoveListener(T key, UnityAction action) {
      this.TryGet<AdvancedEvent>(key)?.RemoveListener(action);
      return action;
    }
    public UnityAction RemoveOnceListener(T key, UnityAction action) {
      this.TryGet<AdvancedEvent>(key)?.RemoveOnceListener(action);
      return action;
    }
    public UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action) {
      this.TryGet<AdvancedEvent<T0>>(key)?.RemoveListener(action);
      return action;
    }
    public UnityAction<T0> RemoveOnceListener<T0>(T key, UnityAction<T0> action) {
      this.TryGet<AdvancedEvent<T0>>(key)?.RemoveOnceListener(action);
      return action;
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      this.TryGet<AdvancedEvent<T0, T1>>(key)?.RemoveListener(action);
      return action;
    }
    public UnityAction<T0, T1> RemoveOnceListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      this.TryGet<AdvancedEvent<T0, T1>>(key)?.RemoveOnceListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      this.TryGet<AdvancedEvent<T0, T1, T2>>(key)?.RemoveListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2> RemoveOnceListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      this.TryGet<AdvancedEvent<T0, T1, T2>>(key)?.RemoveOnceListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      this.TryGet<AdvancedEvent<T0, T1, T2, T3>>(key)?.RemoveListener(action);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> RemoveOnceListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      this.TryGet<AdvancedEvent<T0, T1, T2, T3>>(key)?.RemoveOnceListener(action);
      return action;
    }

    public void Invoke(T key) => this.TryGet<AdvancedEvent>(key)?.Invoke();
    public void Invoke<T0>(T key, T0 arg0) => this.TryGet<AdvancedEvent<T0>>(key)?.Invoke(arg0);
    public void Invoke<T0, T1>(T key, T0 arg0, T1 arg1) => this.TryGet<AdvancedEvent<T0, T1>>(key)?.Invoke(arg0, arg1);
    public void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2) => this.TryGet<AdvancedEvent<T0, T1, T2>>(key)?.Invoke(arg0, arg1, arg2);
    public void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) => this.TryGet<AdvancedEvent<T0, T1, T2, T3>>(key)?.Invoke(arg0, arg1, arg2, arg3);
  }

  public class EventBus : EventBus<object>, IEventBus<object>, IEventBus { }
}