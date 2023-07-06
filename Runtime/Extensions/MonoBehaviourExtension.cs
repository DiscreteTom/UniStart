using System;
using System.Collections;
using UnityEngine;

namespace DT.UniStart {
  public static class MonoBehaviourExtension {
    public static void Invoke(this MonoBehaviour mb, Action f, float delay) {
      static IEnumerator InvokeRoutine(Action f, float delay) {
        yield return new WaitForSeconds(delay);
        f();
      }
      mb.StartCoroutine(InvokeRoutine(f, delay));
    }

    public static void InvokeRepeating(this MonoBehaviour mb, Action f, float delay, float interval) {
      static IEnumerator InvokeRepeatingRoutine(Action f, float delay, float interval) {
        yield return new WaitForSeconds(delay);
        while (true) {
          f();
          yield return new WaitForSeconds(interval);
        }
      }
      mb.StartCoroutine(InvokeRepeatingRoutine(f, delay, interval));
    }

    /// <summary>
    /// Try to get a component from the game object.
    /// If it doesn't exist, add it to the game object and return it.
    /// </summary>
    public static T GetOrAddComponent<T>(this MonoBehaviour mb) where T : Component {
      // IMPORTANT: don't use `??` to check for null, because Unity overrides the == operator
      var res = mb.gameObject.GetComponent<T>();
      if (res != null) return res;
      return mb.gameObject.AddComponent<T>();
    }
  }
}