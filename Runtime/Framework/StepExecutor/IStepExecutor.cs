using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public interface IStepListener {
    UnityAction AddListener<T>(IConvertible step, UnityAction action);
    UnityAction AddOnceListener<T>(IConvertible step, UnityAction action);
    UnityAction RemoveListener<T>(IConvertible step, UnityAction action);
    UnityAction<T> AddListener<T>(IConvertible step, UnityAction<T> action);
    UnityAction<T> AddOnceListener<T>(IConvertible step, UnityAction<T> action);
    UnityAction<T> RemoveListener<T>(IConvertible step, UnityAction<T> action);
  }

  public static class IStepListenerExtension {
    public static UnityAction AddListener<T>(this IStepListener self, T step, UnityAction action) where T : Enum => self.AddListener(step, action);
    public static UnityAction AddOnceListener<T>(this IStepListener self, T step, UnityAction action) where T : Enum => self.AddOnceListener(step, action);
    public static UnityAction RemoveListener<T>(this IStepListener self, T step, UnityAction action) where T : Enum => self.RemoveListener(step, action);
    public static UnityAction<T> AddListener<T>(this IStepListener self, T step, UnityAction<T> action) where T : Enum => self.AddListener(step, action);
    public static UnityAction<T> AddOnceListener<T>(this IStepListener self, T step, UnityAction<T> action) where T : Enum => self.AddOnceListener(step, action);
    public static UnityAction<T> RemoveListener<T>(this IStepListener self, T step, UnityAction<T> action) where T : Enum => self.RemoveListener(step, action);
  }

  public interface IStepInvoker {
    void Invoke<T>(T value);
  }

  public interface IStepExecutor : IStepListener, IStepInvoker { }

  public static class IStepExecutorExtension {
    public static void Invoke<T>(this IStepExecutor self) where T : new() => self.Invoke(new T());
  }
}
