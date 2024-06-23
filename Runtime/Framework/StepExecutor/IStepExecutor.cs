using System;

namespace DT.UniStart {
  public interface IStepListener<S> where S : IConvertible {
    AdvancedEvent On(S step);
  }
  public interface IStepListener<S, T> where S : IConvertible {
    AdvancedEvent<T> On(S step);
  }

  public interface IStepInvoker<S> where S : IConvertible {
    void Invoke();
  }
  public interface IStepInvoker<S, T> where S : IConvertible {
    void Invoke(T ctx);
  }

  public interface IStepExecutor<S> : IStepListener<S>, IStepInvoker<S> where S : IConvertible { }
  public interface IStepExecutor<S, T> : IStepListener<S, T>, IStepInvoker<S, T> where S : IConvertible { }

  public static class IStepExecutorExtension {
    public static void Invoke<S, T>(this IStepExecutor<S, T> self) where S : IConvertible where T : new() => self.Invoke(new());
  }
}
