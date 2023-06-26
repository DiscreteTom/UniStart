using System;
using DT.UniStart.Composable;
using UnityEngine;
using UnityEngine.Events;

namespace DT.UniStart {
  public interface IComposable {
    AdvancedEvent<int> onAnimatorIK { get; }
    AdvancedEvent onAnimatorMove { get; }
    AdvancedEvent<bool> onApplicationFocus { get; }
    AdvancedEvent<bool> onApplicationPause { get; }
    AdvancedEvent onApplicationQuit { get; }
    AdvancedEvent<float[], int> onAudioFilterRead { get; }
    AdvancedEvent onBecameInvisible { get; }
    AdvancedEvent onBecameVisible { get; }
    AdvancedEvent<Collision> onCollisionEnter { get; }
    AdvancedEvent<Collision2D> onCollisionEnter2D { get; }
    AdvancedEvent<Collision> onCollisionExit { get; }
    AdvancedEvent<Collision2D> onCollisionExit2D { get; }
    AdvancedEvent<Collision> onCollisionStay { get; }
    AdvancedEvent<Collision2D> onCollisionStay2D { get; }
    AdvancedEvent<ControllerColliderHit> onControllerColliderHit { get; }
    AdvancedEvent onDestroy { get; }
    AdvancedEvent onDisable { get; }
    AdvancedEvent onDrawGizmos { get; }
    AdvancedEvent onDrawGizmosSelected { get; }
    AdvancedEvent onEnable { get; }
    AdvancedEvent onGUI { get; }
    AdvancedEvent onFixedUpdate { get; }
    AdvancedEvent<float> onJointBreak { get; }
    AdvancedEvent<Joint2D> onJointBreak2D { get; }
    AdvancedEvent onLateUpdate { get; }
    AdvancedEvent onMouseDown { get; }
    AdvancedEvent onMouseDrag { get; }
    AdvancedEvent onMouseEnter { get; }
    AdvancedEvent onMouseExit { get; }
    AdvancedEvent onMouseOver { get; }
    AdvancedEvent onMouseUp { get; }
    AdvancedEvent onMouseUpAsButton { get; }
    AdvancedEvent onNextFixedUpdate { get; }
    AdvancedEvent onNextLateUpdate { get; }
    AdvancedEvent onNextUpdate { get; }
    AdvancedEvent<GameObject> onParticleCollision { get; }
    AdvancedEvent onParticleSystemStopped { get; }
    AdvancedEvent onParticleTrigger { get; }
    AdvancedEvent onParticleUpdateJobScheduled { get; }
    AdvancedEvent onPostRender { get; }
    AdvancedEvent onPreCull { get; }
    AdvancedEvent onPreRender { get; }
    AdvancedEvent<RenderTexture, RenderTexture> onRenderImage { get; }
    AdvancedEvent onRenderObject { get; }
    AdvancedEvent onReset { get; }
    AdvancedEvent onTransformChildrenChanged { get; }
    AdvancedEvent onTransformParentChanged { get; }
    AdvancedEvent<Collider> onTriggerEnter { get; }
    AdvancedEvent<Collider2D> onTriggerEnter2D { get; }
    AdvancedEvent<Collider> onTriggerExit { get; }
    AdvancedEvent<Collider2D> onTriggerExit2D { get; }
    AdvancedEvent<Collider> onTriggerStay { get; }
    AdvancedEvent<Collider2D> onTriggerStay2D { get; }
    AdvancedEvent onUpdate { get; }
    AdvancedEvent onValidate { get; }
    AdvancedEvent onWillRenderObject { get; }
  }

  public class ComposableBehaviour : MonoBehaviour, IComposable {
    IoCC ioc = new IoCC(); // cache for components

    /// <summary>
    /// Try to get a component from the cache.
    /// If it doesn't exist, try to get it from the game object.
    /// If it still doesn't exist, add it to the game object and cache it.
    /// </summary>
    public T GetOrAddComponent<T>() where T : Component {
      // IMPORTANT: don't use `??` to check for null, because Unity overrides the == operator
      T res = this.ioc.TryGet<T>();
      if (res != null) return res;
      res = this.gameObject.GetComponent<T>();
      if (res != null) return this.ioc.Add<T>(res);
      return this.ioc.Add<T>(this.gameObject.AddComponent<T>());
    }

