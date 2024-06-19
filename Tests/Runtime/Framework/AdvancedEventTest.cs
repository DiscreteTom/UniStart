using NUnit.Framework;
using DT.UniStart;
using UnityEngine.Events;

public class AdvancedEventTest {
  [Test]
  public void EchoedAddListenerTest() {
    var e0 = new AdvancedEvent();
    var e1 = new AdvancedEvent<int>();
    var e2 = new AdvancedEvent<int, int>();
    var e3 = new AdvancedEvent<int, int, int>();
    var e4 = new AdvancedEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddListener(() => n++).Invoke();
    Assert.AreEqual(n, 1);

    n = 0;
    e1.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(n, 2);

    n = 0;
    e2.AddListener((a, b) => n += a + b).Invoke(3, 4);
    Assert.AreEqual(n, 7);

    n = 0;
    e3.AddListener((a, b, c) => n += a + b + c).Invoke(5, 6, 7);
    Assert.AreEqual(n, 18);

    n = 0;
    e4.AddListener((a, b, c, d) => n += a + b + c + d).Invoke(8, 9, 10, 11);
    Assert.AreEqual(n, 38);
  }

  [Test]
  public void CompatibleAddListenerTest() {
    var e0 = new AdvancedEvent();
    var e1 = new AdvancedEvent<int>();
    var e2 = new AdvancedEvent<int, int>();
    var e3 = new AdvancedEvent<int, int, int>();
    var e4 = new AdvancedEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e1.AddListener(() => n++).Invoke();
    Assert.AreEqual(n, 1);

    n = 0;
    e2.AddListener(() => n++).Invoke();
    Assert.AreEqual(n, 1);
    e2.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(n, 3);

    n = 0;
    e3.AddListener(() => n++).Invoke();
    Assert.AreEqual(n, 1);
    e3.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(n, 3);
    e3.AddListener((a, b) => n += a + b).Invoke(3, 4);
    Assert.AreEqual(n, 10);

    n = 0;
    e4.AddListener(() => n++).Invoke();
    Assert.AreEqual(n, 1);
    e4.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(n, 3);
    e4.AddListener((a, b) => n += a + b).Invoke(3, 4);
    Assert.AreEqual(n, 10);
    e4.AddListener((a, b, c) => n += a + b + c).Invoke(5, 6, 7);
    Assert.AreEqual(n, 28);
  }

