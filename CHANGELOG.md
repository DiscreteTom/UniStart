# CHANGELOG

## v13.0.0

- **_Breaking Change_**: remove all `RemoveOnceListener` methods.
  - Use `RemoveListener` instead of `RemoveOnceListener` to remove once listeners.
- **_Breaking Change_**: remove `CBC.Add` and `UniStartBehaviour.Add`.
- **_Breaking Change_**: `Entry.GetContext` will search parent first instead of the root object.
- **_Breaking Change_**: remove `InterceptEventBus`.
  - Make `EventBus` methods virtual. You can override them to realize the same effect.
- **_Breaking Change_**: rename `IWritableCommandBus` to `ICommandCenter`, remove `ICommandRepo.Get`, rename `CommandBus` to `CommandCenter`, `DelayedCommandBus` to `DelayedCommandCenter`.
- **_Breaking Change_**: adding the same type to `CommandCenter` multi times will throw exception.
- **_Breaking Change_**: rewrite `DebugCommandBus` to only log `Push` events.
- **_Breaking Change_**: rename `WatchRef/WatchIList/WatchIDictionary.ReadOnlyCommit` to `MutedCommit`.
- **_Breaking Change_**: rename `IState` to `IValueState`.
- **_Breaking Change_**: rewrite `IStateMachine` and `StateMachine`, remove `DebugStateMachine`.
- **_Breaking Change_**: rewrite `IStepExecutor`, `StepExecutor` and `DebugStepExecutor`, remove `InterceptStepExecutor`.
- **_Breaking Change_**: rewrite `StateManager`.
- **_Breaking Change_**: remove echoed `Watch` for InputSystem events.
- **_Breaking Change_**: use `List` to store timers in `TimerManager` to make sure callbacks are called in the order they are added.
- **_Breaking Change_**: remove `TimerManager`.
- **_Breaking Change_**: remove `Box`.
- Feat: add interface `IReadonlyIoC`.
- Feat: add `ComponentExtension.GetOrAddComponent`.
- Feat: add `IReadonlyIoC.GetEventBus`, `IReadonlyIoC.GetCommandBus`, `IReadonlyIoC.GetStepExecutor`, `IIoCC.AddEventBus`, `IIoCC.AddCommandBus` and `IIoCC.AddStepExecutor`.
- Feat: make `DelayedEventBus.InvokeDelayed` virtual.
- Feat: add `DelayedEventBus.Mount`.
- Feat: add `CommandCenter.With`.
- Feat: add `DelayedCommandCenter.Mount`.
- Feat: make `Watch.AddListener/RemoveListener/AddOnceListener` virtual.
- Feat: add protected virtual `Watch.InvokeEvent`.
- Feat: make `Computed` implement `IValueState`.
- Feat: add more constructors for `WatchIList/WatchList/WatchArray`.
- Feat: add `IGetValue.GetValue`.
- Feat: add `IArrayState`, make `WatchArray` implement `IArrayState`.
- Feat: add `Timer.UpdateWithDelta` and `Timer.Mount`.
- Feat: accept callback in constructor of `Timer/RepeatedTimer`.
- Fix: `AdvancedEvent` will call actions and once actions by the order they are added.
  - Previously all once actions will be called after repeated actions.
- Fix: `AdvancedEvent` allow adding listeners or remove listeners during the invocation.
  - `this.onNextUpdate(() => this.onNextUpdate(() => print(1)));` will work properly.
- Fix: `DelayedEventBus` and `DelayedCommandCenter` behave correctly when being recursively invoked during the invocation.

## v12.0.1

- Perf: optimize the performance of `AdvancedEvent`.

## v12.0.0

- **_Breaking Change_**: remove `TransformExtension.SetRotationX/Y/Z/W` and `SetLocalRotationX/Y/Z/W`.
- **_Breaking Change_**: rename `Readonly` to `ReadOnly`. #30
- Note: refactor `AdvancedEvent` family to optimize performance.
- Note: add tests. #18

## v11.3.0

- Feat: `Array/IList.Fill` support `factory` as parameter to create reference types.
  - `IStateManager.AddList/AddArray/AddConstArray` support `factory` as parameter to create reference types.
- Fix: `IStateManager.AddStateArray/AddEnumArray` will call factory to create elements.

## v11.2.0

- Feat: add `fill` for `IStateManager.AddList/AddArray`. #32

