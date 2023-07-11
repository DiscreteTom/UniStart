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

    // be ware of onEnable, since Start is called after OnEnable,
    // you might want to invoke the listener immediately.
    this.onEnable.AddListener(() => print("enable")).Invoke();

    // you can also manage children's lifecycle easily
    // without creating a new class.
    this.transform.Find("Child").AddComponent<ComposableBehaviour>().onUpdate.AddListener(l);
  }
}
```

By using these events and closures, you can write your logic **_at the same place_**, instead of writing your logic in many different locations.

> This is inspired by [Vue Composition API](https://vuejs.org/guide/extras/composition-api-faq.html#more-flexible-code-organization).

<details>
<summary>Example</summary>

```cs
// Without ComposableBehaviour,
// your logics will spread into many different places.
public class UseMonoBehaviour : MonoBehaviour {
  // define vars as fields
  Rigidbody rb;
  SpriteRenderer sr;

  void Start() {
    // init vars at start
    rb = this.GetComponent<Rigidbody>();
    sr = this.GetComponent<SpriteRenderer>();
  }

  void Update() {
    // update logic
    rb.AddForce(Vector3.up * 10);
    sr.color = Color.red;
  }

  void OnDestroy() {
    // clean up
    Destroy(rb);
    Destroy(sr);
  }
}

// With ComposableBehaviour,
// you can write your logic at the same place.
public class UseComposableBehaviour : ComposableBehaviour {
  void Start() {
    // define vars as local variables,
    // and you will never forget to init/delete them.
    var rb = this.GetComponent<Rigidbody>();
    this.onUpdate.AddListener(() => rb.AddForce(Vector3.up * 10));
    this.onDestroy.AddListener(() => Destroy(rb));

    var sr = this.GetComponent<SpriteRenderer>();
    this.onUpdate.AddListener(() => sr.color = Color.red);
    this.onDestroy.AddListener(() => Destroy(sr));
  }
}
```

</details>

Another thing to mention is that, during your development with this `ComposableBehaviour`, your `Start` function will get bigger and bigger, so you may need to split it into multiple modules when you are ready. This is a progressive process, and you can do it at any time. You can also abstract your logic into many files and use them in different classes.

```cs
public class Logics {
  public static void ApplyLogic(ComposableBehaviour cb) {
    var sr = cb.GetComponent<SpriteRenderer>();
    cb.onUpdate.AddListener(() => sr.color = Color.red);
    cb.onDestroy.AddListener(() => Destroy(sr));
  }
}

public class Test1 : ComposableBehaviour {
  void Start() {
    Logics.ApplyLogic(this);
  }
}
public class Test2 : ComposableBehaviour {
  void Start() {
    Logics.ApplyLogic(this);
  }
}
```

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

    // Register with a custom key.
    this.Add<IEventBus>("anotherEB", new EventBus());

    // You can also get the instance after Add.
    var config = this.Get<Config>();

    // The Entry class inherits from ComposableBehaviour.
    this.onUpdate.AddListener(() => print(config));
  }
}
```

The `Entry` should be treated as the entry of you app (just like the `main` function), and should use `Awake` to initialize the context before the `Start` of other classes. It's recommended to attach the `Entry`'s subclass to the root GameObject of the scene.

To get those context, you can use the static method `Entry.GetContext`, but we have a better way to do it.

```cs
// CBC: ComposableBehaviour with Context injected.
public class WithContext : CBC {
  void Start() {
    // First, you can use the injected context.
    var config = this.Get<Config>();

    // Second, this is a ComposableBehaviour, so you can use composable methods like onUpdate.
    this.onUpdate.AddListener(() => print("WithContext.onUpdate"));
  }
}
```

You can replace all your `MonoBehaviour` with `ComposableBehaviour` to use the context injection, except the `Entry` class since the `Entry` class is responsible for initializing the context.