  [Test]
  public void RemoveListenerTest() {
    var e0 = new AdvancedEvent();
    var e1 = new AdvancedEvent<int>();
    var e2 = new AdvancedEvent<int, int>();
    var e3 = new AdvancedEvent<int, int, int>();
    var e4 = new AdvancedEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.RemoveListener(e0.AddListener(() => n++));
    e0.Invoke();
    Assert.AreEqual(n, 0);

    n = 0;
    e1.RemoveListener(e1.AddListener(() => n++));
    e1.Invoke(1);
    Assert.AreEqual(n, 0);
    e1.RemoveListener(e1.AddListener((a) => n += a));
    e1.Invoke(1);
    Assert.AreEqual(n, 0);

    n = 0;
    e2.RemoveListener(e2.AddListener(() => n++));
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 0);
    e2.RemoveListener(e2.AddListener((a) => n += a));
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 0);
    e2.RemoveListener(e2.AddListener((a, b) => n += a + b));
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 0);

    n = 0;
    e3.RemoveListener(e3.AddListener(() => n++));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);
    e3.RemoveListener(e3.AddListener((a) => n += a));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);
    e3.RemoveListener(e3.AddListener((a, b) => n += a + b));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);
    e3.RemoveListener(e3.AddListener((a, b, c) => n += a + b + c));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);

    n = 0;
    e4.RemoveListener(e4.AddListener(() => n++));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddListener((a) => n += a));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddListener((a, b) => n += a + b));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddListener((a, b, c) => n += a + b + c));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddListener((a, b, c, d) => n += a + b + c + d));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
  }

  [Test]
  public void AddOnceListenerTest() {
    var e0 = new AdvancedEvent();
    var e1 = new AdvancedEvent<int>();
    var e2 = new AdvancedEvent<int, int>();
    var e3 = new AdvancedEvent<int, int, int>();
    var e4 = new AdvancedEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddOnceListener(() => n++);
    e0.Invoke();
    e0.Invoke();
    Assert.AreEqual(n, 1);

    n = 0;
    e1.AddOnceListener(() => n++);
    e1.Invoke(1);
    e1.Invoke(1);
    Assert.AreEqual(n, 1);
    e1.AddOnceListener((a) => n += a);
    e1.Invoke(1);
    e1.Invoke(1);
    Assert.AreEqual(n, 2);

    n = 0;
    e2.AddOnceListener(() => n++);
    e2.Invoke(2, 3);
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 1);
    e2.AddOnceListener((a) => n += a);
    e2.Invoke(2, 3);
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 3);
    e2.AddOnceListener((a, b) => n += a + b);
    e2.Invoke(2, 3);
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 8);

    n = 0;
    e3.AddOnceListener(() => n++);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 1);
    e3.AddOnceListener((a) => n += a);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 5);
    e3.AddOnceListener((a, b) => n += a + b);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 14);
    e3.AddOnceListener((a, b, c) => n += a + b + c);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 29);

    n = 0;
    e4.AddOnceListener(() => n++);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 1);
    e4.AddOnceListener((a) => n += a);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 8);
    e4.AddOnceListener((a, b) => n += a + b);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 8 + 7 + 8);
    e4.AddOnceListener((a, b, c) => n += a + b + c);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 8 + 7 + 8 + 7 + 8 + 9);
    e4.AddOnceListener((a, b, c, d) => n += a + b + c + d);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 8 + 7 + 8 + 7 + 8 + 9 + 7 + 8 + 9 + 10);
  }

  [Test]
  public void RemoveOnceListenerTest() {
    var e0 = new AdvancedEvent();
    var e1 = new AdvancedEvent<int>();
    var e2 = new AdvancedEvent<int, int>();
    var e3 = new AdvancedEvent<int, int, int>();
    var e4 = new AdvancedEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.RemoveListener(e0.AddOnceListener(() => n++));
    e0.Invoke();
    Assert.AreEqual(n, 0);

    n = 0;
    e1.RemoveListener(e1.AddOnceListener(() => n++));
    e1.Invoke(1);
    Assert.AreEqual(n, 0);
    e1.RemoveListener(e1.AddOnceListener((a) => n += a));
    e1.Invoke(1);
    Assert.AreEqual(n, 0);

    n = 0;
    e2.RemoveListener(e2.AddOnceListener(() => n++));
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 0);
    e2.RemoveListener(e2.AddOnceListener((a) => n += a));
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 0);
    e2.RemoveListener(e2.AddOnceListener((a, b) => n += a + b));
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 0);

    n = 0;
    e3.RemoveListener(e3.AddOnceListener(() => n++));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);
    e3.RemoveListener(e3.AddOnceListener((a) => n += a));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);
    e3.RemoveListener(e3.AddOnceListener((a, b) => n += a + b));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);
    e3.RemoveListener(e3.AddOnceListener((a, b, c) => n += a + b + c));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 0);

    n = 0;
    e4.RemoveListener(e4.AddOnceListener(() => n++));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddOnceListener((a) => n += a));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddOnceListener((a, b) => n += a + b));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddOnceListener((a, b, c) => n += a + b + c));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
    e4.RemoveListener(e4.AddOnceListener((a, b, c, d) => n += a + b + c + d));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 0);
  }

  [Test]
  public void RemoveAllListenerTest() {
    var e0 = new AdvancedEvent();
    var e1 = new AdvancedEvent<int>();
    var e2 = new AdvancedEvent<int, int>();
    var e3 = new AdvancedEvent<int, int, int>();
    var e4 = new AdvancedEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddListener(() => n++);
    e0.AddOnceListener(() => n++);
    e0.RemoveAllListeners();
    e0.Invoke();
    Assert.AreEqual(n, 0);

    n = 0;
    e1.AddListener(() => n++);
    e1.AddOnceListener(() => n++);
    e1.AddListener((a) => n += a);
    e1.AddOnceListener((a) => n += a);
    e1.RemoveAllListeners();
    e1.Invoke(2);
    Assert.AreEqual(n, 0);

    n = 0;
    e2.AddListener(() => n++);
    e2.AddOnceListener(() => n++);
    e2.AddListener((a) => n += a);
    e2.AddOnceListener((a) => n += a);
    e2.AddListener((a, b) => n += a + b);
    e2.AddOnceListener((a, b) => n += a + b);
    e2.RemoveAllListeners();
    e2.Invoke(3, 4);
    Assert.AreEqual(n, 0);

    n = 0;
    e3.AddListener(() => n++);
    e3.AddOnceListener(() => n++);
    e3.AddListener((a) => n += a);
    e3.AddOnceListener((a) => n += a);
    e3.AddListener((a, b) => n += a + b);
    e3.AddOnceListener((a, b) => n += a + b);
    e3.AddListener((a, b, c) => n += a + b + c);
    e3.AddOnceListener((a, b, c) => n += a + b + c);
    e3.RemoveAllListeners();
    e3.Invoke(5, 6, 7);
    Assert.AreEqual(n, 0);

    n = 0;
    e4.AddListener(() => n++);
    e4.AddOnceListener(() => n++);
    e4.AddListener((a) => n += a);
    e4.AddOnceListener((a) => n += a);
    e4.AddListener((a, b) => n += a + b);
    e4.AddOnceListener((a, b) => n += a + b);
    e4.AddListener((a, b, c) => n += a + b + c);
    e4.AddOnceListener((a, b, c) => n += a + b + c);
    e4.AddListener((a, b, c, d) => n += a + b + c + d);
    e4.AddOnceListener((a, b, c, d) => n += a + b + c + d);
    e4.RemoveAllListeners();
    e4.Invoke(8, 9, 10, 11);
    Assert.AreEqual(n, 0);
  }

  [Test]
  public void InvokeTest() {
    var e0 = new AdvancedEvent();
    var e1 = new AdvancedEvent<int>();
    var e2 = new AdvancedEvent<int, int>();
    var e3 = new AdvancedEvent<int, int, int>();
    var e4 = new AdvancedEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddListener(() => n++);
    e0.Invoke();
    Assert.AreEqual(n, 1);
    e0.Invoke();
    Assert.AreEqual(n, 2);

    n = 0;
    e1.AddListener(() => n++);
    e1.AddListener((a) => n += a);
    e1.Invoke(1);
    Assert.AreEqual(n, 2);
    e1.Invoke(1);
    Assert.AreEqual(n, 4);

    n = 0;
    e2.AddListener(() => n++);
    e2.AddListener((a) => n += a);
    e2.AddListener((a, b) => n += a + b);
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 8);
    e2.Invoke(2, 3);
    Assert.AreEqual(n, 16);

    n = 0;
    e3.AddListener(() => n++);
    e3.AddListener((a) => n += a);
    e3.AddListener((a, b) => n += a + b);
    e3.AddListener((a, b, c) => n += a + b + c);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 29);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(n, 58);

    n = 0;
    e4.AddListener(() => n++);
    e4.AddListener((a) => n += a);
    e4.AddListener((a, b) => n += a + b);
    e4.AddListener((a, b, c) => n += a + b + c);
    e4.AddListener((a, b, c, d) => n += a + b + c + d);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 81);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(n, 162);
  }

  [Test]
  public void StableInvokeTest() {
    var e = new AdvancedEvent();
    var n = 0;
    UnityAction a = () => n++;


    e.AddListener(() => e.RemoveListener(a)); // this will be invoked first
    e.AddListener(a); // a should still be called
    e.Invoke();
    Assert.AreEqual(n, 1);
    // now a should be removed
    e.Invoke();
    Assert.AreEqual(n, 1);

    e.RemoveAllListeners();
    n = 0;
    e.AddListener(() => e.AddListener(a));
    e.Invoke(); // a will be added but not called
    Assert.AreEqual(n, 0);
    e.Invoke(); // a should be called
    Assert.AreEqual(n, 1);

    e.RemoveAllListeners();
    n = 0;
    e.AddOnceListener(() => e.AddOnceListener(a));
    e.Invoke(); // a will be added but not called
    Assert.AreEqual(n, 0);
    e.Invoke(); // a should be called then removed
    Assert.AreEqual(n, 1);
    e.Invoke();
    Assert.AreEqual(n, 1);
  }
}