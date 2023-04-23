using UnityEngine.Events;

namespace DT.UniStart {
  /// <summary>
  /// UnityEvent which will return the action passed in when adding or removing a listener.
  /// </summary>
  public class CascadeEvent : UnityEvent, IWatchable {
    /// <summary>
    /// Add a listener to the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction AddListener(UnityAction action) {
      base.AddListener(action);
      return action;
    }

    /// <summary>
    /// Remove a listener from the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction RemoveListener(UnityAction action) {
      base.RemoveListener(action);
      return action;
    }
  }

  /// <summary>
  /// UnityEvent which will return the action passed in when adding or removing a listener.
  /// </summary>
  public class CascadeEvent<T0> : UnityEvent<T0>, IWatchable<T0> {
    /// <summary>
    /// Add a listener to the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0> AddListener(UnityAction<T0> action) {
      base.AddListener(action);
      return action;
    }

    /// <summary>
    /// Remove a listener from the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0> RemoveListener(UnityAction<T0> action) {
      base.RemoveListener(action);
      return action;
    }
  }

  /// <summary>
  /// UnityEvent which will return the action passed in when adding or removing a listener.
  /// </summary>
  public class CascadeEvent<T0, T1> : UnityEvent<T0, T1>, IWatchable<T0, T1> {
    /// <summary>
    /// Add a listener to the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0, T1> AddListener(UnityAction<T0, T1> action) {
      base.AddListener(action);
      return action;
    }

    /// <summary>
    /// Remove a listener from the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0, T1> RemoveListener(UnityAction<T0, T1> action) {
      base.RemoveListener(action);
      return action;
    }
  }

  /// <summary>
  /// UnityEvent which will return the action passed in when adding or removing a listener.
  /// </summary>
  public class CascadeEvent<T0, T1, T2> : UnityEvent<T0, T1, T2>, IWatchable<T0, T1, T2> {
    /// <summary>
    /// Add a listener to the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0, T1, T2> AddListener(UnityAction<T0, T1, T2> action) {
      base.AddListener(action);
      return action;
    }

    /// <summary>
    /// Remove a listener from the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0, T1, T2> RemoveListener(UnityAction<T0, T1, T2> action) {
      base.RemoveListener(action);
      return action;
    }
  }

  /// <summary>
  /// UnityEvent which will return the action passed in when adding or removing a listener.
  /// </summary>
  public class CascadeEvent<T0, T1, T2, T3> : UnityEvent<T0, T1, T2, T3>, IWatchable<T0, T1, T2, T3> {
    /// <summary>
    /// Add a listener to the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0, T1, T2, T3> AddListener(UnityAction<T0, T1, T2, T3> action) {
      base.AddListener(action);
      return action;
    }

    /// <summary>
    /// Remove a listener from the event.
    /// Return the action passed in so that it can be used in a cascade.
    /// </summary>
    public new UnityAction<T0, T1, T2, T3> RemoveListener(UnityAction<T0, T1, T2, T3> action) {
      base.RemoveListener(action);
      return action;
    }
  }
}