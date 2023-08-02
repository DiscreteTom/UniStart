using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  // TODO: composable behaviour.Watch for IStepExecutor
  // TODO: InterceptStepExecutor, DebugStepExecutor
  public interface IStepExecutor {
    UnityAction AddListener<T>(IConvertible step, UnityAction action);
    UnityAction RemoveListener<T>(IConvertible step, UnityAction action);
    UnityAction<T> AddListener<T>(IConvertible step, UnityAction<T> action);
    UnityAction<T> RemoveListener<T>(IConvertible step, UnityAction<T> action);
    void Invoke<T>(T value);
  }

  public static class IStepExecutorExtension {
    // TODO: echoed Add/Remove Listener, once listener
    public static void Invoke<T>(this IStepExecutor self) where T : new() => self.Invoke(new T());
  }

  public class StepExecutor : IStepExecutor {
    Dictionary<Type, SortedList<int, object>> actions;

    public StepExecutor() {
      this.actions = new Dictionary<Type, SortedList<int, object>>();
    }

    public UnityAction AddListener<T>(IConvertible step, UnityAction action) {
      return (this.actions.GetOrAddNew(typeof(T)).GetOrAdd((int)step, () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(action);
    }
    public UnityAction RemoveListener<T>(IConvertible step, UnityAction action) {
      (this.actions.GetOrAddNew(typeof(T)).GetOrDefault((int)step) as AdvancedEvent<T>)?.RemoveListener(action);
      return action;
    }
    public UnityAction<T> AddListener<T>(IConvertible step, UnityAction<T> action) {
      return (this.actions.GetOrAddNew(typeof(T)).GetOrAdd((int)step, () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(action);
    }
    public UnityAction<T> RemoveListener<T>(IConvertible step, UnityAction<T> action) {
      (this.actions.GetOrAddNew(typeof(T)).GetOrDefault((int)step) as AdvancedEvent<T>)?.RemoveListener(action);
      return action;
    }

    public void Invoke<T>(T value) {
      this.actions.GetOrDefault(typeof(T))?.Values.ForEach((action) => {
        (action as AdvancedEvent<T>)?.Invoke(value);
      });
    }
  }
}
