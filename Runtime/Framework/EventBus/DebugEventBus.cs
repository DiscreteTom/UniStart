using System;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// DebugEventBus is a wrapper around an IEventBus which logs all calls to AddListener, RemoveListener and Invoke.
  /// </summary>
  public class DebugEventBus : InterceptEventBus {
    string name;

    public DebugEventBus(IEventBus bus = null, InterceptEventBusMode mode = InterceptEventBusMode.Invoke, string name = "DebugEventBus") : base(bus, mode) {
      this.name = name;
      this.OnAddListener((type, proceed) => {
        Debug.Log($"{this.name}.AddListener: event = {type}");
        proceed();
      });
      this.OnRemoveListener((type, proceed) => {
        Debug.Log($"{this.name}.RemoveListener: event = {type}");
        proceed();
      });
      this.OnInvoke((type, parameter, proceed) => {
        Debug.Log($"{this.name}.Invoke: event = {type}, parameter = {parameter}");
        proceed();
      });
    }
  }
}