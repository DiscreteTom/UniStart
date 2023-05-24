# CHANGELOG

## v3.0.0

- **_Breaking Change_**: add `AdvancedEvent`, remove `CascadeEvent`.
- Feat: Add `FnHelper/Entry/CBC.Fn`. #5
- Feat: move extensions from UniUtils to this project.
- Feat: all `AdvancedEvent` allow listener with 0 parameter.
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
