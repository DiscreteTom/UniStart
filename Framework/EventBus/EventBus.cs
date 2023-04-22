using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus : IEventBus {
    Dictionary<object, object> dict;

    public EventBus() {
      this.dict = new Dictionary<object, object>();
    }

    public UnityAction AddListener(object key, UnityAction action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent());
      }
      return ((CascadeEvent)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0> AddListener<T0>(object key, UnityAction<T0> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0>());
      }
      return ((CascadeEvent<T0>)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0, T1> AddListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0, T1>());
      }
      return ((CascadeEvent<T0, T1>)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0, T1, T2>());
      }
      return ((CascadeEvent<T0, T1, T2>)this.dict[key]).AddListener(action);
    }
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      if (!this.dict.ContainsKey(key)) {
        this.dict.Add(key, new CascadeEvent<T0, T1, T2, T3>());
      }
      return ((CascadeEvent<T0, T1, T2, T3>)this.dict[key]).AddListener(action);
    }

    public UnityAction RemoveListener(object key, UnityAction action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0> RemoveListener<T0>(object key, UnityAction<T0> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0>)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(object key, UnityAction<T0, T1> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0, T1>)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(object key, UnityAction<T0, T1, T2> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0, T1, T2>)this.dict[key]).RemoveListener(action);
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(object key, UnityAction<T0, T1, T2, T3> action) {
      if (!this.dict.ContainsKey(key)) {
        return null;
      }
      return ((CascadeEvent<T0, T1, T2, T3>)this.dict[key]).RemoveListener(action);
    }

    public void Invoke(object key) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent)this.dict[key]).Invoke();
    }
    public void Invoke<T0>(object key, T0 arg0) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0>)this.dict[key]).Invoke(arg0);
    }
    public void Invoke<T0, T1>(object key, T0 arg0, T1 arg1) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0, T1>)this.dict[key]).Invoke(arg0, arg1);
    }
    public void Invoke<T0, T1, T2>(object key, T0 arg0, T1 arg1, T2 arg2) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0, T1, T2>)this.dict[key]).Invoke(arg0, arg1, arg2);
    }
    public void Invoke<T0, T1, T2, T3>(object key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      if (!this.dict.ContainsKey(key)) {
        return;
      }
      ((CascadeEvent<T0, T1, T2, T3>)this.dict[key]).Invoke(arg0, arg1, arg2, arg3);
    }
  }
}