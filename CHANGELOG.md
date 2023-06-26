# CHANGELOG

## v5.0.0

- **_Breaking Change_**: move static utils into `UniStart` class.
  - Move `FnHelper.Fn` to `UniStart.Fn`.
  - Move `MonoBehaviour.ExitGame` to `UniStart.ExitGame`.
- Feat: add `UniStart.ReloadScene`.
- Fix: `Entry/CBC.context` is not `Ctx`.
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
