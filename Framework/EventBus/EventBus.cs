using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus<T> : IEventBus<T> {
    Dictionary<T, object> dict;

    public EventBus() {
      this.dict = new Dictionary<T, object>();
    }

    public UnityAction AddListener(T key, UnityAction action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent());
      }
      return ((CascadeEvent)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0>());
      }
      return ((CascadeEvent<T0>)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0, T1>());
      }
      return ((CascadeEvent<T0, T1>)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0, T1, T2>());
      }
      return ((CascadeEvent<T0, T1, T2>)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0, T1, T2, T3>());
      }
      return ((CascadeEvent<T0, T1, T2, T3>)this.dict[key]).AddListener(action);
    }

    public UnityAction RemoveListener(T key, UnityAction action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0>)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0, T1>)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0, T1, T2>)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0, T1, T2, T3>)this.dict[key]).RemoveListener(action);
    }

    public void Invoke(T key) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent)this.dict[key]).Invoke();
    }
    public void Invoke<T0>(T key, T0 arg0) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0>)this.dict[key]).Invoke(arg0);
    }
    public void Invoke<T0, T1>(T key, T0 arg0, T1 arg1) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0, T1>)this.dict[key]).Invoke(arg0, arg1);
    }
    public void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0, T1, T2>)this.dict[key]).Invoke(arg0, arg1, arg2);
    }
    public void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0, T1, T2, T3>)this.dict[key]).Invoke(arg0, arg1, arg2, arg3);
    }
  }

  public class EventBus : EventBus<object>, IEventBus<object>, IEventBus { }
}