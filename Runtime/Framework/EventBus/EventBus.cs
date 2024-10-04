using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus : IEventBus {
    readonly Dictionary<Type, object> dict = new();

    UniEvent<T> GetOrAdd<T>() => this.dict.GetOrAdd(typeof(T), () => new UniEvent<T>()) as UniEvent<T>;
    UniEvent<T> GetOrDefault<T>() => this.dict.GetOrDefault(typeof(T)) as UniEvent<T>;

    public virtual UnityAction AddListener<T>(UnityAction listener) => this.GetOrAdd<T>().AddListener(listener);
    public virtual UnityAction AddOnceListener<T>(UnityAction listener) => this.GetOrAdd<T>().AddOnceListener(listener);
    public virtual UnityAction RemoveListener<T>(UnityAction listener) => this.GetOrDefault<T>()?.RemoveListener(listener);
    public virtual UnityAction<T> AddListener<T>(UnityAction<T> listener) => this.GetOrAdd<T>().AddListener(listener);
    public virtual UnityAction<T> AddOnceListener<T>(UnityAction<T> listener) => this.GetOrAdd<T>().AddOnceListener(listener);
    public virtual UnityAction<T> RemoveListener<T>(UnityAction<T> listener) => this.GetOrDefault<T>()?.RemoveListener(listener);

    public virtual void Invoke<T>(T e) => this.GetOrDefault<T>()?.Invoke(e);
  }
}