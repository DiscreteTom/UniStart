using NUnit.Framework;
using DT.UniStart;
using UnityEngine.Events;
using System.Collections.Generic;

public class UniEventTest {
  [Test]
  public void EchoedAddListenerTest() {
    var e0 = new UniEvent();
    var e1 = new UniEvent<int>();
    var e2 = new UniEvent<int, int>();
    var e3 = new UniEvent<int, int, int>();
    var e4 = new UniEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddListener(() => n++).Invoke();
    Assert.AreEqual(1, n);

    n = 0;
    e1.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(2, n);

    n = 0;
    e2.AddListener((a, b) => n += a + b).Invoke(3, 4);
    Assert.AreEqual(7, n);

    n = 0;
    e3.AddListener((a, b, c) => n += a + b + c).Invoke(5, 6, 7);
    Assert.AreEqual(18, n);

    n = 0;
    e4.AddListener((a, b, c, d) => n += a + b + c + d).Invoke(8, 9, 10, 11);
    Assert.AreEqual(38, n);
  }

  [Test]
  public void CompatibleAddListenerTest() {
    var e0 = new UniEvent();
    var e1 = new UniEvent<int>();
    var e2 = new UniEvent<int, int>();
    var e3 = new UniEvent<int, int, int>();
    var e4 = new UniEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e1.AddListener(() => n++).Invoke();
    Assert.AreEqual(1, n);

    n = 0;
    e2.AddListener(() => n++).Invoke();
    Assert.AreEqual(1, n);
    e2.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(3, n);

    n = 0;
    e3.AddListener(() => n++).Invoke();
    Assert.AreEqual(1, n);
    e3.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(3, n);
    e3.AddListener((a, b) => n += a + b).Invoke(3, 4);
    Assert.AreEqual(10, n);

    n = 0;
    e4.AddListener(() => n++).Invoke();
    Assert.AreEqual(1, n);
    e4.AddListener((a) => n += a).Invoke(2);
    Assert.AreEqual(3, n);
    e4.AddListener((a, b) => n += a + b).Invoke(3, 4);
    Assert.AreEqual(10, n);
    e4.AddListener((a, b, c) => n += a + b + c).Invoke(5, 6, 7);
    Assert.AreEqual(28, n);
  }

