using NUnit.Framework;
using UnityEngine;
using DT.UniStart;
using System;
using System.Collections.Generic;

public class ExtensionTest {
  [Test]
  public void ArrayExtensionTest() {
    // TODO: test static methods?

    // contains
    Assert.IsTrue(new int[3] { 1, 2, 3 }.Contains(3));

    // clear
    var a = new int[2] { 1, 2, };
    a.Clear();
    Assert.AreEqual(a[0], 0);
    Assert.AreEqual(a[1], 0);

    // fill
    var b = new Watch<int>[2];
    b.Fill(() => new Watch<int>(0));
    Assert.AreNotEqual(b[0], null);
    Assert.AreNotEqual(b[1], null);
    Assert.AreNotEqual(b[0], b[1]);

    // fill with start index
    var c = new Watch<int>[3];
    c.Fill(() => new Watch<int>(0), 1, 1);
    Assert.IsNull(c[0]);
    Assert.IsNotNull(c[1]);
    Assert.IsNull(c[2]);
  }

  [Test]
  public void ColorExtensionTest() {
    var color = new Color(0, 0, 0, 0);
    Assert.AreEqual(color.WithRed(1).r, 1);
    Assert.AreEqual(color.WithGreen(1).g, 1);
    Assert.AreEqual(color.WithBlue(1).b, 1);
    Assert.AreEqual(color.WithAlpha(1).a, 1);
    // make sure we're not mutating the original color
    Assert.AreNotEqual(color.WithRed(1).r, color.r);
  }

  [Test]
  public void GameObjectExtensionTest() {
    var go = new GameObject();
    // check get
    Assert.AreEqual(go.GetOrAddComponent<Transform>(), go.transform);
    // check add
    Assert.IsNotNull(go.GetOrAddComponent<SpriteRenderer>());

    UnityEngine.Object.Destroy(go);
  }

  [Test]
  public void IDictionaryExtensionTest() {
    var dict = new Dictionary<int, EventBus> {
      { 1, new () }
    };
    // check get
    Assert.AreEqual(dict.GetOrAdd(1, () => new()), dict[1]);
    Assert.AreEqual(dict.GetOrAddDefault(1), dict[1]);
    Assert.AreEqual(dict.GetOrAddNew(1), dict[1]);
    Assert.AreEqual(dict.GetOrDefault(1), dict[1]);

    // check add
    Assert.AreNotEqual(dict.GetOrAdd(2, () => new()), dict[1]);
    Assert.IsNotNull(dict[2]);

    // check add default
    Assert.AreNotEqual(dict.GetOrAddDefault(3), dict[1]);
    Assert.IsNull(dict[3]);

    // check add new
    Assert.AreNotEqual(dict.GetOrAddNew(4), dict[1]);
    Assert.IsNotNull(dict[4]);

    // check get default
    Assert.IsNull(dict.GetOrDefault(5));
  }

  [Test]
  public void IEnumerableExtensionTest() {
    // for each
    // list has a ForEach method, but stack does not
    var stack = new Stack<int>();
    stack.Push(1);
    stack.Push(2);
    stack.Push(3);
    var sum = 0;
    stack.ForEach((i) => sum += i);
    Assert.AreEqual(sum, 6);

    // for each with index
    var list = new List<int> { 1, 2, 3 };
    var sumWithIndex = 0;
    list.ForEach((i, index) => sumWithIndex += i * index);
    Assert.AreEqual(sumWithIndex, 8);

    // map
    var mapped = list.Map((i) => i * 2);
    Assert.AreEqual(mapped[0], 2);
    Assert.AreEqual(mapped[1], 4);
    Assert.AreEqual(mapped[2], 6);

    // map with index
    var mappedWithIndex = list.Map((i, index) => i * index);
    Assert.AreEqual(mappedWithIndex[0], 0);
    Assert.AreEqual(mappedWithIndex[1], 2);
    Assert.AreEqual(mappedWithIndex[2], 6);

    // shuffle
    var shuffled = list.Shuffle();
    Assert.IsTrue(shuffled.Contains(1));
    Assert.IsTrue(shuffled.Contains(2));
    Assert.IsTrue(shuffled.Contains(3));
    Assert.AreEqual(shuffled.Length, 3);
    var iterations = 0;
    while (iterations < 100) {
      shuffled = list.Shuffle();
      if (shuffled[0] != 1 || shuffled[1] != 2 || shuffled[2] != 3) {
        break;
      }
      iterations++;
      if (iterations == 100) {
        Assert.Fail("Shuffle should not return the same order 100 times in a row!");
      }
    }
  }

  [Test]
  public void IListExtensionTest() {
    var list = new List<int> { 1, 2, 3 };
    // fill
    list.Fill(0);
    Assert.AreEqual(list[0], 0);
    Assert.AreEqual(list[1], 0);
    Assert.AreEqual(list[2], 0);

    // fill with factory
    list.Fill(() => 1);
    Assert.AreEqual(list[0], 1);
    Assert.AreEqual(list[1], 1);
    Assert.AreEqual(list[2], 1);
  }

