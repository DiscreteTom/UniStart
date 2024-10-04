using System;
using DT.UniStart.Composable;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public interface IComposable {
    UniEvent<int> onAnimatorIK { get; }
    UniEvent onAnimatorMove { get; }
    UniEvent<bool> onApplicationFocus { get; }
    UniEvent<bool> onApplicationPause { get; }
    UniEvent onApplicationQuit { get; }
    UniEvent<float[], int> onAudioFilterRead { get; }
    UniEvent onBecameInvisible { get; }
    UniEvent onBecameVisible { get; }
    UniEvent<Collision> onCollisionEnter { get; }
    UniEvent<Collision2D> onCollisionEnter2D { get; }
    UniEvent<Collision> onCollisionExit { get; }
    UniEvent<Collision2D> onCollisionExit2D { get; }
    UniEvent<Collision> onCollisionStay { get; }
    UniEvent<Collision2D> onCollisionStay2D { get; }
    UniEvent<ControllerColliderHit> onControllerColliderHit { get; }
    UniEvent onDestroy { get; }
    UniEvent onDisable { get; }
    UniEvent onDrawGizmos { get; }
    UniEvent onDrawGizmosSelected { get; }
    UniEvent onEnable { get; }
    UniEvent onGUI { get; }
    UniEvent onFixedUpdate { get; }
    UniEvent<float> onJointBreak { get; }
    UniEvent<Joint2D> onJointBreak2D { get; }
    UniEvent onLateUpdate { get; }
    UniEvent onMouseDown { get; }
    UniEvent onMouseDrag { get; }
    UniEvent onMouseEnter { get; }
    UniEvent onMouseExit { get; }
    UniEvent onMouseOver { get; }
    UniEvent onMouseUp { get; }
    UniEvent onMouseUpAsButton { get; }
    UniEvent<GameObject> onParticleCollision { get; }
    UniEvent onParticleSystemStopped { get; }
    UniEvent onParticleTrigger { get; }
    UniEvent onParticleUpdateJobScheduled { get; }
    UniEvent onPostRender { get; }
    UniEvent onPreCull { get; }
    UniEvent onPreRender { get; }
    UniEvent<RenderTexture, RenderTexture> onRenderImage { get; }
    UniEvent onRenderObject { get; }
    UniEvent onReset { get; }
    UniEvent onTransformChildrenChanged { get; }
    UniEvent onTransformParentChanged { get; }
    UniEvent<Collider> onTriggerEnter { get; }
    UniEvent<Collider2D> onTriggerEnter2D { get; }
    UniEvent<Collider> onTriggerExit { get; }
    UniEvent<Collider2D> onTriggerExit2D { get; }
    UniEvent<Collider> onTriggerStay { get; }
    UniEvent<Collider2D> onTriggerStay2D { get; }
    UniEvent onUpdate { get; }
    UniEvent onValidate { get; }
    UniEvent onWillRenderObject { get; }
  }

  public class ComposableBehaviour : MonoBehaviour, IComposable {
    #region Composable Components
    public UniEvent<int> onAnimatorIK => this.GetOrAddComponent<ComposableAnimatorIK>().@event;
    public UniEvent onAnimatorMove => this.GetOrAddComponent<ComposableAnimatorMove>().@event;
    public UniEvent<bool> onApplicationFocus => this.GetOrAddComponent<ComposableApplicationFocus>().@event;
    public UniEvent<bool> onApplicationPause => this.GetOrAddComponent<ComposableApplicationPause>().@event;
    public UniEvent onApplicationQuit => this.GetOrAddComponent<ComposableApplicationQuit>().@event;
    public UniEvent<float[], int> onAudioFilterRead => this.GetOrAddComponent<ComposableAudioFilterRead>().@event;
    public UniEvent onBecameInvisible => this.GetOrAddComponent<ComposableBecameInvisible>().@event;
    public UniEvent onBecameVisible => this.GetOrAddComponent<ComposableBecameVisible>().@event;
    public UniEvent<Collision> onCollisionEnter => this.GetOrAddComponent<ComposableCollisionEnter>().@event;
    public UniEvent<Collision2D> onCollisionEnter2D => this.GetOrAddComponent<ComposableCollisionEnter2D>().@event;
    public UniEvent<Collision> onCollisionExit => this.GetOrAddComponent<ComposableCollisionExit>().@event;
    public UniEvent<Collision2D> onCollisionExit2D => this.GetOrAddComponent<ComposableCollisionExit2D>().@event;
    public UniEvent<Collision> onCollisionStay => this.GetOrAddComponent<ComposableCollisionStay>().@event;
    public UniEvent<Collision2D> onCollisionStay2D => this.GetOrAddComponent<ComposableCollisionStay2D>().@event;
    public UniEvent<ControllerColliderHit> onControllerColliderHit => this.GetOrAddComponent<ComposableControllerColliderHit>().@event;
    public UniEvent onDrawGizmos => this.GetOrAddComponent<ComposableDrawGizmos>().@event;
    public UniEvent onDrawGizmosSelected => this.GetOrAddComponent<ComposableDrawGizmosSelected>().@event;
    public UniEvent onGUI => this.GetOrAddComponent<ComposableGUI>().@event;
    public UniEvent onFixedUpdate => this.GetOrAddComponent<ComposableFixedUpdate>().@event;
    public UniEvent<float> onJointBreak => this.GetOrAddComponent<ComposableJointBreak>().@event;
    public UniEvent<Joint2D> onJointBreak2D => this.GetOrAddComponent<ComposableJointBreak2D>().@event;
    public UniEvent onLateUpdate => this.GetOrAddComponent<ComposableLateUpdate>().@event;
    public UniEvent onMouseDown => this.GetOrAddComponent<ComposableMouseDown>().@event;
    public UniEvent onMouseDrag => this.GetOrAddComponent<ComposableMouseDrag>().@event;
    public UniEvent onMouseEnter => this.GetOrAddComponent<ComposableMouseEnter>().@event;
    public UniEvent onMouseExit => this.GetOrAddComponent<ComposableMouseExit>().@event;
    public UniEvent onMouseOver => this.GetOrAddComponent<ComposableMouseOver>().@event;
    public UniEvent onMouseUp => this.GetOrAddComponent<ComposableMouseUp>().@event;
    public UniEvent onMouseUpAsButton => this.GetOrAddComponent<ComposableMouseUpAsButton>().@event;
    public UniEvent<GameObject> onParticleCollision => this.GetOrAddComponent<ComposableParticleCollision>().@event;
    public UniEvent onParticleSystemStopped => this.GetOrAddComponent<ComposableParticleSystemStopped>().@event;
    public UniEvent onParticleTrigger => this.GetOrAddComponent<ComposableParticleTrigger>().@event;
    public UniEvent onParticleUpdateJobScheduled => this.GetOrAddComponent<ComposableParticleUpdateJobScheduled>().@event;
    public UniEvent onPostRender => this.GetOrAddComponent<ComposablePostRender>().@event;
    public UniEvent onPreCull => this.GetOrAddComponent<ComposablePreCull>().@event;
    public UniEvent onPreRender => this.GetOrAddComponent<ComposablePreRender>().@event;
    public UniEvent<RenderTexture, RenderTexture> onRenderImage => this.GetOrAddComponent<ComposableRenderImage>().@event;
    public UniEvent onRenderObject => this.GetOrAddComponent<ComposableRenderObject>().@event;
    public UniEvent onReset => this.GetOrAddComponent<ComposableReset>().@event;
    public UniEvent onTransformChildrenChanged => this.GetOrAddComponent<ComposableTransformChildrenChanged>().@event;
    public UniEvent onTransformParentChanged => this.GetOrAddComponent<ComposableTransformParentChanged>().@event;
    public UniEvent<Collider> onTriggerEnter => this.GetOrAddComponent<ComposableTriggerEnter>().@event;
    public UniEvent<Collider2D> onTriggerEnter2D => this.GetOrAddComponent<ComposableTriggerEnter2D>().@event;
    public UniEvent<Collider> onTriggerExit => this.GetOrAddComponent<ComposableTriggerExit>().@event;
    public UniEvent<Collider2D> onTriggerExit2D => this.GetOrAddComponent<ComposableTriggerExit2D>().@event;
    public UniEvent<Collider> onTriggerStay => this.GetOrAddComponent<ComposableTriggerStay>().@event;
    public UniEvent<Collider2D> onTriggerStay2D => this.GetOrAddComponent<ComposableTriggerStay2D>().@event;
    public UniEvent onUpdate => this.GetOrAddComponent<ComposableUpdate>().@event;
    public UniEvent onValidate => this.GetOrAddComponent<ComposableValidate>().@event;
    public UniEvent onWillRenderObject => this.GetOrAddComponent<ComposableWillRenderObject>().@event;
    #endregion

    // See: https://github.com/DiscreteTom/UniStart/issues/9
    #region Component Level Events
    readonly LazyNew<UniEvent> _onDestroy = new();
    readonly LazyNew<UniEvent> _onDisable = new();
    readonly LazyNew<UniEvent> _onEnable = new();
    public UniEvent onDestroy => this._onDestroy.Value;
    public UniEvent onDisable => this._onDisable.Value;
    /// <summary>
    /// When being used in `Start`, you might want to invoke this immediately after adding a listener: `onEnable(...).Invoke()`
    /// because `OnEnable` is called before `Start`.
    /// </summary>
    public UniEvent onEnable => this._onEnable.Value;
    // make these protected to show a warning if the user want's to override them
    protected void OnDestroy() => this._onDestroy.RawValue?.Invoke();
    protected void OnDisable() => this._onDisable.RawValue?.Invoke();
    protected void OnEnable() => this._onEnable.RawValue?.Invoke();
    #endregion
  }

  public static class ComposableBehaviourExtension {
    #region Next Event
    public static UnityAction onNextUpdate(this ComposableBehaviour self, UnityAction action) => self.onUpdate.AddOnceListener(action);
    public static UnityAction onNextFixedUpdate(this ComposableBehaviour self, UnityAction action) => self.onFixedUpdate.AddOnceListener(action);
    public static UnityAction onNextLateUpdate(this ComposableBehaviour self, UnityAction action) => self.onLateUpdate.AddOnceListener(action);
    #endregion


    #region Helper Methods for IWatchable
    // Watch with remover
    public static UnityAction Watch(this ComposableBehaviour self, IWatchable watchable, IWatchable remover, UnityAction action) {
      watchable.AddListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0> Watch<T0>(this ComposableBehaviour self, IWatchable<T0> watchable, IWatchable remover, UnityAction<T0> action) {
      watchable.AddListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1> Watch<T0, T1>(this ComposableBehaviour self, IWatchable<T0, T1> watchable, IWatchable remover, UnityAction<T0, T1> action) {
      watchable.AddListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1, T2> Watch<T0, T1, T2>(this ComposableBehaviour self, IWatchable<T0, T1, T2> watchable, IWatchable remover, UnityAction<T0, T1, T2> action) {
      watchable.AddListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(this ComposableBehaviour self, IWatchable<T0, T1, T2, T3> watchable, IWatchable remover, UnityAction<T0, T1, T2, T3> action) {
      watchable.AddListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    // OnceWatch with remover
    public static UnityAction OnceWatch(this ComposableBehaviour self, IWatchable watchable, IWatchable remover, UnityAction action) {
      watchable.AddOnceListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0> OnceWatch<T0>(this ComposableBehaviour self, IWatchable<T0> watchable, IWatchable remover, UnityAction<T0> action) {
      watchable.AddOnceListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1> OnceWatch<T0, T1>(this ComposableBehaviour self, IWatchable<T0, T1> watchable, IWatchable remover, UnityAction<T0, T1> action) {
      watchable.AddOnceListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1, T2> OnceWatch<T0, T1, T2>(this ComposableBehaviour self, IWatchable<T0, T1, T2> watchable, IWatchable remover, UnityAction<T0, T1, T2> action) {
      watchable.AddOnceListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1, T2, T3> OnceWatch<T0, T1, T2, T3>(this ComposableBehaviour self, IWatchable<T0, T1, T2, T3> watchable, IWatchable remover, UnityAction<T0, T1, T2, T3> action) {
      watchable.AddOnceListener(action);
      remover.AddOnceListener(() => watchable.RemoveListener(action));
      return action;
    }
    // remove listener on destroy
    public static UnityAction Watch(this ComposableBehaviour self, IWatchable watchable, UnityAction action) => self.Watch(watchable, self.onDestroy, action);
    public static UnityAction<T0> Watch<T0>(this ComposableBehaviour self, IWatchable<T0> watchable, UnityAction<T0> action) => self.Watch(watchable, self.onDestroy, action);
    public static UnityAction<T0, T1> Watch<T0, T1>(this ComposableBehaviour self, IWatchable<T0, T1> watchable, UnityAction<T0, T1> action) => self.Watch(watchable, self.onDestroy, action);
    public static UnityAction<T0, T1, T2> Watch<T0, T1, T2>(this ComposableBehaviour self, IWatchable<T0, T1, T2> watchable, UnityAction<T0, T1, T2> action) => self.Watch(watchable, self.onDestroy, action);
    public static UnityAction<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(this ComposableBehaviour self, IWatchable<T0, T1, T2, T3> watchable, UnityAction<T0, T1, T2, T3> action) => self.Watch(watchable, self.onDestroy, action);
    // remove once listener on destroy
    public static UnityAction OnceWatch(this ComposableBehaviour self, IWatchable watchable, UnityAction action) => self.OnceWatch(watchable, self.onDestroy, action);
    public static UnityAction<T0> OnceWatch<T0>(this ComposableBehaviour self, IWatchable<T0> watchable, UnityAction<T0> action) => self.OnceWatch(watchable, self.onDestroy, action);
    public static UnityAction<T0, T1> OnceWatch<T0, T1>(this ComposableBehaviour self, IWatchable<T0, T1> watchable, UnityAction<T0, T1> action) => self.OnceWatch(watchable, self.onDestroy, action);
    public static UnityAction<T0, T1, T2> OnceWatch<T0, T1, T2>(this ComposableBehaviour self, IWatchable<T0, T1, T2> watchable, UnityAction<T0, T1, T2> action) => self.OnceWatch(watchable, self.onDestroy, action);
    public static UnityAction<T0, T1, T2, T3> OnceWatch<T0, T1, T2, T3>(this ComposableBehaviour self, IWatchable<T0, T1, T2, T3> watchable, UnityAction<T0, T1, T2, T3> action) => self.OnceWatch(watchable, self.onDestroy, action);
    #endregion

    #region Helper Methods for IEventListener
    // watch with remover
    public static UnityAction Watch<T>(this ComposableBehaviour self, IEventListener eventBus, IWatchable remover, UnityAction action) {
      eventBus.AddListener<T>(action);
      remover.AddOnceListener(() => eventBus.RemoveListener<T>(action));
      return action;
    }
    public static UnityAction<T> Watch<T>(this ComposableBehaviour self, IEventListener eventBus, IWatchable remover, UnityAction<T> action) {
      eventBus.AddListener(action);
      remover.AddOnceListener(() => eventBus.RemoveListener(action));
      return action;
    }
    // watch once with remover
    public static UnityAction OnceWatch<T>(this ComposableBehaviour self, IEventListener eventBus, IWatchable remover, UnityAction action) {
      eventBus.AddOnceListener<T>(action);
      remover.AddOnceListener(() => eventBus.RemoveListener<T>(action));
      return action;
    }
    public static UnityAction<T> OnceWatch<T>(this ComposableBehaviour self, IEventListener eventBus, IWatchable remover, UnityAction<T> action) {
      eventBus.AddOnceListener(action);
      remover.AddOnceListener(() => eventBus.RemoveListener(action));
      return action;
    }
    // remove listener on destroy
    public static UnityAction Watch<T>(this ComposableBehaviour self, IEventListener eventBus, UnityAction action) => self.Watch<T>(eventBus, self.onDestroy, action);
    public static UnityAction<T> Watch<T>(this ComposableBehaviour self, IEventListener eventBus, UnityAction<T> action) => self.Watch(eventBus, self.onDestroy, action);
    // remove once listener on destroy
    public static UnityAction OnceWatch<T>(this ComposableBehaviour self, IEventListener eventBus, UnityAction action) => self.OnceWatch<T>(eventBus, self.onDestroy, action);
    public static UnityAction<T> OnceWatch<T>(this ComposableBehaviour self, IEventListener eventBus, UnityAction<T> action) => self.OnceWatch(eventBus, self.onDestroy, action);
    #endregion

    #region Helper Methods for Action
    // Watch with remover
    public static Action Watch(this ComposableBehaviour self, Action target, IWatchable remover, Action action) {
      target += action;
      remover.AddOnceListener(() => target -= action);
      return action;
    }
    public static Action<T0> Watch<T0>(this ComposableBehaviour self, Action<T0> target, IWatchable remover, Action<T0> action) {
      target += action;
      remover.AddOnceListener(() => target -= action);
      return action;
    }
    public static Action<T0, T1> Watch<T0, T1>(this ComposableBehaviour self, Action<T0, T1> target, IWatchable remover, Action<T0, T1> action) {
      target += action;
      remover.AddOnceListener(() => target -= action);
      return action;
    }
    public static Action<T0, T1, T2> Watch<T0, T1, T2>(this ComposableBehaviour self, Action<T0, T1, T2> target, IWatchable remover, Action<T0, T1, T2> action) {
      target += action;
      remover.AddOnceListener(() => target -= action);
      return action;
    }
    public static Action<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(this ComposableBehaviour self, Action<T0, T1, T2, T3> target, IWatchable remover, Action<T0, T1, T2, T3> action) {
      target += action;
      remover.AddOnceListener(() => target -= action);
      return action;
    }
    // remove listener on destroy
    public static Action Watch(this ComposableBehaviour self, Action target, Action action) => self.Watch(target, self.onDestroy, action);
    public static Action<T0> Watch<T0>(this ComposableBehaviour self, Action<T0> target, Action<T0> action) => self.Watch(target, self.onDestroy, action);
    public static Action<T0, T1> Watch<T0, T1>(this ComposableBehaviour self, Action<T0, T1> target, Action<T0, T1> action) => self.Watch(target, self.onDestroy, action);
    public static Action<T0, T1, T2> Watch<T0, T1, T2>(this ComposableBehaviour self, Action<T0, T1, T2> target, Action<T0, T1, T2> action) => self.Watch(target, self.onDestroy, action);
    public static Action<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(this ComposableBehaviour self, Action<T0, T1, T2, T3> target, Action<T0, T1, T2, T3> action) => self.Watch(target, self.onDestroy, action);
    #endregion

    #region Helper Methods for UnityEvent
    // Watch with remover
    public static UnityAction Watch(this ComposableBehaviour self, UnityEvent e, IWatchable remover, UnityAction action) {
      e.AddListener(action);
      remover.AddOnceListener(() => e.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0> Watch<T0>(this ComposableBehaviour self, UnityEvent<T0> e, IWatchable remover, UnityAction<T0> action) {
      e.AddListener(action);
      remover.AddOnceListener(() => e.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1> Watch<T0, T1>(this ComposableBehaviour self, UnityEvent<T0, T1> e, IWatchable remover, UnityAction<T0, T1> action) {
      e.AddListener(action);
      remover.AddOnceListener(() => e.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1, T2> Watch<T0, T1, T2>(this ComposableBehaviour self, UnityEvent<T0, T1, T2> e, IWatchable remover, UnityAction<T0, T1, T2> action) {
      e.AddListener(action);
      remover.AddOnceListener(() => e.RemoveListener(action));
      return action;
    }
    public static UnityAction<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(this ComposableBehaviour self, UnityEvent<T0, T1, T2, T3> e, IWatchable remover, UnityAction<T0, T1, T2, T3> action) {
      e.AddListener(action);
      remover.AddOnceListener(() => e.RemoveListener(action));
      return action;
    }
    // remove listener on destroy
    public static UnityAction Watch(this ComposableBehaviour self, UnityEvent e, UnityAction action) => self.Watch(e, self.onDestroy, action);
    public static UnityAction<T0> Watch<T0>(this ComposableBehaviour self, UnityEvent<T0> e, UnityAction<T0> action) => self.Watch(e, self.onDestroy, action);
    public static UnityAction<T0, T1> Watch<T0, T1>(this ComposableBehaviour self, UnityEvent<T0, T1> e, UnityAction<T0, T1> action) => self.Watch(e, self.onDestroy, action);
    public static UnityAction<T0, T1, T2> Watch<T0, T1, T2>(this ComposableBehaviour self, UnityEvent<T0, T1, T2> e, UnityAction<T0, T1, T2> action) => self.Watch(e, self.onDestroy, action);
    public static UnityAction<T0, T1, T2, T3> Watch<T0, T1, T2, T3>(this ComposableBehaviour self, UnityEvent<T0, T1, T2, T3> e, UnityAction<T0, T1, T2, T3> action) => self.Watch(e, self.onDestroy, action);
    #endregion
  }
}