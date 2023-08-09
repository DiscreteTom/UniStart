using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public interface IStepListener {
    UnityAction AddListener<T>(IConvertible step, UnityAction action);
    UnityAction AddOnceListener<T>(IConvertible step, UnityAction action);
    UnityAction RemoveListener<T>(IConvertible step, UnityAction action);
    UnityAction RemoveOnceListener<T>(IConvertible step, UnityAction action);
    UnityAction<T> AddListener<T>(IConvertible step, UnityAction<T> action);
    UnityAction<T> AddOnceListener<T>(IConvertible step, UnityAction<T> action);
    UnityAction<T> RemoveOnceListener<T>(IConvertible step, UnityAction<T> action);
    UnityAction<T> RemoveListener<T>(IConvertible step, UnityAction<T> action);
  }

  public interface IStepInvoker {
    void Invoke<T>(T value);
  }

  public interface IStepExecutor : IStepListener, IStepInvoker { }

  public static class IStepExecutorExtension {
    public static void Invoke<T>(this IStepExecutor self) where T : new() => self.Invoke(new T());
  }
}
