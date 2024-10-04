using NUnit.Framework;
using DT.UniStart;

public class EventBusTest {
  record E;
  record EE(int a);

  [Test]
  public void BasicTest() {
    IEventBus eb = new EventBus();
    var a = 0;

    eb.AddListener<E>(e => a++);
    eb.Invoke<E>();
    Assert.AreEqual(1, a);

    a = 0;
    eb.AddListener<EE>(() => a += 1); // less param
    eb.AddListener<EE>(e => a += e.a);
    eb.Invoke(new EE(1));
    Assert.AreEqual(2, a);
  }

  [Test]
  public void OnceEventTest() {
    IEventBus eb = new EventBus();
    var a = 0;

    eb.AddOnceListener<E>(() => a += 1);
    eb.Invoke<E>();
    Assert.AreEqual(1, a);

    eb.Invoke<E>();
    Assert.AreEqual(1, a);
  }

  [Test]
  public void DelayedTest() {
    var eb = new DelayedEventBus();
    IEventBus _ = eb;
    var a = 0;

    eb.AddListener<E>(e => a++);
    eb.Invoke<E>();
    Assert.AreEqual(0, a);

    eb.InvokeDelayed();
    Assert.AreEqual(1, a);
  }
}