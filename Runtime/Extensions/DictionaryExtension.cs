using System;
using System.Collections;
using System.Collections.Generic;

namespace DT.UniStart {
  public static class DictionaryExtension {
    /// <summary>
    /// Returns the value associated with the specified key.
    /// If the key does not exist, use the factory to create a new value and add it to the dictionary,
    /// then return the new value.
    /// </summary>
    public static V GetOrAdd<K, V>(this Dictionary<K, V> dict, K key, Func<V> factory) {
      if (dict.TryGetValue(key, out var value)) return value;
      var t = factory.Invoke();
      dict.Add(key, t);
      return t;
    }
    /// <summary>
    /// Returns the value associated with the specified key.
    /// If the key does not exist, use the default constructor to create a new value and add it to the dictionary,
    /// then return the new value.
    public static V GetOrAddDefault<K, V>(this Dictionary<K, V> dict, K key) {
      return dict.GetOrAdd(key, () => default(V));
    }
    /// <summary>
    /// Returns the value associated with the specified key.
    /// If the key does not exist, create a new value and add it to the dictionary,
    /// then return the new value.
    /// </summary>
    public static V GetOrAddNew<K, V>(this Dictionary<K, V> dict, K key) where V : new() {
      return dict.GetOrAdd(key, () => new V());
    }
    /// <summary>
    /// Returns the value associated with the specified key.
    /// If the key does not exist, return the default value for type V.
    /// </summary>
    public static V GetOrDefault<K, V>(this Dictionary<K, V> dict, K key) {
      if (dict.TryGetValue(key, out var value)) return value;
      return default(V);
    }
  }
}