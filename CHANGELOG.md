# CHANGELOG

## v10.2.0

- Feat: add `StepExecutor` family.

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
