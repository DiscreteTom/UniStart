using System;
using System.Collections.Generic;

namespace DT.UniStart {
  /// <summary>
  /// Readonly IoC Container Interface.
  /// </summary>
  public interface IReadonlyIoC {
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    T Get<T>();

    bool TryGet<T>(out T instance);
  }

  public static class IReadonlyIoCExtension {
    public static bool Contains<T>(this IIoCC ioc) => ioc.TryGet<T>(out var _);

    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)` which is usually `null`.
    /// </summary>
    public static T GetOrDefault<T>(this IIoCC ioc) => ioc.TryGet<T>(out var instance) ? instance : default;
  }

  /// <summary>
  /// IoC Container Interface.
  /// </summary>
  public interface IIoCC : IReadonlyIoC {
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    T Add<T>(T instance);
  }

  public static class IIoCCExtension {
    /// <summary>
    /// Register a type and auto create an instance.
    /// </summary>
    public static T Add<T>(this IIoCC ioc) where T : new() => ioc.Add(new T());
  }


  /// <summary>
  /// IoC Container.
  /// </summary>
  public class IoCC : IIoCC {
    readonly Dictionary<Type, object> dict;

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
    /// Get the instance of a type.
    /// </summary>
    public T Get<T>() => (T)this.dict[typeof(T)];

    public bool TryGet<T>(out T instance) {
      var res = this.dict.TryGetValue(typeof(T), out var obj);
      instance = (T)obj;
      return res;
    }
  }
}