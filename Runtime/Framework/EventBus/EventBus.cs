using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus : IEventBus {
    Dictionary<Type, object> dict;

    public EventBus() {
      this.dict = new Dictionary<Type, object>();
    }

    public UnityAction AddListener<T>(UnityAction listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener);
    public UnityAction<T> AddListener<T>(UnityAction<T> listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener);
    public UnityAction AddOnceListener<T>(UnityAction listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    public UnityAction RemoveListener<T>(UnityAction listener) where T : IEvent => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);
    public UnityAction<T> RemoveListener<T>(UnityAction<T> listener) where T : IEvent => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);

    public void Invoke<T>(T e) where T : IEvent => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.Invoke(e);
  }
}