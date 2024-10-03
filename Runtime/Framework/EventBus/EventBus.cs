using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus : IEventBus {
    readonly Dictionary<Type, object> dict = new();

    public virtual UnityAction AddListener<T>(UnityAction listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new UniEvent<T>()) as UniEvent<T>).AddListener(listener);
    public virtual UnityAction RemoveListener<T>(UnityAction listener) where T : IEvent => (this.dict.GetOrDefault(typeof(T)) as UniEvent<T>)?.RemoveListener(listener);
    public virtual UnityAction AddOnceListener<T>(UnityAction listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new UniEvent<T>()) as UniEvent<T>).AddOnceListener(listener);
    public virtual UnityAction<T> AddListener<T>(UnityAction<T> listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new UniEvent<T>()) as UniEvent<T>).AddListener(listener);
    public virtual UnityAction<T> RemoveListener<T>(UnityAction<T> listener) where T : IEvent => (this.dict.GetOrDefault(typeof(T)) as UniEvent<T>)?.RemoveListener(listener);
    public virtual UnityAction<T> AddOnceListener<T>(UnityAction<T> listener) where T : IEvent => (this.dict.GetOrAdd(typeof(T), () => new UniEvent<T>()) as UniEvent<T>).AddOnceListener(listener);

    public virtual void Invoke<T>(T e) where T : IEvent => (this.dict.GetOrDefault(typeof(T)) as UniEvent<T>)?.Invoke(e);
  }
}