  [Test]
  public void LayerMaskExtensionTest() {
    var mask = new LayerMask() { value = 1 };
    Assert.IsTrue(mask.Contains(0));
    Assert.IsFalse(mask.Contains(1));
  }

  [Test]
  public void MonoBehaviourExtensionTest() {
    // TODO: test Invoke/InvokeRepeating

    var go = new GameObject();
    var cb = go.AddComponent<ComposableBehaviour>();
    // check get
    Assert.AreEqual(cb.GetOrAddComponent<Transform>(), cb.transform);
    // check add
    Assert.IsNotNull(cb.GetOrAddComponent<SpriteRenderer>());

    UnityEngine.Object.Destroy(go);
  }

  [Test]
  public void QuaternionExtensionTest() {
    var q = new Quaternion(0, 0, 0, 0);
    Assert.AreEqual(q.WithX(1).x, 1);
    Assert.AreEqual(q.WithY(1).y, 1);
    Assert.AreEqual(q.WithZ(1).z, 1);
    Assert.AreEqual(q.WithW(1).w, 1);
    // make sure we're not mutating the original quaternion
    Assert.AreNotEqual(q.WithX(1).x, q.x);
  }

  [Test]
  public void Rigidbody2DExtensionTest() {
    var go = new GameObject();
    var rb = go.AddComponent<Rigidbody2D>();
    Assert.AreEqual(rb.SetVelocityX(1).velocity.x, 1);
    Assert.AreEqual(rb.SetVelocityY(1).velocity.y, 1);

    UnityEngine.Object.Destroy(go);
  }

  [Test]
  public void RigidbodyExtensionTest() {
    var go = new GameObject();
    var rb = go.AddComponent<Rigidbody>();
    Assert.AreEqual(rb.SetVelocityX(1).velocity.x, 1);
    Assert.AreEqual(rb.SetVelocityY(1).velocity.y, 1);
    Assert.AreEqual(rb.SetVelocityZ(1).velocity.z, 1);

    UnityEngine.Object.Destroy(go);
  }

  [Test]
  public void SpriteRendererExtensionTest() {
    var go = new GameObject();
    var sr = go.AddComponent<SpriteRenderer>();
    Assert.AreEqual(sr.SetColorRed(1).color.r, 1);
    Assert.AreEqual(sr.SetColorGreen(1).color.g, 1);
    Assert.AreEqual(sr.SetColorBlue(1).color.b, 1);
    Assert.AreEqual(sr.SetColorAlpha(1).color.a, 1);

    UnityEngine.Object.Destroy(go);
  }

  [Test]
  public void TransformExtensionTest() {
    var go = new GameObject();
    var t = go.transform;
    Assert.AreEqual(t.SetPositionX(1).position.x, 1);
    Assert.AreEqual(t.SetPositionY(1).position.y, 1);
    Assert.AreEqual(t.SetPositionZ(1).position.z, 1);
    Assert.AreEqual(t.SetLocalPositionX(2).localPosition.x, 2);
    Assert.AreEqual(t.SetLocalPositionY(2).localPosition.y, 2);
    Assert.AreEqual(t.SetLocalPositionZ(2).localPosition.z, 2);
    Assert.AreEqual(t.SetLocalScaleX(3).localScale.x, 3);
    Assert.AreEqual(t.SetLocalScaleY(3).localScale.y, 3);
    Assert.AreEqual(t.SetLocalScaleZ(3).localScale.z, 3);

    // for each child
    var child1 = new GameObject("child1");
    child1.transform.parent = t;
    var child2 = new GameObject("child2");
    child2.transform.parent = t;
    var child3 = new GameObject("child3");
    child3.transform.parent = t;
    var count = 0;
    t.ForEachChild((child) => count++);
    Assert.AreEqual(count, 3);

    // for each child with index
    count = 0;
    t.ForEachChild((child, index) => count += index);
    Assert.AreEqual(count, 3);

    // map children
    var mapped = t.MapChildren((child) => child.name);
    Assert.AreEqual(mapped[0], child1.name);
    Assert.AreEqual(mapped[1], child2.name);
    Assert.AreEqual(mapped[2], child3.name);

    // map children with index
    mapped = t.MapChildren((child, index) => child.name + index);
    Assert.AreEqual(mapped[0], child1.name + 0);
    Assert.AreEqual(mapped[1], child2.name + 1);
    Assert.AreEqual(mapped[2], child3.name + 2);

    UnityEngine.Object.Destroy(go);
  }

  [Test]
  public void VectorExtensionTest() {
    var v2 = new Vector2(0, 0);
    Assert.AreEqual(v2.WithX(1).x, 1);
    Assert.AreEqual(v2.WithY(1).y, 1);
    // make sure we're not mutating the original vector
    Assert.AreNotEqual(v2.WithX(1).x, v2.x);

    var v3 = new Vector3(0, 0, 0);
    Assert.AreEqual(v3.WithX(1).x, 1);
    Assert.AreEqual(v3.WithY(1).y, 1);
    Assert.AreEqual(v3.WithZ(1).z, 1);
    // make sure we're not mutating the original vector
    Assert.AreNotEqual(v3.WithX(1).x, v3.x);
  }
}
