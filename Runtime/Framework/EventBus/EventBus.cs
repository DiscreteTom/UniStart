using System.Collections.Generic;
using UnityEngine.Events;

namespace DT.UniStart {
  public class EventBus<T> : IEventBus<T> {
    Dictionary<T, object> dict;

    public EventBus() {
      this.dict = new Dictionary<T, object>();
    }

    public UnityAction AddListener(T key, UnityAction action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent)o).AddListener(action);

      var e = new AdvancedEvent();
      e.AddListener(action);
      this.dict.Add(key, e);
      return action;
    }
    public UnityAction<T0> AddListener<T0>(T key, UnityAction<T0> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0>)o).AddListener(action);

      var e = new AdvancedEvent<T0>();
      e.AddListener(action);
      this.dict.Add(key, e);
      return action;
    }
    public UnityAction<T0, T1> AddListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0, T1>)o).AddListener(action);

      var e = new AdvancedEvent<T0, T1>();
      e.AddListener(action);
      this.dict.Add(key, e);
      return action;
    }
    public UnityAction<T0, T1, T2> AddListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0, T1, T2>)o).AddListener(action);

      var e = new AdvancedEvent<T0, T1, T2>();
      e.AddListener(action);
      this.dict.Add(key, e);
      return action;
    }
    public UnityAction<T0, T1, T2, T3> AddListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0, T1, T2, T3>)o).AddListener(action);

      var e = new AdvancedEvent<T0, T1, T2, T3>();
      e.AddListener(action);
      this.dict.Add(key, e);
      return action;
    }

    public UnityAction RemoveListener(T key, UnityAction action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent)o).RemoveListener(action);
      return null;
    }
    public UnityAction<T0> RemoveListener<T0>(T key, UnityAction<T0> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0>)o).RemoveListener(action);
      return null;
    }
    public UnityAction<T0, T1> RemoveListener<T0, T1>(T key, UnityAction<T0, T1> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0, T1>)o).RemoveListener(action);
      return null;
    }
    public UnityAction<T0, T1, T2> RemoveListener<T0, T1, T2>(T key, UnityAction<T0, T1, T2> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0, T1, T2>)o).RemoveListener(action);
      return null;
    }
    public UnityAction<T0, T1, T2, T3> RemoveListener<T0, T1, T2, T3>(T key, UnityAction<T0, T1, T2, T3> action) {
      if (this.dict.TryGetValue(key, out object o))
        return ((AdvancedEvent<T0, T1, T2, T3>)o).RemoveListener(action);
      return null;
    }

    public void Invoke(T key) {
      if (this.dict.TryGetValue(key, out object o))
        ((AdvancedEvent)o).Invoke();
    }
    public void Invoke<T0>(T key, T0 arg0) {
      if (this.dict.TryGetValue(key, out object o))
        ((AdvancedEvent<T0>)o).Invoke(arg0);
    }
    public void Invoke<T0, T1>(T key, T0 arg0, T1 arg1) {
      if (this.dict.TryGetValue(key, out object o))
        ((AdvancedEvent<T0, T1>)o).Invoke(arg0, arg1);
    }
    public void Invoke<T0, T1, T2>(T key, T0 arg0, T1 arg1, T2 arg2) {
      if (this.dict.TryGetValue(key, out object o))
        ((AdvancedEvent<T0, T1, T2>)o).Invoke(arg0, arg1, arg2);
    }
    public void Invoke<T0, T1, T2, T3>(T key, T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      if (this.dict.TryGetValue(key, out object o))
        ((AdvancedEvent<T0, T1, T2, T3>)o).Invoke(arg0, arg1, arg2, arg3);
    }
  }

  public class EventBus : EventBus<object>, IEventBus<object>, IEventBus { }
}