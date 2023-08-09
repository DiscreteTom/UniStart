using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  [Flags]
  public enum InterceptStepExecutorMode {
    None = 0,
    AddListener = 1,
    RemoveListener = 2,
    Invoke = 4,
    All = AddListener | RemoveListener | Invoke
  }

  /// <summary>
  /// InterceptStepExecutor is a wrapper around an IStepExecutor which proxy all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class InterceptStepExecutor : IStepExecutor {
    protected IStepExecutor exe { get; private set; }
    protected InterceptStepExecutorMode mode { get; private set; }
    protected bool isAddListenerModeEnabled;
    protected bool isRemoveListenerModeEnabled;
    protected bool isInvokeModeEnabled;

    readonly AdvancedEvent<Type, IConvertible, UnityAction> onAddListener;
    readonly AdvancedEvent<Type, IConvertible, UnityAction> onRemoveListener;
    readonly AdvancedEvent<Type, object, UnityAction> onInvoke;

    public InterceptStepExecutor(IStepExecutor exe = null, InterceptStepExecutorMode mode = InterceptStepExecutorMode.Invoke) {
      this.exe = exe ?? new StepExecutor();
      this.mode = mode;
      this.isAddListenerModeEnabled = (this.mode & InterceptStepExecutorMode.AddListener) == InterceptStepExecutorMode.AddListener;
      this.isRemoveListenerModeEnabled = (this.mode & InterceptStepExecutorMode.RemoveListener) == InterceptStepExecutorMode.RemoveListener;
      this.isInvokeModeEnabled = (this.mode & InterceptStepExecutorMode.Invoke) == InterceptStepExecutorMode.Invoke;
      this.onAddListener = new();
      this.onRemoveListener = new();
      this.onInvoke = new();
    }

    protected InterceptStepExecutor OnAddListener(UnityAction<Type, IConvertible, UnityAction> action) {
      this.onAddListener.AddListener(action);
      return this;
    }
    protected InterceptStepExecutor OnRemoveListener(UnityAction<Type, IConvertible, UnityAction> action) {
      this.onRemoveListener.AddListener(action);
      return this;
    }
    protected InterceptStepExecutor OnInvoke(UnityAction<Type, object, UnityAction> action) {
      this.onInvoke.AddListener(action);
      return this;
    }

    public UnityAction AddListener<T>(IConvertible step, UnityAction action) {
      if (this.isAddListenerModeEnabled) this.onAddListener.Invoke(typeof(T), step, () => this.exe.AddListener<T>(step, action));
      else this.exe.AddListener<T>(step, action);
      return action;
    }

    public UnityAction RemoveListener<T>(IConvertible step, UnityAction action) {
      if (this.isRemoveListenerModeEnabled) this.onRemoveListener.Invoke(typeof(T), step, () => this.exe.RemoveListener<T>(step, action));
      else this.exe.RemoveListener<T>(step, action);
      return action;
    }

    public UnityAction AddOnceListener<T>(IConvertible step, UnityAction action) {
      if (this.isAddListenerModeEnabled) this.onAddListener.Invoke(typeof(T), step, () => this.exe.AddOnceListener<T>(step, action));
      else this.exe.AddOnceListener<T>(step, action);
      return action;
    }

    public UnityAction RemoveOnceListener<T>(IConvertible step, UnityAction action) {
      if (this.isRemoveListenerModeEnabled) this.onRemoveListener.Invoke(typeof(T), step, () => this.exe.RemoveOnceListener<T>(step, action));
      else this.exe.RemoveOnceListener<T>(step, action);
      return action;
    }

    public UnityAction<T> AddListener<T>(IConvertible step, UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) this.onAddListener.Invoke(typeof(T), step, () => this.exe.AddListener(step, action));
      else this.exe.AddListener(step, action);
      return action;
    }

    public UnityAction<T> RemoveListener<T>(IConvertible step, UnityAction<T> action) {
      if (this.isRemoveListenerModeEnabled) this.onRemoveListener.Invoke(typeof(T), step, () => this.exe.RemoveListener(step, action));
      else this.exe.RemoveListener(step, action);
      return action;
    }

    public UnityAction<T> AddOnceListener<T>(IConvertible step, UnityAction<T> action) {
      if (this.isAddListenerModeEnabled) this.onAddListener.Invoke(typeof(T), step, () => this.exe.AddOnceListener(step, action));
      else this.exe.AddOnceListener(step, action);
      return action;
    }

    public UnityAction<T> RemoveOnceListener<T>(IConvertible step, UnityAction<T> action) {
      if (this.isRemoveListenerModeEnabled) this.onRemoveListener.Invoke(typeof(T), step, () => this.exe.RemoveOnceListener(step, action));
      else this.exe.RemoveOnceListener(step, action);
      return action;
    }

    public void Invoke<T>(T e) {
      if (this.isInvokeModeEnabled) this.onInvoke.Invoke(typeof(T), e, () => this.exe.Invoke(e));
      else this.exe.Invoke(e);
    }
  }
}