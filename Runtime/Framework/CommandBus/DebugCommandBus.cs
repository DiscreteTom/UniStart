using UnityEngine;

namespace DT.UniStart {
  public class DebugCommandBus<Ctx> : ICommandBus<Ctx> {
    public string name = "DebugCommandBus";
    readonly ICommandBus<Ctx> bus;

    public DebugCommandBus(ICommandBus<Ctx> bus) {
      this.bus = bus;
    }

    /// <summary>
    /// Set the name of the DebugCommandBus.
    /// </summary>
    public DebugCommandBus<Ctx> WithName(string name) {
      this.name = name;
      return this;
    }

    public void Push<T>(T cmd) where T : ICommand<Ctx> {
      Debug.Log($"{this.name}.Push: command = {typeof(T)}, parameter = {cmd}");
      this.bus.Push(cmd);
    }
  }
}