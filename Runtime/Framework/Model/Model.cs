using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class Model : IModel {
    class ModelItem<T> {
      public T value;
      public AdvancedEvent<T> listeners;
    }

    Dictionary<Type, object> dict;

    public Model() {
      this.dict = new Dictionary<Type, object>();
    }

    public IModel Add<T>(T value) {
      this.dict.Add(typeof(T), new ModelItem<T>() {
        value = value,
        listeners = new AdvancedEvent<T>()
      });
      return this;
    }

    public T Get<T>() {
      return (this.dict[typeof(T)] as ModelItem<T>).value;
    }

    public IModel Commit<T>(T value) {
      var item = this.dict[typeof(T)] as ModelItem<T>;
      item.value = value;
      item.listeners.Invoke(value);
      return this;
    }

    public UnityAction AddListener<T>(UnityAction listener) => (this.dict[typeof(T)] as ModelItem<T>).listeners.AddListener(listener);
    public UnityAction<T> AddListener<T>(UnityAction<T> listener) => (this.dict[typeof(T)] as ModelItem<T>).listeners.AddListener(listener);
    public UnityAction AddOnceListener<T>(UnityAction listener) => (this.dict[typeof(T)] as ModelItem<T>).listeners.AddOnceListener(listener);
    public UnityAction<T> AddOnceListener<T>(UnityAction<T> listener) => (this.dict[typeof(T)] as ModelItem<T>).listeners.AddOnceListener(listener);
    public UnityAction RemoveListener<T>(UnityAction listener) => (this.dict[typeof(T)] as ModelItem<T>).listeners.RemoveListener(listener);
    public UnityAction<T> RemoveListener<T>(UnityAction<T> listener) => (this.dict[typeof(T)] as ModelItem<T>).listeners.RemoveListener(listener);
  }
}