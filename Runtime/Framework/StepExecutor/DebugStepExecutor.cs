using System;
using UnityEngine;

namespace DT.UniStart {
  /// <summary>
  /// DebugStepExecutor is a wrapper around an IStepExecutor which logs all calls to Invoke.
  /// </summary>
  public class DebugStepExecutor<S> : IStepExecutor<S> where S : IConvertible {
    public string name = "DebugStepExecutor";
    readonly IStepExecutor<S> exe;

    public DebugStepExecutor(IStepExecutor<S> exe = null) {
      this.exe = exe ?? new StepExecutor<S>();
    }

    /// <summary>
    /// Set the name of the DebugStepExecutor.
    /// </summary>
    public DebugStepExecutor<S> WithName(string name) {
      this.name = name;
      return this;
    }

    public UniEvent On(S step) {
      Debug.Log($"{this.name}.On: step = {step}");
      return this.exe.On(step);
    }

    public void Invoke() {
      Debug.Log($"{this.name}.Invoke");
      this.exe.Invoke();
    }
  }

  /// <summary>
  /// DebugStepExecutor is a wrapper around an IStepExecutor which logs all calls to Invoke.
  /// </summary>
  public class DebugStepExecutor<S, T> : IStepExecutor<S, T> where S : IConvertible {
    public string name = "DebugStepExecutor";
    readonly IStepExecutor<S, T> exe;

    public DebugStepExecutor(IStepExecutor<S, T> exe = null) {
      this.exe = exe ?? new StepExecutor<S, T>();
    }

    /// <summary>
    /// Set the name of the DebugStepExecutor.
    /// </summary>
    public DebugStepExecutor<S, T> WithName(string name) {
      this.name = name;
      return this;
    }

    public UniEvent<T> On(S step) {
      Debug.Log($"{this.name}.On: step = {step}");
      return this.exe.On(step);
    }

    public void Invoke(T ctx) {
      Debug.Log($"{this.name}.Invoke: ctx = {ctx}");
      this.exe.Invoke(ctx);
    }
  }
}