# UniStart

![version](https://img.shields.io/badge/dynamic/json?style=flat-square&color=blue&label=version&query=%24.version&url=https%3A%2F%2Fgithub.com%2FDiscreteTom%2FUniStart%2Fraw%2Fmain%2Fpackage.json)
![license](https://img.shields.io/github/license/DiscreteTom/UniStart?style=flat-square)
![Built for Unity3D](https://img.shields.io/badge/Built%20for-Unity3D-lightgrey?style=flat-square)

An experimental Unity3D framework which can boost your development speed several times over.

_Progressive, responsive, decoupled, and functional._

## Installation

Add package from git URL:

```
https://github.com/DiscreteTom/UniStart.git
```

Include this package:

```cs
using DT.UniStart;
```

## Get Started

### Composables and Closures

In UniStart, basically the only method you need to write is the `Start`:

```cs
// Inherit from ComposableBehaviour instead of MonoBehaviour
public class Test : ComposableBehaviour {
  void Start() {
    // You don't need the Update method in your class.
    // Just add a listener to the onUpdate event.
    this.onUpdate.AddListener(() => print("Test.onUpdate"));

    // Other events are also available, even with parameters.
    this.onCollisionEnter.AddListener((collision) => print("Test.onCollisionEnter"));

    // We even have extra events to enhance the update loop,
    // and it's lazy so it won't be called if there are no listeners.
    this.onNextUpdate.AddListener(() => print("Test.onNextUpdate"));

    // Unlike UnityEvent, AddListener will return the function you passed in,
    // so you can store it and remove it later.
    var l = this.onUpdate.AddListener(() => print("Test.onUpdate2"));
    this.onUpdate.RemoveListener(l);
    // or call it immediately
    this.onUpdate.AddListener(() => print("Test.onUpdate2")).Invoke();

    // Closures can capture variables, and value types will be boxed as reference types,
    // so you don't need to define variables as class's fields,
    // and you can use them in multi listeners.
    int i = 0;
    this.onUpdate.AddListener(() => print(i++));
    this.onCollisionEnter.AddListener((collision) => print(i));
  }
}
```

By using these events and closures, you can write your logic _at the same place_, instead of writing your logic in many different locations like `Start`(to initialize), `Update`, and some other functions you defined.

> This is inspired by [Vue Composition API](https://vuejs.org/guide/extras/composition-api-faq.html#more-flexible-code-organization).

Another thing to mention is that, during your development with this framework, your `Start` function will get bigger and bigger, so you may need to split it into multiple modules when you are ready. This is a progressive process, and you can do it at any time.

### Global Context Management

When developing a game, you may need to store some global context, like the player's data, the game's settings, etc. You may use singletons to store these data, but sometimes it's not a good idea.

In UniStart, we recommend to initialize those context in the `Entry` class, and use `Add` to register it to the app.

```cs
public class App : Entry {
  // Use Awake instead of Start to initialize your app.
  void Awake() {
    // Add the Config class to the app.
    // Entry will automatically new it up for you
    // if it has a default constructor.
    this.Add<Config>();

    // Add an existing instance of Model to the app.
    // Use this if your class has parameters in its constructor.
    // In addition, Add will return the instance.
    var model = this.Add(new Model(1));

    // Add an existing instance of EventBus to the app
    // but register it as an interface instead of a class.
    this.Add<IEventBus>(new EventBus());

    // You can also get the instance after Add.
    var config = this.Get<Config>();

    // The Entry class inherits from ComposableBehaviour.
    this.onUpdate.AddListener(() => print(config));
  }
}
```

The `Entry` should be treated as the entry of you app (just like the `main` function), and should use `Awake` to initialize the context before the `Start` of other classes.

> **Note**: It's recommended to attach the `Entry/App` to the root GameObject of the scene, and make sure it's the first script to be executed.

To get those context, you can use the static method `Entry.GetCore`, but we have a better way to do it.

```cs
// CBC: ComposableBehaviour with Core injected.
public class WithContext : CBC {
  void Start() {
    // First, you can use the injected core.
    var config = this.Get<Config>();

    // Second, this is a ComposableBehaviour, so you can use the onUpdate event.
    this.onUpdate.AddListener(() => print("WithContext.onUpdate"));
  }
}
```

With this design, you will have an explicit place to initialize your context, instead of using singletons or other static variables.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s IoC container, and [jackutea](https://github.com/jackutea)'s deterministic lifecycle management.

### Responsive Containers

In UniStart, we have many built-in responsive containers/collections:

```cs
public class Model {
  public Watch<int> Count { get; private set; }
  public WatchList<int> List { get; private set; }
  public WatchArray<bool> Array { get; private set; }
  public WatchDictionary<string, int> Dictionary { get; private set; }

  public Computed<int> Computed { get; private set; }
  public LazyComputed<int> LazyComputed { get; private set; }

  public Model(int count) {
    // set the initial value
    this.Count = new Watch<int>(count);
    this.List = new WatchList<int>(); // init an empty list
    this.Array = new WatchArray<bool>(10); // init an array with 10 elements
    this.Dictionary = new WatchDictionary<string, int>(); // init an empty dictionary

    // For computed values, we need to watch the values that are used to compute the value.
    this.Computed = new Computed<int>(() => this.Count.Value * 2).Watch(this.Count);
    this.LazyComputed = new LazyComputed<int>(() => this.Count.Value * 2).Watch(this.Count);
  }
}
```

Then we can `AddListener` to those responsive containers, and they will be called when the value changes.

```cs
// CBC: ComposableBehaviour with Core injected.
public class WithContext : CBC {
  void Start() {
    // Retrieve the instance of Model from the app.
    var model = this.Get<Model>();

    // For value types, there are 3 AddListener overloads:
    model.Count.AddListener(() => print("WithContext: " + model.Count.Value));
    model.Count.AddListener((value) => print("WithContext: " + value));
    model.Count.AddListener((value, oldValue) => print("WithContext: " + value + ", " + oldValue));

    // For collections, there are 2 AddListener overloads:
    model.List.AddListener(() => print("WithContext: " + model.List.Value));
    model.List.AddListener((value) => print("WithContext: " + value));

    // Trigger the events for value types.
    model.Count.Value = 2;

    // Trigger the events for collections.
    model.List.Add(1); // built-in methods are supported
    model.List.Contains(1); // readonly methods won't trigger events
  }
}
```

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s `BindableProperty`.

### EventBus

Responsive containers can help you to write your logic in a more declarative way. But sometimes you may want to use this idea in your own logic. In this case, you can use the `EventBus` class.

```cs
public class App : Entry {
  // Use Awake instead of Start to initialize your app.
  void Awake() {
    // Register the EventBus as IEventBus.
    var eb = this.Add<IEventBus>(new EventBus());

    // AddListener, the 1st parameter is the event name, the 2nd parameter is the callback.
    // You can use anything as the event name, since the event name is just an object.
    eb.AddListener("Test", () => print("Test"));
    eb.AddListener(123, () => print("123"));
    eb.AddListener(SomeEnum.EnumValue, () => print("EnumValue"));
    // And with parameters.
    eb.AddListener("Param", (int i) => print("Param: " + i));

    // Trigger the events.
    eb.Invoke("Test");
    eb.Invoke(123);
    eb.Invoke(SomeEnum.EnumValue);
    // And with parameters.
    eb.Invoke("Test", 1);

    // You can also create typed EventBus.
    this.Add<IEventBus<int>>(new EventBus<int>());
    this.Add<IEventBus<SomeEnum>>(new EventBus<SomeEnum>());

    // We also provide some EventBus wrappers to enhance the usage.
    // DebugEventBus will print the event name and parameters.
    // You can replace the EventBus with DebugEventBus to debug your events.
    // Since it also implements IEventBus, you don't need to change your code.
    this.Add<IEventBus>(new DebugEventBus());
    // Typed EventBus.
    this.Add<IEventBus<int>>(new DebugEventBus<int>());
    // Even with your own EventBus type.
    this.Add<IEventBus<int>>(new DebugEventBus<MyEventBus, int>(new MyEventBus()));

    // DelayedEventBus will delay the event invocation, until you call InvokeDelayed.
    var deb = new DelayedEventBus(); // store as DelayedEventBus
    this.Add<IEventBus>(deb); // but register as IEventBus
    this.onLateUpdate.AddListener(deb.InvokeDelayed); // invoke all delayed events
    // Generic DelayedEventBus.
    this.Add<IEventBus<int>>(new DelayedEventBus<int>());
    this.Add<IEventBus<int>>(new DelayedEventBus<MyEventBus, int>(new MyEventBus()));
  }
}
```

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s event system.

### RemoveListener on Destroy

```cs
// CBC: ComposableBehaviour with Core injected.
public class WithContext : CBC {
  void Start() {
    var model = this.Get<Model>();
    var eb = this.Get<IEventBus>();

    // This function will capture `this` in a closure,
    // we need to remove the listener when the object is destroyed.
    var cb = model.Count.AddListener((count) => print(this));
    this.onDestroy.AddListener(() => model.Count.RemoveListener(cb));

    // Helper function. Listener will be removed when the object is destroyed.
    this.Watch(model.Count, (count) => print(this));

    // You can watch other watchable objects.
    this.Watch(model.List, () => print(this));
    // Invoke your listener immediately.
    this.Watch(model.List, () => print(this)).Invoke();
    // Including IEventBus
    this.Watch(eb, "event name", () => print(this));
  }
}
```

## Related

- [CannonVsMosquito](https://github.com/DiscreteTom/CannonVsMosquito) - A demo game.

## [CHANGELOG](https://github.com/DiscreteTom/UniStart/blob/main/CHANGELOG.md)
