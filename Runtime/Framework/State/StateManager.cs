using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class StateManager {
    #region Mutation Management
#if UNITY_EDITOR
    readonly HashSet<string> set = new();
#endif

    UnityEvent delayed = new();
    UnityEvent shadow = new();

    protected UnityAction Init(ref UnityAction mutation, UnityAction handler,
#if CSHARP_10
  // CallerArgumentExpression is implemented in the compiler for C# 10 and later versions only.
  [System.Runtime.CompilerServices.CallerArgumentExpression("mutation")]
#endif
    string name = "", bool debug = true
    ) {
#if UNITY_EDITOR
      this.Deduplication(name);
#endif

      mutation = () => {
#if UNITY_EDITOR
        if (debug && name.Length != 0)
          Debug.Log($"{name}");
#endif
        this.delayed.AddListener(() => handler.Invoke());
      };

      return handler;
    }

    protected UnityAction<T0> Init<T0>(ref UnityAction<T0> mutation, UnityAction<T0> handler,
#if CSHARP_10
  // CallerArgumentExpression is implemented in the compiler for C# 10 and later versions only.
  [System.Runtime.CompilerServices.CallerArgumentExpression("mutation")]
#endif
    string name = "", bool debug = true
    ) {
#if UNITY_EDITOR
      this.Deduplication(name);
#endif

      mutation = (arg0) => {
#if UNITY_EDITOR
        if (debug && name.Length != 0)
          Debug.Log($"{name} {arg0}");
#endif
        this.delayed.AddListener(() => handler.Invoke(arg0));
      };

      return handler;
    }

    protected UnityAction<T0, T1> Init<T0, T1>(ref UnityAction<T0, T1> mutation, UnityAction<T0, T1> handler,
#if CSHARP_10
  // CallerArgumentExpression is implemented in the compiler for C# 10 and later versions only.
  [System.Runtime.CompilerServices.CallerArgumentExpression("mutation")]
#endif
    string name = "", bool debug = true
    ) {
#if UNITY_EDITOR
      this.Deduplication(name);
#endif

      mutation = (arg0, arg1) => {
#if UNITY_EDITOR
        if (debug && name.Length != 0)
          Debug.Log($"{name} {arg0} {arg1}");
#endif
        this.delayed.AddListener(() => handler.Invoke(arg0, arg1));
      };

      return handler;
    }

    protected UnityAction<T0, T1, T2> Init<T0, T1, T2>(ref UnityAction<T0, T1, T2> mutation, UnityAction<T0, T1, T2> handler,
#if CSHARP_10
  // CallerArgumentExpression is implemented in the compiler for C# 10 and later versions only.
  [System.Runtime.CompilerServices.CallerArgumentExpression("mutation")]
#endif
    string name = "", bool debug = true
    ) {
#if UNITY_EDITOR
      this.Deduplication(name);
#endif

      mutation = (arg0, arg1, arg2) => {
#if UNITY_EDITOR
        if (debug && name.Length != 0)
          Debug.Log($"{name} {arg0} {arg1} {arg2}");
#endif
        this.delayed.AddListener(() => handler.Invoke(arg0, arg1, arg2));
      };

      return handler;
    }

    protected UnityAction<T0, T1, T2, T3> Init<T0, T1, T2, T3>(ref UnityAction<T0, T1, T2, T3> mutation, UnityAction<T0, T1, T2, T3> handler,
#if CSHARP_10
  // CallerArgumentExpression is implemented in the compiler for C# 10 and later versions only.
  [System.Runtime.CompilerServices.CallerArgumentExpression("mutation")]
#endif
    string name = "", bool debug = true
    ) {
#if UNITY_EDITOR
      this.Deduplication(name);
#endif

      mutation = (arg0, arg1, arg2, arg3) => {
#if UNITY_EDITOR
        if (debug && name.Length != 0)
          Debug.Log($"{name} {arg0} {arg1} {arg2} {arg3}");
#endif
        this.delayed.AddListener(() => handler.Invoke(arg0, arg1, arg2, arg3));
      };

      return handler;
    }

    public virtual void Execute() {
      // swap delayed and shadow to prevent modifying the delayed list while executing
      (this.delayed, this.shadow) = (this.shadow, this.delayed);

      this.shadow.Invoke();
      this.shadow.RemoveAllListeners();
    }

    public void Mount(IWatchable target) {
      target.AddListener(this.Execute);
    }

#if UNITY_EDITOR
    void Deduplication(string name) {
      if (name.Length == 0) return;
      if (!this.set.Add(name)) {
        throw new InvalidOperationException($"Mutation of name {name} already exists!");
      }
    }
#endif
    #endregion

    #region State Initializer
    protected Watch<T> Init<T>(ref IValueState<T> s, T value) => Assign(ref s, new Watch<T>(value));
    protected StateMachine<T> Init<T>(ref IEnumState<T> s, T value) where T : Enum => Assign(ref s, new StateMachine<T>(value));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, int count) => Assign(ref s, new WatchArray<T>(count));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, int count, T fill) => Assign(ref s, new WatchArray<T>(count, fill));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, int count, Func<T> factory) => Assign(ref s, new WatchArray<T>(count, factory));
    protected WatchArray<T> Init<T>(ref IArrayState<T> s, T[] value) => Assign(ref s, new WatchArray<T>(value));
    protected WatchList<T> Init<T>(ref IListState<T> s) => Assign(ref s, new WatchList<T>());
    protected WatchList<T> Init<T>(ref IListState<T> s, int count) => Assign(ref s, new WatchList<T>(count));
    protected WatchList<T> Init<T>(ref IListState<T> s, int count, T fill) => Assign(ref s, new WatchList<T>(count, fill));
    protected WatchList<T> Init<T>(ref IListState<T> s, int count, Func<T> factory) => Assign(ref s, new WatchList<T>(count, factory));
    protected WatchList<T> Init<T>(ref IListState<T> s, List<T> value) => Assign(ref s, new WatchList<T>(value));
    protected WatchDictionary<K, V> Init<K, V>(ref IDictionaryState<K, V> s) => Assign(ref s, new WatchDictionary<K, V>());
    protected WatchDictionary<K, V> Init<K, V>(ref IDictionaryState<K, V> s, Dictionary<K, V> value) => Assign(ref s, new WatchDictionary<K, V>(value));
    #endregion

    #region Const Collections
    protected T[] Init<T>(ref IReadOnlyList<T> s, int count) => Assign(ref s, new T[count]);
    protected T[] Init<T>(ref IReadOnlyList<T> s, int count, T fill) {
      var res = new T[count];
      res.Fill(fill);
      return Assign(ref s, res);
    }
    protected T[] Init<T>(ref IReadOnlyList<T> s, int count, Func<T> factory) {
      var res = new T[count];
      res.Fill(factory);
      return Assign(ref s, res);
    }
    protected Dictionary<K, V> Init<K, V>(ref IReadOnlyDictionary<K, V> s) => Assign(ref s, new Dictionary<K, V>());
    protected Watch<T>[] Init<T>(ref IReadOnlyList<IValueState<T>> s, int count) {
      var res = new Watch<T>[count];
      res.Fill(() => new Watch<T>(default));
      return Assign(ref s, res);
    }
    protected Watch<T>[] Init<T>(ref IReadOnlyList<IValueState<T>> s, int count, T fill) {
      var res = new Watch<T>[count];
      res.Fill(() => new Watch<T>(fill));
      return Assign(ref s, res);
    }
    protected StateMachine<T>[] Init<T>(ref IReadOnlyList<IEnumState<T>> s, int count) where T : Enum {
      var res = new StateMachine<T>[count];
      res.Fill(() => new StateMachine<T>(default));
      return Assign(ref s, res);
    }
    protected StateMachine<T>[] Init<T>(ref IReadOnlyList<IEnumState<T>> s, int count, T fill) where T : Enum {
      var res = new StateMachine<T>[count];
      res.Fill(() => new StateMachine<T>(fill));
      return Assign(ref s, res);
    }
    #endregion

    T Assign<T, S>(ref S state, T value) where T : S {
      state = value;
      return value;
    }
  }
}