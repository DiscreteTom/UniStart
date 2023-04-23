using DT.UniStart.Composable;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public class ComposableBehaviour : MonoBehaviour {
    public T GetOrAddComponent<T>() where T : Component {
      T component = this.GetComponent<T>();
      if (component == null) {
        component = this.gameObject.AddComponent<T>();
      }
      return component;
    }

    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch(IWatchable watchable, UnityAction action) {
      var cb = watchable.AddListener(action);
      return this.onDestroy.AddListener(() => watchable.RemoveListener(cb));
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch<T0>(IWatchable<T0> watchable, UnityAction<T0> action) {
      var cb = watchable.AddListener(action);
      return this.onDestroy.AddListener(() => watchable.RemoveListener(cb));
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch<T0, T1>(IWatchable<T0, T1> watchable, UnityAction<T0, T1> action) {
      var cb = watchable.AddListener(action);
      return this.onDestroy.AddListener(() => watchable.RemoveListener(cb));
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch<T0, T1, T2>(IWatchable<T0, T1, T2> watchable, UnityAction<T0, T1, T2> action) {
      var cb = watchable.AddListener(action);
      return this.onDestroy.AddListener(() => watchable.RemoveListener(cb));
    }
    /// <summary>
    /// Watch a watchable for changes.
    /// Remove the listener when the object is destroyed.
    /// </summary>
    public UnityAction Watch<T0, T1, T2, T3>(IWatchable<T0, T1, T2, T3> watchable, UnityAction<T0, T1, T2, T3> action) {
      var cb = watchable.AddListener(action);
      return this.onDestroy.AddListener(() => watchable.RemoveListener(cb));
    }

    #region Composable Events without Cache
    public CascadeEvent<int> onAnimatorIK => this.GetOrAddComponent<ComposableAnimatorIK>().@event;
    public CascadeEvent onAnimatorMove => this.GetOrAddComponent<ComposableAnimatorMove>().@event;
    public CascadeEvent<bool> onApplicationFocus => this.GetOrAddComponent<ComposableApplicationFocus>().@event;
    public CascadeEvent<bool> onApplicationPause => this.GetOrAddComponent<ComposableApplicationPause>().@event;
    public CascadeEvent onApplicationQuit => this.GetOrAddComponent<ComposableApplicationQuit>().@event;
    public CascadeEvent<float[], int> onAudioFilterRead => this.GetOrAddComponent<ComposableAudioFilterRead>().@event;
    public CascadeEvent onBecameInvisible => this.GetOrAddComponent<ComposableBecameInvisible>().@event;
    public CascadeEvent onBecameVisible => this.GetOrAddComponent<ComposableBecameVisible>().@event;
    public CascadeEvent<Collision> onCollisionEnter => this.GetOrAddComponent<ComposableCollisionEnter>().@event;
    public CascadeEvent<Collision2D> onCollisionEnter2D => this.GetOrAddComponent<ComposableCollisionEnter2D>().@event;
    public CascadeEvent<Collision> onCollisionExit => this.GetOrAddComponent<ComposableCollisionExit>().@event;
    public CascadeEvent<Collision2D> onCollisionExit2D => this.GetOrAddComponent<ComposableCollisionExit2D>().@event;
    public CascadeEvent<Collision> onCollisionStay => this.GetOrAddComponent<ComposableCollisionStay>().@event;
    public CascadeEvent<Collision2D> onCollisionStay2D => this.GetOrAddComponent<ComposableCollisionStay2D>().@event;
    public CascadeEvent<ControllerColliderHit> onControllerColliderHit => this.GetOrAddComponent<ComposableControllerColliderHit>().@event;
    public CascadeEvent onDestroy => this.GetOrAddComponent<ComposableDestroy>().@event;
    public CascadeEvent onDisable => this.GetOrAddComponent<ComposableDisable>().@event;
    public CascadeEvent onDrawGizmos => this.GetOrAddComponent<ComposableDrawGizmos>().@event;
    public CascadeEvent onDrawGizmosSelected => this.GetOrAddComponent<ComposableDrawGizmosSelected>().@event;
    public CascadeEvent onEnable => this.GetOrAddComponent<ComposableEnable>().@event;
    public CascadeEvent onGUI => this.GetOrAddComponent<ComposableGUI>().@event;
    public CascadeEvent onFixedUpdate => this.GetOrAddComponent<ComposableFixedUpdate>().@event;
    public CascadeEvent<float> onJointBreak => this.GetOrAddComponent<ComposableJointBreak>().@event;
    public CascadeEvent<Joint2D> onJointBreak2D => this.GetOrAddComponent<ComposableJointBreak2D>().@event;
    public CascadeEvent onLateUpdate => this.GetOrAddComponent<ComposableLateUpdate>().@event;
    public CascadeEvent onMouseDown => this.GetOrAddComponent<ComposableMouseDown>().@event;
    public CascadeEvent onMouseDrag => this.GetOrAddComponent<ComposableMouseDrag>().@event;
    public CascadeEvent onMouseEnter => this.GetOrAddComponent<ComposableMouseEnter>().@event;
    public CascadeEvent onMouseExit => this.GetOrAddComponent<ComposableMouseExit>().@event;
    public CascadeEvent onMouseOver => this.GetOrAddComponent<ComposableMouseOver>().@event;
    public CascadeEvent onMouseUp => this.GetOrAddComponent<ComposableMouseUp>().@event;
    public CascadeEvent onMouseUpAsButton => this.GetOrAddComponent<ComposableMouseUpAsButton>().@event;
    public CascadeEvent onNextFixedUpdate => this.GetOrAddComponent<ComposableNextFixedUpdate>().@event;
    public CascadeEvent onNextLateUpdate => this.GetOrAddComponent<ComposableNextLateUpdate>().@event;
    public CascadeEvent onNextUpdate => this.GetOrAddComponent<ComposableNextUpdate>().@event;
    public CascadeEvent<GameObject> onParticleCollision => this.GetOrAddComponent<ComposableParticleCollision>().@event;
    public CascadeEvent onParticleSystemStopped => this.GetOrAddComponent<ComposableParticleSystemStopped>().@event;
    public CascadeEvent onParticleTrigger => this.GetOrAddComponent<ComposableParticleTrigger>().@event;
    public CascadeEvent onParticleUpdateJobScheduled => this.GetOrAddComponent<ComposableParticleUpdateJobScheduled>().@event;
    public CascadeEvent onPostRender => this.GetOrAddComponent<ComposablePostRender>().@event;
    public CascadeEvent onPreCull => this.GetOrAddComponent<ComposablePreCull>().@event;
    public CascadeEvent onPreRender => this.GetOrAddComponent<ComposablePreRender>().@event;
    public CascadeEvent<RenderTexture, RenderTexture> onRenderImage => this.GetOrAddComponent<ComposableRenderImage>().@event;
    public CascadeEvent onRenderObject => this.GetOrAddComponent<ComposableRenderObject>().@event;
    public CascadeEvent onReset => this.GetOrAddComponent<ComposableReset>().@event;
    public CascadeEvent onTransformChildrenChanged => this.GetOrAddComponent<ComposableTransformChildrenChanged>().@event;
    public CascadeEvent onTransformParentChanged => this.GetOrAddComponent<ComposableTransformParentChanged>().@event;
    public CascadeEvent<Collider> onTriggerEnter => this.GetOrAddComponent<ComposableTriggerEnter>().@event;
    public CascadeEvent<Collider2D> onTriggerEnter2D => this.GetOrAddComponent<ComposableTriggerEnter2D>().@event;
    public CascadeEvent<Collider> onTriggerExit => this.GetOrAddComponent<ComposableTriggerExit>().@event;
    public CascadeEvent<Collider2D> onTriggerExit2D => this.GetOrAddComponent<ComposableTriggerExit2D>().@event;
    public CascadeEvent<Collider> onTriggerStay => this.GetOrAddComponent<ComposableTriggerStay>().@event;
    public CascadeEvent<Collider2D> onTriggerStay2D => this.GetOrAddComponent<ComposableTriggerStay2D>().@event;
    public CascadeEvent onUpdate => this.GetOrAddComponent<ComposableUpdate>().@event;
    public CascadeEvent onValidate => this.GetOrAddComponent<ComposableValidate>().@event;
    public CascadeEvent onWillRenderObject => this.GetOrAddComponent<ComposableWillRenderObject>().@event;
    #endregion
  }
}