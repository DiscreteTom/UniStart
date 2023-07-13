using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus : IEventBus {
    Dictionary<Type, object> dict;

    public EventBus() {
      this.dict = new Dictionary<Type, object>();
    }

    public UnityAction AddListener<T>(UnityAction listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener);
    public UnityAction AddListener<T>(UnityAction listener, out UnityAction named) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener, out named);
    public UnityAction<T> AddListener<T>(UnityAction<T> listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener);
    public UnityAction<T> AddListener<T>(UnityAction<T> listener, out UnityAction<T> named) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener, out named);
    public UnityAction AddOnceListener<T>(UnityAction listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    public UnityAction AddOnceListener<T>(UnityAction listener, out UnityAction named) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener, out named);
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> listener, out UnityAction<T> named) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener, out named);
    public UnityAction RemoveListener<T>(UnityAction listener) => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);
    public UnityAction RemoveListener<T>(UnityAction listener, out UnityAction named) {
      named = null;
      return (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener, out named);
    }
    public UnityAction<T> RemoveListener<T>(UnityAction<T> listener) => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);
    public UnityAction<T> RemoveListener<T>(UnityAction<T> listener, out UnityAction<T> named) {
      named = null;
      return (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener, out named);
    }

    public void Invoke<T>(T e) => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.Invoke(e);
    public void Invoke<T>() where T : new() => this.Invoke(new T());
  }
}