## v11.1.0

- Feat: `ComposableBehaviour.Watch` support `IReadonlyStateMachine` instead of `IStateMachine`. #29
- Fix: `ComposableBehaviour.OnceWatch` should call `RemoveOnceListener`. #31
- Fix: remove `ComposableBehaviour.OnceWatch` for `Action`.

## v11.0.0

- **_Breaking Change_**: remove echoed events.
  - `AddListener/RemoveListener/AddOnceListener/RemoveOnceListener` no long have `out` parameter.
- **_Breaking Change_**: remove reversed functions in `IStateManager`.
- **_Breaking Change_**: rewrite `onNextUpdate/onNextFixedUpdate/onNextLateUpdate`. #25
- Feat: add `StepExecutor` family. #28
- Feat: add `StateMachine` family.
- Feat: add `IEnumState`.
- Feat: add `IStateManager.AddConstX/AddXArray` for const collections and watchable arrays.
- Feat: add `ICommandRepo.Get`.

## v10.1.0

- Feat: `ComposableBehaviour.Watch` support `InputSystem.InputAction`. Fix 24.
  - Add `InputActionEventType`.

## v10.0.0

- **_Breaking Change_**: add `ICommand/IEvent` for `CommandBus/EventBus` family for better intellisense. Fix #20.
  - All commands and events should implement `ICommand/IEvent`.
- **_Breaking Change_**: rewrite `AdvancedEvent` family.
  - Fix: generic `AdvancedEvent` can no longer call `Invoke` without params.
  - Fix: once listeners will be cleared correctly.
  - Note: use `IWatchable.RemoveOnceListener` to remove once listeners.
- Feat: more `ArrayExtension` methods. Fix #21.
- Feat: `ComposableBehaviour.Watch` support `Action/UnityEvent`. Fix #22.
- Feat: customizable remover for `ComposableBehaviour.Watch`. Fix #23.
- Feat: add `IListExtension.Fill`.
- Feat: add `UnityEventExtension`.

## v9.0.0

- **_Breaking Change_**: rewrite `IState/IStateManager`.
  - Remove `ICommittableList/ICommittableDictionary/IWritableState/IWritableListState/IWritableDictionaryState/IStateCommitter`.
  - Rewrite `IStateManager`.
- Feat: add `Timer/RepeatedTimer/TimerManager`.
- Note: add a sample `UniSnake`.

## v8.0.0

- **_Breaking Change_**: remove `IOnceWatchable`, use `IWatchable` instead.
- **_Breaking Change_**: rename `WatchRef.Apply` to `WatchRef.Commit`.
- **_Breaking Change_**: rewrite `CommandBus` family.
  - Remove `CommandRepo`, `ICommandRepo.Invoke`.
  - `ICommandRepo.Add` return the `UnityAction` instead of `ICommandRepo`.
  - Add `DebugCommandBus/DelayedCommandBus`.
- **_Breaking Change_**: remove `DebugEventBusMode`, use `InterceptEventBusMode` instead.
  - Add `InterceptEventBus`. Fix #2.
  - Rewrite `DebugEventBus/DelayedEventBus` using `InterceptEventBus`.
- Feat: add `Computed/LazyComputed.UnWatch`.
- Feat: add `IIoCC.Contains/TryGet`.
- Feat: add `Box`.
- Feat: add `IGetValue/ISetValue/IGetSetValue`.
- Feat: add `State` family.
- Fix: make `WatchRef.InvokeEvent` virtual and public, make watch collections override `InvokeEvent` to fix `Apply`.
- Note: move helper methods for `IWatchable/IEventListener` from `UniStartBehaviour` to `ComposableBehaviourExtension`.
- Optimize code.

## v7.0.0

- **_Breaking Change_**: rewrite `AdvancedEvent`, remove `RemoveOnceListener`.
  - Enhanced `AdvancedEvent/IEventBus/IWatchable` etc, add out variable.
- **_Breaking Change_**: rewrite `EventBus` family, including `IEventBus/EventBus/DebugEventBus/DelayedEventBus`.
  - Use typed event bus. Fix #14.
  - Add `DebugEventBusMode.All`.
- **_Breaking Change_**: rollback `IoC` family.
  - Remove `KeyedIoCC`.
  - Simplify `Framework`.
