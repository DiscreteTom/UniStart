using System;
using System.Collections.Generic;

namespace DT.UniStart {
  /// <summary>
  /// IoC Container Interface.
  /// </summary>
  public interface IIoCC {
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
    T GetOrDefault<T>();
  }


  /// <summary>
  /// IoC Container.
  /// </summary>
  public class IoCC : IIoCC {
    Dictionary<Type, object> dict;

    public IoCC() {
      this.dict = new Dictionary<Type, object>();
    }

    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    public T Add<T>(T instance) {
      this.dict.Add(typeof(T), instance);
      return instance;
    }

    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public T Add<T>() where T : new() => this.Add<T>(new T());

    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => (T)this.dict[typeof(T)];

    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)`.
    /// </summary>
    public T GetOrDefault<T>() => (T)this.dict.GetOrDefault(typeof(T));
  }
}