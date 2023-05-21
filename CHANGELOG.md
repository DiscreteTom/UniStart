# CHANGELOG

## v3.0.0

- Feat: Add `FnHelper.Fn`.

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