- **_Breaking Change_**: rewrite `CommandBus`, including `ICommandBus/CommandBus/ICommandRepo/CommandRepo`.
  - Remove `DebugCommandBus/DelayedCommandBus`.
- Feat: add `IDictionaryExtension`.
- Feat: add `System.Runtime.CompilerServices.IsExternalInit` to make records working.
- Feat: add `GameObject.GetOrAddComponent`.
- Feat: `DebugEventBus` can be renamed.

## v6.1.0

- Feat: add `DebugCommandBus`, fix #11.
- Feat: add `IEventListener/IEventInvoker` as sub-interface of `IEventBus`.
- Feat: add `UniStartBehaviour.OnceWatch` for `IEventListener`.
- Note: optimize output format of `DebugEventBus`.

## v6.0.1

- Fix: #13

## v6.0.0

- **_Breaking Change_**: refactor `CommandBus`. Add `CommandRepo`, `DelayedCommandBus`.
- Feat: add `Lazy/LazyRef/LazyNew`.
- Feat: move `ComposableBehaviour.GetOrAddComponent` to `MonoBehaviourExtension`.
- Feat: show `Computed/LazyComputed/WatchRef` in inspector. #4
- Feat: more `MonoBehaviourExtension.Invoke/InvokeRepeating` overloads.
- Fix: #9
- Note: make `Entry.Start` protected.

## v5.0.0

- **_Breaking Change_**: move static utils into `UniStart` class.
  - Move `FnHelper.Fn` to `UniStart.Fn`.
  - Move `MonoBehaviour.ExitGame` to `UniStart.ExitGame`.
- Feat: add `UniStart.ReloadScene`.
- Fix: `Entry/CBC.context` is not `Ctx`.
- Deprecated: mark `onEnable/onDisable` in `ComposableBehaviour` as obsolete.
- Feat: add **_experimental_** `ICommandBus/CommandBus`.

## v4.0.0

- **_Breaking Change_**: rename `core` to `context`.
- **_Breaking Change_**: move `ComposableBehaviour.Watch` to `UniStartBehaviour.Watch`.
  - Add `UniStartBehaviour`.
  - `UniStartBehaviour` can watch `IEventBus<K>`.
- **_Breaking Change_**: remove `CompatibleEventBus`, rewrite `EventBus` family.
- **_Breaking Change_**: rename `SpriteRendererExtension.WithX` to `SpriteRendererExtension.SetColorX`.
- Feat: rewrite IoC module, add `IBasicIoCC/IKeyedIoCC/IStringIoCC/StringIoCC`.
- Feat: add `AdvancedEvent.AddOnceListener/RemoveOnceListener`.
- Feat: add `IComposable`.
- Feat: add `IOnceWatchable`.
  - Apply to `AdvancedEvent/UniStartBehaviour/Watch/WatchRef/Computed/IEventBus` and watchable collections.
- Feat: add `Rigidbody/Rigidbody2D.SetVelocityX/Y/Z`. #8
- Feat: show `Watch/WatchList/WatchArray` in inspector. #4

## v3.1.1

- Fix: using `System` for `Func`.

## v3.1.0

- Feat: `FnHelper/Entry/CBC.Fn` support `Func`. #5

## v3.0.0

- **_Breaking Change_**: add `AdvancedEvent`, remove `CascadeEvent`.
- **_Breaking Change_**: `EventBus.RemoveListener` will always return the action in parameter.
- Feat: Add `FnHelper/Entry/CBC.Fn`. #5
- Feat: move extensions from UniUtils to this project.
- Feat: all `AdvancedEvent` allow listener with 0 parameter.
- Feat: add `CompatibleEventBus`. #3
- Perf: optimize `EventBus` code and runtime performance.

## v2.0.0

- Feat: IoC container can accept `object` as key. #1
  - **Breaking Change**: new `IIoCC.Add/Get/TryGet`.
- Fix: `ComposableBehaviour.GetOrAddComponent` can't add some component (like `Rigidbody2D`).
- Perf: optimize `EventBus` runtime performance.

## v1.0.3

- Feat: Add `IIoCC.TryGet`.
- Fix: CBC can't get core.
- Fix: `ComposableBehaviour.GetOrAddComponent` can't get component.

## v1.0.2

Fix asmdef meta file.

## v1.0.1

Fix asmdef file.

## v1.0.0

Initial release.