  [Test]
  public void RemoveListenerTest() {
    var e0 = new UniEvent();
    var e1 = new UniEvent<int>();
    var e2 = new UniEvent<int, int>();
    var e3 = new UniEvent<int, int, int>();
    var e4 = new UniEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.RemoveListener(e0.AddListener(() => n++));
    e0.Invoke();
    Assert.AreEqual(0, n);

    n = 0;
    e1.RemoveListener(e1.AddListener(() => n++));
    e1.Invoke(1);
    Assert.AreEqual(0, n);
    e1.RemoveListener(e1.AddListener((a) => n += a));
    e1.Invoke(1);
    Assert.AreEqual(0, n);

    n = 0;
    e2.RemoveListener(e2.AddListener(() => n++));
    e2.Invoke(2, 3);
    Assert.AreEqual(0, n);
    e2.RemoveListener(e2.AddListener((a) => n += a));
    e2.Invoke(2, 3);
    Assert.AreEqual(0, n);
    e2.RemoveListener(e2.AddListener((a, b) => n += a + b));
    e2.Invoke(2, 3);
    Assert.AreEqual(0, n);

    n = 0;
    e3.RemoveListener(e3.AddListener(() => n++));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);
    e3.RemoveListener(e3.AddListener((a) => n += a));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);
    e3.RemoveListener(e3.AddListener((a, b) => n += a + b));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);
    e3.RemoveListener(e3.AddListener((a, b, c) => n += a + b + c));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);

    n = 0;
    e4.RemoveListener(e4.AddListener(() => n++));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddListener((a) => n += a));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddListener((a, b) => n += a + b));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddListener((a, b, c) => n += a + b + c));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddListener((a, b, c, d) => n += a + b + c + d));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
  }

  [Test]
  public void AddOnceListenerTest() {
    var e0 = new UniEvent();
    var e1 = new UniEvent<int>();
    var e2 = new UniEvent<int, int>();
    var e3 = new UniEvent<int, int, int>();
    var e4 = new UniEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddOnceListener(() => n++);
    e0.Invoke();
    e0.Invoke();
    Assert.AreEqual(1, n);

    n = 0;
    e1.AddOnceListener(() => n++);
    e1.Invoke(1);
    e1.Invoke(1);
    Assert.AreEqual(1, n);
    e1.AddOnceListener((a) => n += a);
    e1.Invoke(1);
    e1.Invoke(1);
    Assert.AreEqual(2, n);

    n = 0;
    e2.AddOnceListener(() => n++);
    e2.Invoke(2, 3);
    e2.Invoke(2, 3);
    Assert.AreEqual(1, n);
    e2.AddOnceListener((a) => n += a);
    e2.Invoke(2, 3);
    e2.Invoke(2, 3);
    Assert.AreEqual(3, n);
    e2.AddOnceListener((a, b) => n += a + b);
    e2.Invoke(2, 3);
    e2.Invoke(2, 3);
    Assert.AreEqual(8, n);

    n = 0;
    e3.AddOnceListener(() => n++);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(1, n);
    e3.AddOnceListener((a) => n += a);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(5, n);
    e3.AddOnceListener((a, b) => n += a + b);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(14, n);
    e3.AddOnceListener((a, b, c) => n += a + b + c);
    e3.Invoke(4, 5, 6);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(29, n);

    n = 0;
    e4.AddOnceListener(() => n++);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(1, n);
    e4.AddOnceListener((a) => n += a);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(8, n);
    e4.AddOnceListener((a, b) => n += a + b);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(8 + 7 + 8, n);
    e4.AddOnceListener((a, b, c) => n += a + b + c);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(8 + 7 + 8 + 7 + 8 + 9, n);
    e4.AddOnceListener((a, b, c, d) => n += a + b + c + d);
    e4.Invoke(7, 8, 9, 10);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(8 + 7 + 8 + 7 + 8 + 9 + 7 + 8 + 9 + 10, n);
  }

  [Test]
  public void RemoveOnceListenerTest() {
    var e0 = new UniEvent();
    var e1 = new UniEvent<int>();
    var e2 = new UniEvent<int, int>();
    var e3 = new UniEvent<int, int, int>();
    var e4 = new UniEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.RemoveListener(e0.AddOnceListener(() => n++));
    e0.Invoke();
    Assert.AreEqual(0, n);

    n = 0;
    e1.RemoveListener(e1.AddOnceListener(() => n++));
    e1.Invoke(1);
    Assert.AreEqual(0, n);
    e1.RemoveListener(e1.AddOnceListener((a) => n += a));
    e1.Invoke(1);
    Assert.AreEqual(0, n);

    n = 0;
    e2.RemoveListener(e2.AddOnceListener(() => n++));
    e2.Invoke(2, 3);
    Assert.AreEqual(0, n);
    e2.RemoveListener(e2.AddOnceListener((a) => n += a));
    e2.Invoke(2, 3);
    Assert.AreEqual(0, n);
    e2.RemoveListener(e2.AddOnceListener((a, b) => n += a + b));
    e2.Invoke(2, 3);
    Assert.AreEqual(0, n);

    n = 0;
    e3.RemoveListener(e3.AddOnceListener(() => n++));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);
    e3.RemoveListener(e3.AddOnceListener((a) => n += a));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);
    e3.RemoveListener(e3.AddOnceListener((a, b) => n += a + b));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);
    e3.RemoveListener(e3.AddOnceListener((a, b, c) => n += a + b + c));
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(0, n);

    n = 0;
    e4.RemoveListener(e4.AddOnceListener(() => n++));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddOnceListener((a) => n += a));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddOnceListener((a, b) => n += a + b));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddOnceListener((a, b, c) => n += a + b + c));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
    e4.RemoveListener(e4.AddOnceListener((a, b, c, d) => n += a + b + c + d));
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(0, n);
  }

  [Test]
  public void RemoveAllListenerTest() {
    var e0 = new UniEvent();
    var e1 = new UniEvent<int>();
    var e2 = new UniEvent<int, int>();
    var e3 = new UniEvent<int, int, int>();
    var e4 = new UniEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddListener(() => n++);
    e0.AddOnceListener(() => n++);
    e0.RemoveAllListeners();
    e0.Invoke();
    Assert.AreEqual(0, n);

    n = 0;
    e1.AddListener(() => n++);
    e1.AddOnceListener(() => n++);
    e1.AddListener((a) => n += a);
    e1.AddOnceListener((a) => n += a);
    e1.RemoveAllListeners();
    e1.Invoke(2);
    Assert.AreEqual(0, n);

    n = 0;
    e2.AddListener(() => n++);
    e2.AddOnceListener(() => n++);
    e2.AddListener((a) => n += a);
    e2.AddOnceListener((a) => n += a);
    e2.AddListener((a, b) => n += a + b);
    e2.AddOnceListener((a, b) => n += a + b);
    e2.RemoveAllListeners();
    e2.Invoke(3, 4);
    Assert.AreEqual(0, n);

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
    Assert.AreEqual(0, n);

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
    Assert.AreEqual(0, n);
  }

  [Test]
  public void InvokeTest() {
    var e0 = new UniEvent();
    var e1 = new UniEvent<int>();
    var e2 = new UniEvent<int, int>();
    var e3 = new UniEvent<int, int, int>();
    var e4 = new UniEvent<int, int, int, int>();
    var n = 0;

    n = 0;
    e0.AddListener(() => n++);
    e0.Invoke();
    Assert.AreEqual(1, n);
    e0.Invoke();
    Assert.AreEqual(2, n);

    n = 0;
    e1.AddListener(() => n++);
    e1.AddListener((a) => n += a);
    e1.Invoke(1);
    Assert.AreEqual(2, n);
    e1.Invoke(1);
    Assert.AreEqual(4, n);

    n = 0;
    e2.AddListener(() => n++);
    e2.AddListener((a) => n += a);
    e2.AddListener((a, b) => n += a + b);
    e2.Invoke(2, 3);
    Assert.AreEqual(8, n);
    e2.Invoke(2, 3);
    Assert.AreEqual(16, n);

    n = 0;
    e3.AddListener(() => n++);
    e3.AddListener((a) => n += a);
    e3.AddListener((a, b) => n += a + b);
    e3.AddListener((a, b, c) => n += a + b + c);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(29, n);
    e3.Invoke(4, 5, 6);
    Assert.AreEqual(58, n);

    n = 0;
    e4.AddListener(() => n++);
    e4.AddListener((a) => n += a);
    e4.AddListener((a, b) => n += a + b);
    e4.AddListener((a, b, c) => n += a + b + c);
    e4.AddListener((a, b, c, d) => n += a + b + c + d);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(81, n);
    e4.Invoke(7, 8, 9, 10);
    Assert.AreEqual(162, n);
  }

  [Test]
  public void StableInvokeTest() {
    var e = new UniEvent();
    var n = 0;
    UnityAction a = () => n++;


    e.AddListener(() => e.RemoveListener(a)); // this will be invoked first
    e.AddListener(a); // a should still be called
    e.Invoke();
    Assert.AreEqual(1, n);
    // now a should be removed
    e.Invoke();
    Assert.AreEqual(1, n);

    e.RemoveAllListeners();
    n = 0;
    e.AddListener(() => e.AddListener(a));
    e.Invoke(); // a will be added but not called
    Assert.AreEqual(0, n);
    e.Invoke(); // a should be called
    Assert.AreEqual(1, n);

    e.RemoveAllListeners();
    n = 0;
    e.AddOnceListener(() => e.AddOnceListener(a));
    e.Invoke(); // a will be added but not called
    Assert.AreEqual(0, n);
    e.Invoke(); // a should be called then removed
    Assert.AreEqual(1, n);
    e.Invoke();
    Assert.AreEqual(1, n);
  }

  [Test]
  public void StableInvokeOrderTest() {
    var list = new List<int>();
    var e1 = new UniEvent<int>();

    e1.AddListener(() => list.Add(1));
    e1.AddOnceListener(() => list.Add(2));
    e1.AddListener((a) => list.Add(a));

    e1.Invoke(3);
    Assert.AreEqual(new List<int> { 1, 2, 3 }, list);
  }

  [Test]
  public void StableInvokeAddListenerTest() {
    var list = new List<int>();
    var e = new UniEvent();

    // add listeners during invocation
    e.AddOnceListener(() => e.AddOnceListener(() => list.Add(1)));

    e.Invoke(); // this will add the second once listener, but won't invoke it
    Assert.AreEqual(new List<int>(), list);

    e.Invoke(); // this will invoke the second once listener, which will add 1 to the list
    Assert.AreEqual(new List<int> { 1 }, list);
  }

  [Test]
  public void StableInvokeRemoveListenerTest() {
    var list = new List<int>();
    var e = new UniEvent();
    UnityAction a = () => list.Add(1);

    // remove listeners during invocation
    e.AddListener(() => e.RemoveListener(a));
    e.AddListener(a);

    e.Invoke(); // this will remove listener 'a' but only take effect on the next invocation
    Assert.AreEqual(new List<int> { 1 }, list); // so 'a' will still be called in this invocation

    e.Invoke(); // now 'a' should be removed
    Assert.AreEqual(new List<int> { 1 }, list); // list should not be modified
  }
}