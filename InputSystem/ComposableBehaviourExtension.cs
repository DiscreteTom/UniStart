using System;
using UnityEngine.InputSystem;

namespace DT.UniStart {
  public enum InputActionEventType {
    Started,
    Performed,
    Canceled
  }

  public static class ComposableBehaviourWithInputSystemExtension {
    #region Helper Methods for InputSystem
    // watch with remover
    public static Action<InputAction.CallbackContext> Watch(this ComposableBehaviour self, InputAction input, InputActionEventType type, IWatchable remover, Action<InputAction.CallbackContext> action) {
      switch (type) {
        case InputActionEventType.Started:
          input.started += action;
          remover.AddListener(() => input.started -= action);
          break;
        case InputActionEventType.Performed:
          input.performed += action;
          remover.AddListener(() => input.performed -= action);
          break;
        case InputActionEventType.Canceled:
          input.canceled += action;
          remover.AddListener(() => input.canceled -= action);
          break;
      }
      return action;
    }
    // remove listener on destroy
    public static Action<InputAction.CallbackContext> Watch(this ComposableBehaviour self, InputAction input, InputActionEventType type, Action<InputAction.CallbackContext> action) => self.Watch(input, type, self.onDestroy, action);
    #endregion
  }
}