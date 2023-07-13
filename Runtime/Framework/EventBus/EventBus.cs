using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus : IEventBus {
    Dictionary<Type, object> dict;

    public EventBus() {
      this.dict = new Dictionary<Type, object>();
    }

    public UnityAction AddListener<T>(UnityAction listener) {
      return (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener);
    }
    public UnityAction<T> AddListener<T>(UnityAction<T> listener) {
      return (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener);
    }
    public UnityAction AddOnceListener<T>(UnityAction listener) {
      return (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    }
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> listener) {
      return (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    }

    public UnityAction RemoveListener<T>(UnityAction listener) {
      (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);
      return listener;
    }
    public UnityAction<T> RemoveListener<T>(UnityAction<T> listener) {
      (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);
      return listener;
    }
    public UnityAction RemoveOnceListener<T>(UnityAction listener) {
      (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveOnceListener(listener);
      return listener;
    }
    public UnityAction<T> RemoveOnceListener<T>(UnityAction<T> listener) {
      (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveOnceListener(listener);
      return listener;
    }

    public void Invoke<T>(T e) {
      (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.Invoke(e);
    }
  }
}