With this design, you will have an explicit place to initialize your context, instead of using singletons or other static variables.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s IoC container, and [jackutea](https://github.com/jackutea)'s deterministic lifecycle management.

### Responsive Containers

In UniStart, we have many built-in responsive containers/collections:

```cs
public class Model : MonoBehaviour {
  public Watch<int> Count;
  public WatchList<int> List;
  public WatchArray<bool> Array;
  public WatchDictionary<string, int> Dictionary;

  public Computed<int> Computed;
  public LazyComputed<int> LazyComputed;

  public Model Setup(int count) {
    // set the initial value
    this.Count = new Watch<int>(count);
    this.List = new WatchList<int>(); // init an empty list
    this.Array = new WatchArray<bool>(10); // init an array with 10 elements
    this.Dictionary = new WatchDictionary<string, int>(); // init an empty dictionary

    // For computed values, we need to watch the values that are used to compute the value.
    this.Computed = new Computed<int>(() => this.Count.Value * 2).Watch(this.Count);
    this.LazyComputed = new LazyComputed<int>(() => this.Count.Value * 2).Watch(this.Count);

    return this;
  }
}
```

Register `Model` to `Entry`:

```cs
public class App : Entry {
  void Awake() {
    this.Add(this.GetComponent<Model>().Setup(1));
  }
}
```

Then we can `AddListener` to those responsive containers, and they will be called when the value changes.

```cs
// CBC: ComposableBehaviour with Context injected.
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
    var ebi = this.Add<IEventBus<int>>(new DebugEventBus<int>(new EventBus<int>()));
    this.Watch(eb, 1, (int i) => print("Watch: " + i));
    // Even with your own EventBus type.
    this.Add<IEventBus<int>>(new DebugEventBus<int>(new MyEventBus()));
    // DelayedEventBus will delay the event invocation, until you call InvokeDelayed.
    var deb = new DelayedEventBus(); // store as DelayedEventBus
    this.Add<IEventBus>(deb); // but register as IEventBus
    this.onLateUpdate.AddListener(deb.InvokeDelayed); // invoke all delayed events
    // Generic DelayedEventBus.
    this.Add<IEventBus<int>>(new DelayedEventBus<int>(new EventBus<int>()));
    this.Add<IEventBus<int>>(new DelayedEventBus<int>(new MyEventBus()));
  }
}
```

Besides, there are 2 base interface of `IEventBus`: `IEventListener` and `IEventInvoker`.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s event system.

### RemoveListener on Destroy

```cs
// CBC: ComposableBehaviour with Context injected.
public class WithContext : CBC {
  void Start() {
    var model = this.Get<Model>();
    var eb = this.Get<IEventBus>();

    // This function will capture `this` in a closure,
    // we need to remove the listener when the script is destroyed.
    var cb = model.Count.AddListener((count) => print(this));
    this.onDestroy.AddListener(() => model.Count.RemoveListener(cb));

    // Helper function. Listener will be removed when the script is destroyed.
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

### CommandBus

Though you can modify your `Model` in any place, we recommend you to use `CommandBus` to modify your `Model` in a more centralized way.

```cs
// store commands in CommandRepo
public class MyCommandRepo: CommandRepo {
  public MyCommandRepo(Entry app) {
    // get context at the beginning
    var model = app.Get<Model>();
    var eb = app.Get<IEventBus>();

    // add command with a key,
    // use captured context, modify model, trigger event, etc
    this.Add("CommandName", () => {
      model.Count.Value++;
      eb.Invoke("SomeEvent");
    });

    // the key is an object, so you can use enum, int, etc.
    // commands can have parameters
    this.Add(SomeEnum.SomeValue, (int i) => {
      model.Count.Value += i;
      eb.Invoke("SomeEvent");
    });

    // get command from the return value
    var cmd = this.Add("Test", (int i) => {});

    // reuse existing command's logic
    this.Add("AnotherCommand", () => {
      // use this.Get to get existing command
      this.Get("CommandName").Invoke();
      // use this.Get to get existing command with parameters,
      // the returned command will must be UnityAction,
      // so provide parameters in `Get` instead of `Invoke`
      this.Get(SomeEnum.SomeValue, 1).Invoke();
      // or, just use returned command,
      // pass parameters in `Invoke`
      cmd.Invoke(0);
    });
  }
}

public class App : Entry {
  void Awake() {
    // init context before CommandBus
    this.Add<Model>();
    this.Add<IEventBus>(new EventBus());

    // register CommandBus with CommandRepo
    this.Add<ICommandBus>(new CommandBus(new MyCommandRepo(this)));
  }
}

public class MyCBC : CBC {
  void Start() {
    var model = this.Get<Model>();
    var eb = this.Get<IEventBus>();
    var cb = this.Get<ICommandBus>();

    // read values in model
    this.onUpdate.AddListener(() => print(model.Count.Value));

    // responsive by model/events
    this.Watch(model.Count, () => print(model.Count.Value));
    this.Watch(eb, "SomeEvent", () => print("SomeEvent"));

    // update model by command
    cb.Push("CommandName");
    // with parameters
    cb.Push(SomeEnum.SomeValue, 1);
  }
}
```

Thus, you can separate your game logics in the `CommandRepo` from the views in `CBC`. If you modify your view in `CBC` you can still reuse your logics in `CommandRepo`.

The data flow should be like:

1. Capture input/physics/other events in `CBC`.
2. Push commands into command bus in `CBC`.
3. Execute game logics in commands, change model, trigger events, etc.
4. Watch model/events in `CBC`, update views.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s command system.

## Related

- [CannonVsMosquito](https://github.com/DiscreteTom/CannonVsMosquito) - A demo game.
- [QFramework](https://github.com/liangxiegame/QFramework) - Which inspired this project.
- [jackutea](https://github.com/jackutea) - Who helped me a lot.

## [CHANGELOG](https://github.com/DiscreteTom/UniStart/blob/main/CHANGELOG.md)
