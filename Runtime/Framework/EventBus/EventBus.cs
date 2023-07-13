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
    public UnityAction AddListener<T>(out UnityAction named, UnityAction listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(out named, listener);
    public UnityAction<T> AddListener<T>(UnityAction<T> listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(listener);
    public UnityAction<T> AddListener<T>(out UnityAction<T> named, UnityAction<T> listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(out named, listener);
    public UnityAction AddOnceListener<T>(UnityAction listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    public UnityAction AddOnceListener<T>(out UnityAction named, UnityAction listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(out named, listener);
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(listener);
    public UnityAction<T> AddOnceListener<T>(out UnityAction<T> named, UnityAction<T> listener) => (this.dict.GetOrAdd(typeof(T), () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(out named, listener);
    public UnityAction RemoveListener<T>(UnityAction listener) => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);
    public UnityAction RemoveListener<T>(out UnityAction named, UnityAction listener) {
      named = null;
      return (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(out named, listener);
    }
    public UnityAction<T> RemoveListener<T>(UnityAction<T> listener) => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(listener);
    public UnityAction<T> RemoveListener<T>(out UnityAction<T> named, UnityAction<T> listener) {
      named = null;
      return (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.RemoveListener(out named, listener);
    }

    public void Invoke<T>(T e) => (this.dict.GetOrDefault(typeof(T)) as AdvancedEvent<T>)?.Invoke(e);
    public void Invoke<T>() where T : new() => this.Invoke(new T());
  }
}