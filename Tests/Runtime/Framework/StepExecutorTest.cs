using NUnit.Framework;
using DT.UniStart;

public class StepExecutorTest {
  enum S {
    Step1,
    Step2
  }

  [Test]
  public void BasicTest() {
    var a = 0;
    IStepExecutor<S> se = new StepExecutor<S>();

    se.On(S.Step1).AddListener(() => a++);
    se.On(S.Step2).AddListener(() => a += 2);

    se.Invoke();
    Assert.AreEqual(3, a);
  }
}