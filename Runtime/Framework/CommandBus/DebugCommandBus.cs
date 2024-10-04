using UnityEngine;

namespace DT.UniStart {
  public class DebugCommandBus : ICommandBus {
    public string name = "DebugCommandBus";
    readonly ICommandBus bus;

    public DebugCommandBus(ICommandBus bus) {
      this.bus = bus;
    }

    /// <summary>
    /// Set the name of the DebugCommandBus.
    /// </summary>
    public DebugCommandBus WithName(string name) {
      this.name = name;
      return this;
    }

    public void Push<T>(T cmd) {
      Debug.Log($"{this.name}.Push: command = {typeof(T)}, parameter = {cmd}");
      this.bus.Push(cmd);
    }
  }
}