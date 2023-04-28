using System;
using System.Collections.Generic;

namespace DT.UniStart {

  /// <summary>
  /// IoC Container Interface.
  /// </summary>
  public interface IIoCC {
    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    T Add<T>(object key, T instance);

    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    T Add<T>(T instance);

    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    T Add<T>(object key) where T : new();

    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    T Add<T>() where T : new();

    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    T Get<T>(object key);

    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    T Get<T>();

    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    T TryGet<T>(object key);

    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    T TryGet<T>();
  }

  /// <summary>
  /// IoC Container.
  /// </summary>
  public class IoCC : IIoCC {
    Dictionary<object, object> dict;

    public IoCC() {
      this.dict = new Dictionary<object, object>();
    }

    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    public T Add<T>(object key, T instance) {
      this.dict.Add(key, instance);
      return instance;
    }

    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) {
      return this.Add(typeof(T), instance);
    }

    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    public T Add<T>(object key) where T : new() {
      return this.Add<T>(key, new T());
    }

    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() {
      return this.Add<T>(new T());
    }

    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    public T Get<T>(object key) {
      return (T)this.dict[key];
    }

    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() {
      return this.Get<T>(typeof(T));
    }

    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>(object key) {
      if (this.dict.TryGetValue(key, out object value)) {
        return (T)value;
      } else {
        return default(T);
      }
    }

    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>() {
      return this.TryGet<T>(typeof(T));
    }
  }
}