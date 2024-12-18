using System;
using System.Collections.Generic;
using UnityEngine;

namespace DT.UniStart {
  /// <summary>
  /// Readonly IoC Container Interface.
  /// </summary>
  public interface IReadonlyIoCC {
    /// <summary>
    /// Get the instance of a type.
    /// </summary>
    T Get<T>();

    bool TryGet<T>(out T instance);
  }

  public static class IReadonlyIoCExtension {
    public static bool Contains<T>(this IReadonlyIoCC ioc) => ioc.TryGet<T>(out var _);

    /// <summary>
    /// Try to get the instance of a type.
    /// If the type is not registered, return `default(T)` which is usually `null`.
    /// </summary>
    public static T GetOrDefault<T>(this IReadonlyIoCC ioc) => ioc.TryGet<T>(out var instance) ? instance : default;

    /// <summary>
    /// Get the registered `IEventBus`.
    /// </summary>
    public static IEventBus GetEventBus(this IReadonlyIoCC ioc) => ioc.Get<IEventBus>();
    /// <summary>
    /// Get the registered `ICommandBus`.
    /// </summary>
    public static ICommandBus<Ctx> GetCommandBus<Ctx>(this IReadonlyIoCC ioc) => ioc.Get<ICommandBus<Ctx>>();
    /// <summary>
    /// Get the registered `IStepExecutor` with no context.
    /// </summary>
    public static IStepExecutor<S> GetStepExecutor<S>(this IReadonlyIoCC ioc) where S : IConvertible => ioc.Get<IStepExecutor<S>>();
    /// <summary>
    /// Get the registered `IStepExecutor` with context `T`.
    /// </summary>
    public static IStepExecutor<S, T> GetStepExecutor<S, T>(this IReadonlyIoCC ioc) where S : IConvertible => ioc.Get<IStepExecutor<S, T>>();
  }

  /// <summary>
  /// IoC Container Interface.
  /// </summary>
  public interface IIoCC : IReadonlyIoCC {
    /// <summary>
    /// Register a type with an existing instance.
    /// </summary>
    T Add<T>(T instance);
  }

  public static class IIoCCExtension {
    /// <summary>
    /// Register a type with a new instance.
    /// </summary>
    public static T Add<T>(this IIoCC ioc) where T : new() => ioc.Add(new T());

    /// <summary>
    /// Register an `IEventBus`. If the `IEventBus` is not provided, a new instance of `EventBus` will be created.
    /// If `debug` is `true`, the provided `IEventBus` will be wrapped with `DebugEventBus` in editor mode.
    /// </summary>
    public static IEventBus AddEventBus(this IIoCC ioc, IEventBus eb = null, bool debug = false) {
      eb ??= new EventBus();
      return ioc.Add((debug && Application.isEditor) ? new DebugEventBus(eb) : eb);
    }

    /// <summary>
    /// Register an `ICommandBus` with the provided context.
    /// If `debug` is `true`, the provided `ICommandBus` will be wrapped with `DebugCommandBus` in editor mode.
    /// </summary>
    public static ICommandBus<Ctx> AddCommandBus<Ctx>(this IIoCC ioc, Ctx ctx, bool debug = false) {
      var cb = new CommandBus<Ctx>(ctx);
      return ioc.Add<ICommandBus<Ctx>>((debug && Application.isEditor) ? new DebugCommandBus<Ctx>(cb) : cb);
    }

    /// <summary>
    /// Register an `ICommandBus` with the provided command bus.
    /// If `debug` is `true`, the provided `ICommandBus` will be wrapped with `DebugCommandBus` in editor mode.
    /// </summary>
    public static ICommandBus<Ctx> AddICommandBus<Ctx>(this IIoCC ioc, ICommandBus<Ctx> cb, bool debug = false) => ioc.Add((debug && Application.isEditor) ? new DebugCommandBus<Ctx>(cb) : cb);

    /// <summary>
    /// Register an `IStepExecutor`. If the `IStepExecutor` is not provided, a new instance of `StepExecutor` will be created.
    /// If `debug` is `true`, the provided `IStepExecutor` will be wrapped with `DebugStepExecutor` in editor mode.
    /// </summary>
    public static IStepExecutor<S> AddStepExecutor<S>(this IIoCC ioc, IStepExecutor<S> exe = null, bool debug = false) where S : IConvertible {
      exe ??= new StepExecutor<S>();
      return ioc.Add((debug && Application.isEditor) ? new DebugStepExecutor<S>(exe) : exe);
    }

    /// <summary>
    /// Register an `IStepExecutor`. If the `IStepExecutor` is not provided, a new instance of `StepExecutor` will be created.
    /// If `debug` is `true`, the provided `IStepExecutor` will be wrapped with `DebugStepExecutor` in editor mode.
    /// </summary>
    public static IStepExecutor<S, T> AddStepExecutor<S, T>(this IIoCC ioc, IStepExecutor<S, T> exe = null, bool debug = false) where S : IConvertible {
      exe ??= new StepExecutor<S, T>();
      return ioc.Add((debug && Application.isEditor) ? new DebugStepExecutor<S, T>(exe) : exe);
    }
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
#if UNITY_EDITOR
      if (this.dict.ContainsKey(typeof(T))) throw new Exception($"Type {typeof(T)} is already registered!");
      if (instance == null) Debug.LogWarning($"Type {typeof(T)} is registered with a null instance!");
#endif
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