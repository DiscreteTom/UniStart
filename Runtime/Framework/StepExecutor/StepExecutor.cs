using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {

  public class StepExecutor : IStepExecutor {
    readonly Dictionary<Type, SortedList<int, object>> actions;

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
    public UnityAction AddOnceListener<T>(IConvertible step, UnityAction action) {
      return (this.actions.GetOrAddNew(typeof(T)).GetOrAdd((int)step, () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(action);
    }
    public UnityAction RemoveOnceListener<T>(IConvertible step, UnityAction action) {
      (this.actions.GetOrAddNew(typeof(T)).GetOrDefault((int)step) as AdvancedEvent<T>)?.RemoveOnceListener(action);
      return action;
    }
    public UnityAction<T> AddListener<T>(IConvertible step, UnityAction<T> action) {
      return (this.actions.GetOrAddNew(typeof(T)).GetOrAdd((int)step, () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddListener(action);
    }
    public UnityAction<T> RemoveListener<T>(IConvertible step, UnityAction<T> action) {
      (this.actions.GetOrAddNew(typeof(T)).GetOrDefault((int)step) as AdvancedEvent<T>)?.RemoveListener(action);
      return action;
    }
    public UnityAction<T> AddOnceListener<T>(IConvertible step, UnityAction<T> action) {
      return (this.actions.GetOrAddNew(typeof(T)).GetOrAdd((int)step, () => new AdvancedEvent<T>()) as AdvancedEvent<T>).AddOnceListener(action);
    }
    public UnityAction<T> RemoveOnceListener<T>(IConvertible step, UnityAction<T> action) {
      (this.actions.GetOrAddNew(typeof(T)).GetOrDefault((int)step) as AdvancedEvent<T>)?.RemoveOnceListener(action);
      return action;
    }

    public void Invoke<T>(T value) {
      this.actions.GetOrDefault(typeof(T))?.Values.ForEach((action) => {
        (action as AdvancedEvent<T>)?.Invoke(value);
      });
    }
  }
}
