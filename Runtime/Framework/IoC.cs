using System;
using System.Collections.Generic;

namespace DT.UniStart {
  /// <summary>
  /// Basic IoC Container Interface.
  /// </summary>
  public interface IBasicIoCC {
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    T Add<T>(T instance);

    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    T Add<T>() where T : new();

    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    T Get<T>();

    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    T TryGet<T>();
  }

  /// <summary>
  /// IoC Container Interface with Key.
  /// </summary>
  public interface IKeyedIoCC<K> {
    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    T Add<T>(K key, T instance);

    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    T Add<T>(K key) where T : new();

    /// <summary>
    /// Get the instance of a type by key.
    /// </summary>
    T Get<T>(K key);

    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    T TryGet<T>(K key);
  }

  /// <summary>
  /// IoC Container Interface which implements both `IBasicIoCC` and `IKeyedIoCC`.
  /// </summary>
  public interface IIoCC<K> : IBasicIoCC, IKeyedIoCC<K> { }

  /// <summary>
  /// IoC Container which implements both `IBasicIoCC` and `IKeyedIoCC`.
  /// </summary>
  public class IoCC<K> : IIoCC<K> {
    public Func<Type, K> adapter;
    Dictionary<K, object> dict;

    public IoCC(Func<Type, K> adapter) {
      this.adapter = adapter;
      this.dict = new Dictionary<K, object>();
    }

    /// <summary>
    /// Register a type with an existing instance and a key.
    /// </summary>
    public T Add<T>(K key, T instance) {
      this.dict.Add(key, instance);
      return instance;
    }

    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) {
      return this.Add(this.adapter.Invoke(typeof(T)), instance);
    }

    /// <summary>
    /// Register a type with a key, and auto create an instance.
    /// </summary>
    public T Add<T>(K key) where T : new() {
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
    public T Get<T>(K key) {
      return (T)this.dict[key];
    }

    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() {
      return this.Get<T>(this.adapter.Invoke(typeof(T)));
    }

    /// <summary>
    /// Try to get the instance of a type with a key.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T TryGet<T>(K key) {
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
      return this.TryGet<T>(this.adapter.Invoke(typeof(T)));
    }
  }

  /// <summary>
  /// IoC Container Interface with object as key.
  /// </summary>
  public interface IIoCC : IIoCC<object> { }
  /// <summary>
  /// IoC Container with object as key.
  /// </summary>
  public class IoCC : IoCC<object>, IIoCC {
    public IoCC() : base((type) => type) { }
  }

  /// <summary>
  /// IoC Container Interface with string as key.
  /// </summary>
  public interface IStringIoCC : IIoCC<string> { }
  /// <summary>
  /// IoC Container with string as key.
  /// </summary>
  public class StringIoCC : IoCC<string>, IStringIoCC {
    public StringIoCC() : base((type) => type.FullName) { }
  }
}