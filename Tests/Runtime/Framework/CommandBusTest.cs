using NUnit.Framework;
using DT.UniStart;

public class CommandBusTest {
  record E;
  record EE(int a);

  [Test]
  public void BasicTest() {
    var a = 0;
    ICommandBus cb = new CommandCenter().With<E>(e => a++).With<EE>(() => a++);

    cb.Push<E>();
    Assert.AreEqual(1, a);

    a = 0;
    cb.Push(new EE(1));
    Assert.AreEqual(1, a);
  }

  [Test]
  public void DelayedTest() {
    var a = 0;
    var cb = new DelayedCommandCenter();
    ICommandBus _ = cb;

    cb.Add<E>(e => a++);
    cb.Push<E>();
    Assert.AreEqual(0, a);

    cb.Execute();
    Assert.AreEqual(1, a);
  }
}