    public AdvancedEvent<int> onAnimatorIK => this.GetOrAddComponent<ComposableAnimatorIK>().@event;
    public AdvancedEvent onAnimatorMove => this.GetOrAddComponent<ComposableAnimatorMove>().@event;
    public AdvancedEvent<bool> onApplicationFocus => this.GetOrAddComponent<ComposableApplicationFocus>().@event;
    public AdvancedEvent<bool> onApplicationPause => this.GetOrAddComponent<ComposableApplicationPause>().@event;
    public AdvancedEvent onApplicationQuit => this.GetOrAddComponent<ComposableApplicationQuit>().@event;
    public AdvancedEvent<float[], int> onAudioFilterRead => this.GetOrAddComponent<ComposableAudioFilterRead>().@event;
    public AdvancedEvent onBecameInvisible => this.GetOrAddComponent<ComposableBecameInvisible>().@event;
    public AdvancedEvent onBecameVisible => this.GetOrAddComponent<ComposableBecameVisible>().@event;
    public AdvancedEvent<Collision> onCollisionEnter => this.GetOrAddComponent<ComposableCollisionEnter>().@event;
    public AdvancedEvent<Collision2D> onCollisionEnter2D => this.GetOrAddComponent<ComposableCollisionEnter2D>().@event;
    public AdvancedEvent<Collision> onCollisionExit => this.GetOrAddComponent<ComposableCollisionExit>().@event;
    public AdvancedEvent<Collision2D> onCollisionExit2D => this.GetOrAddComponent<ComposableCollisionExit2D>().@event;
    public AdvancedEvent<Collision> onCollisionStay => this.GetOrAddComponent<ComposableCollisionStay>().@event;
    public AdvancedEvent<Collision2D> onCollisionStay2D => this.GetOrAddComponent<ComposableCollisionStay2D>().@event;
    public AdvancedEvent<ControllerColliderHit> onControllerColliderHit => this.GetOrAddComponent<ComposableControllerColliderHit>().@event;
    public AdvancedEvent onDestroy => this.GetOrAddComponent<ComposableDestroy>().@event;
    [Obsolete("See https://github.com/DiscreteTom/UniStart/issues/9.")]
    public AdvancedEvent onDisable => this.GetOrAddComponent<ComposableDisable>().@event;
    public AdvancedEvent onDrawGizmos => this.GetOrAddComponent<ComposableDrawGizmos>().@event;
    public AdvancedEvent onDrawGizmosSelected => this.GetOrAddComponent<ComposableDrawGizmosSelected>().@event;
    [Obsolete("See https://github.com/DiscreteTom/UniStart/issues/9.")]
    public AdvancedEvent onEnable => this.GetOrAddComponent<ComposableEnable>().@event;
    public AdvancedEvent onGUI => this.GetOrAddComponent<ComposableGUI>().@event;
    public AdvancedEvent onFixedUpdate => this.GetOrAddComponent<ComposableFixedUpdate>().@event;
    public AdvancedEvent<float> onJointBreak => this.GetOrAddComponent<ComposableJointBreak>().@event;
    public AdvancedEvent<Joint2D> onJointBreak2D => this.GetOrAddComponent<ComposableJointBreak2D>().@event;
    public AdvancedEvent onLateUpdate => this.GetOrAddComponent<ComposableLateUpdate>().@event;
    public AdvancedEvent onMouseDown => this.GetOrAddComponent<ComposableMouseDown>().@event;
    public AdvancedEvent onMouseDrag => this.GetOrAddComponent<ComposableMouseDrag>().@event;
    public AdvancedEvent onMouseEnter => this.GetOrAddComponent<ComposableMouseEnter>().@event;
    public AdvancedEvent onMouseExit => this.GetOrAddComponent<ComposableMouseExit>().@event;
    public AdvancedEvent onMouseOver => this.GetOrAddComponent<ComposableMouseOver>().@event;
    public AdvancedEvent onMouseUp => this.GetOrAddComponent<ComposableMouseUp>().@event;
    public AdvancedEvent onMouseUpAsButton => this.GetOrAddComponent<ComposableMouseUpAsButton>().@event;
    public AdvancedEvent onNextFixedUpdate => this.GetOrAddComponent<ComposableNextFixedUpdate>().@event;
    public AdvancedEvent onNextLateUpdate => this.GetOrAddComponent<ComposableNextLateUpdate>().@event;
    public AdvancedEvent onNextUpdate => this.GetOrAddComponent<ComposableNextUpdate>().@event;
    public AdvancedEvent<GameObject> onParticleCollision => this.GetOrAddComponent<ComposableParticleCollision>().@event;
    public AdvancedEvent onParticleSystemStopped => this.GetOrAddComponent<ComposableParticleSystemStopped>().@event;
    public AdvancedEvent onParticleTrigger => this.GetOrAddComponent<ComposableParticleTrigger>().@event;
    public AdvancedEvent onParticleUpdateJobScheduled => this.GetOrAddComponent<ComposableParticleUpdateJobScheduled>().@event;
    public AdvancedEvent onPostRender => this.GetOrAddComponent<ComposablePostRender>().@event;
    public AdvancedEvent onPreCull => this.GetOrAddComponent<ComposablePreCull>().@event;
    public AdvancedEvent onPreRender => this.GetOrAddComponent<ComposablePreRender>().@event;
    public AdvancedEvent<RenderTexture, RenderTexture> onRenderImage => this.GetOrAddComponent<ComposableRenderImage>().@event;
    public AdvancedEvent onRenderObject => this.GetOrAddComponent<ComposableRenderObject>().@event;
    public AdvancedEvent onReset => this.GetOrAddComponent<ComposableReset>().@event;
    public AdvancedEvent onTransformChildrenChanged => this.GetOrAddComponent<ComposableTransformChildrenChanged>().@event;
    public AdvancedEvent onTransformParentChanged => this.GetOrAddComponent<ComposableTransformParentChanged>().@event;
    public AdvancedEvent<Collider> onTriggerEnter => this.GetOrAddComponent<ComposableTriggerEnter>().@event;
    public AdvancedEvent<Collider2D> onTriggerEnter2D => this.GetOrAddComponent<ComposableTriggerEnter2D>().@event;
    public AdvancedEvent<Collider> onTriggerExit => this.GetOrAddComponent<ComposableTriggerExit>().@event;
    public AdvancedEvent<Collider2D> onTriggerExit2D => this.GetOrAddComponent<ComposableTriggerExit2D>().@event;
    public AdvancedEvent<Collider> onTriggerStay => this.GetOrAddComponent<ComposableTriggerStay>().@event;
    public AdvancedEvent<Collider2D> onTriggerStay2D => this.GetOrAddComponent<ComposableTriggerStay2D>().@event;
    public AdvancedEvent onUpdate => this.GetOrAddComponent<ComposableUpdate>().@event;
    public AdvancedEvent onValidate => this.GetOrAddComponent<ComposableValidate>().@event;
    public AdvancedEvent onWillRenderObject => this.GetOrAddComponent<ComposableWillRenderObject>().@event;
  }
}