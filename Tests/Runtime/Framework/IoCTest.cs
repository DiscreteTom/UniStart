using NUnit.Framework;
using DT.UniStart;
using UnityEngine.Events;

public class IoCTest {
  [Test]
  public void IoCClassTest() {
    var ioc = new IoCC();
    ioc.Add(new EventBus());
    Assert.IsTrue(ioc.Contains<EventBus>());
    Assert.IsTrue(ioc.TryGet<EventBus>(out var _));
    Assert.IsNotNull(ioc.Get<EventBus>());
    Assert.IsNotNull(ioc.GetOrDefault<EventBus>());

    Assert.IsFalse(ioc.Contains<UnityEvent>());
    Assert.IsFalse(ioc.TryGet<UnityEvent>(out var e));
    Assert.IsNull(e);
    Assert.IsNull(ioc.GetOrDefault<UnityEvent>());
    Assert.Catch(() => ioc.Get<UnityEvent>());
  }
}