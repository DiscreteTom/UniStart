# UniStart

![version](https://img.shields.io/badge/dynamic/json?style=flat-square&color=blue&label=version&query=%24.version&url=https%3A%2F%2Fgithub.com%2FDiscreteTom%2FUniStart%2Fraw%2Fmain%2Fpackage.json)
![license](https://img.shields.io/github/license/DiscreteTom/UniStart?style=flat-square)
![Built for Unity3D](https://img.shields.io/badge/Built%20for-Unity3D-lightgrey?style=flat-square)

An experimental Unity3D framework which can boost your development speed several times over.

_Progressive, responsive, decoupled, and functional._

## Architecture Overview

![architecture](img/architecture.png)

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

### AdvancedEvent

Before we start, let's take a look at the fundamental building block of UniStart: `AdvancedEvent`

```cs
public class AdvancedEventApp : MonoBehaviour {
  void Start() {
    // you can use AdvancedEvent just like UnityEvent
    new AdvancedEvent();
    new AdvancedEvent<int>();
    new AdvancedEvent<int, int>();
    new AdvancedEvent<int, int, int>();
    new AdvancedEvent<int, int, int, int>();

    // AddListener will return the listener
    // so you can call it immediately
    var e = new AdvancedEvent<int>();
    e.AddListener((a) => print(a)).Invoke(1);
    // or store it and remove it later
    var listener = e.AddListener((a) => print(a));
    e.RemoveListener(listener);
    // or use out var to store it
    e.AddListener(out var named, (a) => print(a));
    e.RemoveListener(named);

    // listeners with zero params are always acceptable
    e.AddListener(() => print(1)).Invoke();

    // listeners that will only be invoked once
    e.AddOnceListener((a) => print(a)).Invoke(1);
    var once = e.AddOnceListener(() => print(1));
    e.RemoveListener(once);
  }
}
```

As you can see, the `AdvancedEvent` encourages you to use closures instead of methods, and it's more flexible than `UnityEvent`.

Almost all events in UniStart will use `AdvancedEvent` instead of `UnityEvent`.

### Composables and Closures

In UniStart, basically the only method you need to write is the `Start`:

```cs
// Inherit from ComposableBehaviour instead of MonoBehaviour
public class ComposableApp : ComposableBehaviour {
  void Start() {
    // You don't need the Update method in your class.
    // Just add a listener to the onUpdate event.
    this.onUpdate.AddListener(() => print("Test.onUpdate"));

    // Other events are also available, even with parameters.
    this.onCollisionEnter.AddListener((collision) => print("Test.onCollisionEnter"));

    // We even have extra events to enhance the update loop,
    // and it's lazy so it won't be called if there are no listeners.
    this.onNextUpdate.AddListener(() => print("Test.onNextUpdate"));

    // All events are AdvancedEvent,
    // so listeners with zero params are always acceptable,
    // you can also invoke them immediately.
    this.onCollisionEnter.AddListener(() => print(1)).Invoke();

    // Closures can capture variables, and value types will be boxed as reference types,
    // so you don't need to define variables as class's fields,
    // and you can use local vars safely in multi listeners.
    int i = 0;
    this.onUpdate.AddListener(() => print(i++));
    this.onCollisionEnter.AddListener((collision) => print(i));

    // be ware of onEnable, since Start is called after OnEnable,
    // you might want to invoke the listener immediately.
    this.onEnable.AddListener(() => print("enable")).Invoke();

    // you can also manage children's lifecycle easily
    // without creating a new class.
    var child = this.transform.Find("Child").gameObject;
    child.GetOrAddComponent<ComposableBehaviour>().onUpdate.AddListener(() => { });
  }
}
```

By using `AdvancedEvent` and closures, you can write your logic **_at the same place_**, instead of spreading your logic in many different locations.

> This is inspired by [Vue Composition API](https://vuejs.org/guide/extras/composition-api-faq.html#more-flexible-code-organization).

<details>
<summary>Compare MonoBehaviour and ComposableBehaviour</summary>

```cs
// Without ComposableBehaviour,
// your logics will be spread into many different places/functions.
public class WithMonoBehaviour : MonoBehaviour {
  // define vars as fields
  Rigidbody rb;
  SpriteRenderer sr;

  void Start() {
    // init vars at start
    this.rb = this.GetComponent<Rigidbody>();
    this.sr = this.GetComponent<SpriteRenderer>();
  }

  void Update() {
    // update logic
    this.rb.AddForce(Vector3.up * 10);
    this.sr.color = Color.red;
  }

  void OnDestroy() {
    // clean up
    Destroy(this.rb);
    Destroy(this.sr);
  }
}

// With ComposableBehaviour,
// you can write your logic at the same place.
public class WithComposableBehaviour : ComposableBehaviour {
  void Start() {
    // define vars as local variables,
    // init them with auto type inference when define them,
    // and you will never forget to clean them up.
    var rb = this.GetComponent<Rigidbody>();
    this.onDestroy.AddListener(() => Destroy(rb));
    this.onUpdate.AddListener(() => rb.AddForce(Vector3.up * 10));

    var sr = this.GetComponent<SpriteRenderer>();
    this.onDestroy.AddListener(() => Destroy(sr));
    this.onUpdate.AddListener(() => sr.color = Color.red);
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
public class EntryApp : Entry {
  // Use Awake instead of Start to initialize your app.
  void Awake() {
    // Add custom class to the app.
    // Entry will automatically new it up for you
    // if it has a default constructor.
    this.Add<Config>();

    // Add an existing instance to the app.
    // In addition, Add will return the instance.
    var model = this.Add(new ModelManager());

    // Add an existing instance to the app
    // but register it as an interface instead of a class.
    this.Add<IEventBus>(new EventBus());

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

You can replace all your `MonoBehaviour` with `CBC` to use the context injection, except the `Entry` class since the `Entry` class is responsible for initializing the context.

With this design, you will have an explicit place to initialize your context, instead of using singletons or other static variables.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s IoC container, and [jackutea](https://github.com/jackutea)'s deterministic lifecycle management.

### Event Bus

You can register `EventBus` to app to realize cross-component communication. `EventBus` can intercept events and realize additional logics like logging, and you can also use it to decouple your components.

```cs
// define your own event types
public record EventWithoutParams { }
public record EventWithParams(int a, int b);

public class EventBusApp : Entry {
  // Use Awake instead of Start to initialize your app.
  void Awake() {
    // Register the EventBus as IEventBus.
    var eb = this.Add<IEventBus>(new EventBus());

    // add/remove listener
    var listener = eb.AddListener<EventWithoutParams>(() => print(1));
    eb.RemoveListener<EventWithoutParams>(listener);
    // with params
    var listenerWithParams = eb.AddListener<EventWithParams>((e) => print(e.a));
    eb.RemoveListener(listenerWithParams);
    // even the event has params, you can still use the listener without params
    eb.AddListener<EventWithParams>(() => print(1));
    // once listener
    var once = eb.AddOnceListener<EventWithParams>((e) => print(e.b));
    eb.RemoveListener(once); // remove once listener

    // trigger events
    eb.Invoke<EventWithoutParams>();
    eb.Invoke(new EventWithoutParams());
    eb.Invoke(new EventWithParams(1, 2));

    // you can define wrappers to proxy events with other functionality,
    // we have predefined DebugEventBus to print the event name and parameters.
    this.Add<IEventBus>(new DebugEventBus(new EventBus(), InterceptEventBusMode.Invoke));
    // the default inner bus is EventBus, and the default mode is Invoke,
    // so you can omit them.
    this.Add<IEventBus>(new DebugEventBus());
    // you can also use your own event bus
    this.Add<IEventBus>(new DebugEventBus(new MyEventBus()));
    // or change the mode use keyword args
    this.Add<IEventBus>(new DebugEventBus(mode: InterceptEventBusMode.AddListener));

    // we also have predefined DelayedEventBus to delay the event invocation
    this.Add<IEventBus>(new DelayedEventBus(new EventBus()));
    // the default inner bus is EventBus, so you can omit it.
    this.Add<IEventBus>(new DelayedEventBus());
    // invoke the delayed actions
    var deb = new DelayedEventBus();
    deb.Invoke(new EventWithParams(1, 2)); // won't invoke
    this.onLateUpdate.AddListener(deb.InvokeDelayed); // invoke all delayed actions
    this.onNextUpdate.AddListener(deb.InvokeDelayed); // you can also use onNextUpdate

    // use multi-wrappers
    this.Add<IEventBus>(new DebugEventBus(new DelayedEventBus(new MyEventBus())));
  }
}
```

Besides, there are 2 base interface of `IEventBus`: `IEventListener` and `IEventInvoker`.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s event system.

### Command Bus

`EventBus` lets you add listeners anywhere, but you may have some pre-defined `Commands` which should be listened centrally. `CommandBus` is designed for this.

```cs
public record SimpleCommand { }
public record ComplexCommand(int a, int b);

public class CommandBusEntry : Entry {
  void Awake() {
    // register commands' listeners centrally
    var cb = new CommandBus();
    cb.Add<SimpleCommand>(() => print(1));
    cb.Add<ComplexCommand>((e) => print(e.a));
    // register command bus into app as readonly ICommandBus
    this.Add<ICommandBus>(cb);

    // there is an IEventBus in the CommandBus
    // so you can use custom event bus
    new CommandBus(new DebugEventBus(name: "DebugCommandBus"));
    // we also have helper command bus
    new DebugCommandBus(); // equals to new CommandBus(new DebugEventBus(name: "DebugCommandBus"))
    new DelayedCommandBus(); // equals to new CommandBus(new DelayedEventBus())
  }
}

public class CommandBusApp : CBC {
  void Start() {
    var cb = this.Get<ICommandBus>();

    // execute commands
    cb.Push<SimpleCommand>();
    cb.Push(new ComplexCommand(1, 2));
  }
}
```

Thus, you can separate your game logics in the `CommandBus` from the views in `CBC`. If you modify your view in `CBC` you can still reuse your logics in `CommandBus`.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s command system.

### Responsive Containers

In UniStart, we have many built-in responsive containers/collections to help you build responsive app:

```cs
public class ResponsiveApp : MonoBehaviour {
  void Start() {
    // responsive containers
    var count = new Watch<int>(0);
    var list = new WatchList<int>(); // empty list
    var array = new WatchArray<int>(10); // array with 10 elements
    var dictionary = new WatchDictionary<string, int>(); // empty dictionary

    // For computed values, we need to watch the values that are used to compute the value.
    var computed = new Computed<int>(() => count.Value * 2).Watch(count);
    var lazyComputed = new LazyComputed<int>(() => count.Value * 2).Watch(count);

    // For value types, there are 3 AddListener overloads:
    count.AddListener(() => print(count.Value));
    count.AddListener((value) => print(value));
    count.AddListener((value, oldValue) => print(value));

    // For collections, there are 2 AddListener overloads:
    list.AddListener(() => print(list.Value));
    list.AddListener((value) => print(value));

    // you can add listeners to computed values, but not lazy computed values
    computed.AddListener(() => print(computed.Value));

    // Trigger change event for value types.
    count.Value = 2;

    // Trigger change event for collections.
    list.Add(1); // built-in methods are supported
    list.Contains(1); // readonly methods won't trigger events
    list[0] = 2; // you can also use indexers

    // commit many changes in one transaction using Commit
    // this will trigger the change event only once
    list.Commit((l) => {
      l.Add(1);
      l.Add(2);
    });

    // use readonly commit and manually trigger events
    list.ReadOnlyCommit((l) => {
      l.Add(3);
      l.Add(4);
    });
    list.InvokeEvent();
  }
}
```

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s `BindableProperty`.

### State Management

Usually we need to manage the state (or `Model`) of the game, we also want to watch for changes of the state, and commit changes to the state.

Unlike those responsive containers, we don't want the state to be changed by other classes, only the state manager can commit changes to the state.

```cs
public class Model {
  // state is readonly and watchable
  public IState<int> Count { get; protected set; }
  public IListState<int> List { get; protected set; }
  public IDictionaryState<string, int> Dictionary { get; protected set; }
  public IListState<bool> Array { get; protected set; }

  public Computed<int> Computed { get; protected set; }
  public LazyComputed<int> LazyComputed { get; protected set; }

  // prevent external instantiation
  protected Model() { }
}

// make ModelManager inherit Model to manage states,
// also implement IStateManager to use extension methods
public class ModelManager : Model, IStateManager {
  public ModelManager() {
    // you can use responsive containers as the state,
    // you can also use your custom classes as long as the interface is implemented
    this.Count = this.SafeAdd(new Watch<int>(0));
    this.List = this.SafeAddList(new WatchList<int>());
    this.Dictionary = this.SafeAddDictionary(new WatchDictionary<string, int>());
    // there is no SafeAddArray/IArrayState
    this.Array = this.SafeAddList(new WatchArray<bool>(10));

    // we also have shorthand methods for the above
    this.Count = this.Add(0); // use Watch
    this.List = this.AddList<int>(); // use WatchList
    this.Array = this.AddArray<bool>(10); // use WatchArray
    this.Dictionary = this.AddDictionary<string, int>(); // use WatchDictionary

    // you can still use computed values
    this.Computed = new Computed<int>(() => this.Count.Value * 2).Watch(this.Count);
    this.LazyComputed = new LazyComputed<int>(() => this.Count.Value * 2).Watch(this.Count);
  }
}

public class ModelAppEntry : Entry {
  void Awake() {
    var cb = new CommandBus();
    this.Add<ICommandBus>(cb);

    // register readonly model to app
    var model = new ModelManager();
    this.Add<Model>(model);

    // update model through commands
    cb.Add<SimpleCommand>(() => {
      // use commit to update value type's value
      model.Commit(model.Count, 123);

      // commits can be cascaded
      model.Commit(model.Count, 123).Commit(model.Count, 456);

      // for collections, you can use Commit or Apply
      model.Apply(model.List, (list) => {
        // if you use Apply,
        // every write action will trigger the change event
        list.Add(1);
        list.Add(2);
      }).Commit(model.List, (list) => {
        // if you use Commit,
        // the change event will only be triggered once
        list.Add(3);
        list.Add(4);
      });
    });
  }
}

public class ModelApp : CBC {
  void Start() {
    var cb = this.Get<ICommandBus>();
    // get readonly model from app
    var model = this.Get<Model>();

    // watch model for changes
    model.List.AddListener((l) => print(l.Count));

    // check model value
    this.onUpdate.AddListener(() => print(model.Count.Value));

    // you can't update model directly
    // but you can use commands to update model
    cb.Push<SimpleCommand>();
  }
}
```

### RemoveListener on Destroy

```cs
// CBC: ComposableBehaviour with Context injected.
public class RemoveListenerApp : CBC {
  void Start() {
    var model = this.Get<Model>();
    var el = this.Get<IEventListener>();
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
    // Watch IEventListener/IEventBus
    this.Watch<EventWithParams>(el, () => print(this));
    this.Watch<EventWithParams>(eb, (e) => print(e.a));
    this.Watch(eb, (EventWithParams e) => print(e.a));

    // In addition, composable events are actually standalone components,
    // except onEnable/onDisable and onDestroy,
    // so if you plan to destroy the script before destroying the game object,
    // maybe you also need to destroy the listener too.
    this.Watch(this.onUpdate, () => print(this));
  }
}
```

### Put Them Together

Finally, keep the architecture diagram in mind, and put all the pieces together.

![architecture](img/architecture.png)

```cs
using DT.UniStart;
using UnityEngine;

namespace Project {
  public class Model {
    // store states in readonly model
    public IState<int> Count { get; protected set; }
    // prevent external instantiation
    protected Model() { }
  }

  public class ModelManager : Model, IStateManager {
    public ModelManager() {
      // init states
      this.Count = this.Add(0);
    }
  }

  // define commands & events
  public record SomeCommand(int a, int b);
  public record SomeEvent(int a, int b);

  // attach the entry script to the root game object
  public class App : Entry {
    void Awake() {
      // register context
      var eb = this.Add<IEventBus>(new DebugEventBus());
      var model = new ModelManager();
      this.Add<Model>(model);
      var cb = new CommandBus();
      this.Add<ICommandBus>(cb);

      // register commands
      cb.Add<SomeCommand>((e) => {
        // update model in commands
        model.Commit(model.Count, e.a + e.b);
        // publish event to controllers
        eb.Invoke(new SomeEvent(e.a, e.b));
      });
    }
  }

  // attach the controller script to other game object
  public class Controller : CBC {
    void Start() {
      // get context
      var eb = this.Get<IEventBus>();
      var model = this.Get<Model>();
      var cb = this.Get<ICommandBus>();

      // update view when model changes
      // or when events are published
      this.Watch(model.Count, (v) => print(v));
      this.Watch(eb, (SomeEvent e) => print(e));

      // use composable behaviour's update event
      this.onUpdate.AddListener(() => {
        if (Input.GetKeyDown(KeyCode.Space)) {
          // send commands
          cb.Push(new SomeCommand(1, 2));
        }
      });
    }
  }
}
```

## Related

- [CannonVsMosquito](https://github.com/DiscreteTom/CannonVsMosquito) - A demo game.
- [QFramework](https://github.com/liangxiegame/QFramework) - Which inspired this project.
- [jackutea](https://github.com/jackutea) - Who helped me a lot.

## [CHANGELOG](https://github.com/DiscreteTom/UniStart/blob/main/CHANGELOG.md)
