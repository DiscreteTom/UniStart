using NUnit.Framework;
using DT.UniStart;
using System;

public class CommandBusTest {
  record E : ICommand<Watch<int>> {
    public void Invoke(Watch<int> ctx) {
      ctx.Value++;
    }
  }
  record EE(int a) : ICommand<Watch<int>> {
    public void Invoke(Watch<int> ctx) {
      ctx.Value += a;
    }
  }

  [Test]
  public void BasicTest() {
    var a = new Watch<int>(0);
    ICommandBus<Watch<int>> cb = new CommandBus<Watch<int>>(a);

    cb.Push<E>();
    Assert.AreEqual(1, a.Value);

    a.Value = 0;
    cb.Push(new EE(2));
    Assert.AreEqual(2, a.Value);
  }

  [Test]
  public void DelayedTest() {
    var a = new Watch<int>(0);
    var cb = new DelayedCommandBus<Watch<int>>(a);

    (cb as ICommandBus<Watch<int>>).Push<E>();
    Assert.AreEqual(0, a.Value);

    cb.Execute();
    Assert.AreEqual(1, a.Value);
  }
}