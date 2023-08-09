using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// DebugStepExecutor is a wrapper around an IStepExecutor which logs all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugStepExecutor : InterceptStepExecutor {
    readonly string name;

    public DebugStepExecutor(IStepExecutor exe = null, InterceptStepExecutorMode mode = InterceptStepExecutorMode.Invoke, string name = "DebugStepExecutor") : base(exe, mode) {
      this.name = name;
      this.OnAddListener((type, step, proceed) => {
        Debug.Log($"{this.name}.AddListener: event = {type}, step = {step}");
        proceed();
      });
      this.OnRemoveListener((type, step, proceed) => {
        Debug.Log($"{this.name}.RemoveListener: event = {type}, step = {step}");
        proceed();
      });
      this.OnInvoke((type, parameter, proceed) => {
        Debug.Log($"{this.name}.Invoke: event = {type}, parameter = {parameter}");
        proceed();
      });
    }
  }
}