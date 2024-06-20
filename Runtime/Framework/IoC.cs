using System;
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// Get the `IEventBus`.
    /// </summary>
    public static IEventBus GetEventBus(this IIoCC ioc) => ioc.Get<IEventBus>();
    /// <summary>
    /// Get the `ICommandBus`.
    /// </summary>
    public static ICommandBus GetCommandBus(this IIoCC ioc) => ioc.Get<ICommandBus>();
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

    /// <summary>
    /// Register an `IEventBus`. If the `IEventBus` is not provided, a new instance of `EventBus` will be created.
    /// If `debug` is `true`, the provided `IEventBus` will be wrapped with `DebugEventBus` in editor mode.
    /// </summary>
    public static IEventBus AddEventBus(this IIoCC ioc, IEventBus eb = null, bool debug = false) => ioc.Add((debug && Application.isEditor) ? new DebugEventBus(eb ?? new EventBus()) : (eb ?? new EventBus()));
    /// <summary>
    /// Register an `ICommandBus`.
    /// If `debug` is `true`, the provided `ICommandBus` will be wrapped with `DebugCommandBus` in editor mode.
    /// </summary>
    public static ICommandBus AddCommandBus(this IIoCC ioc, ICommandBus cb, bool debug = false) => ioc.Add((debug && Application.isEditor) ? new DebugCommandBus(cb) : cb);
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