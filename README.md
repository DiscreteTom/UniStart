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

### Basics - AdvancedEvent

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

    // listeners with fewer params are also acceptable
    var ee = new AdvancedEvent<int, int, int, int>();
    ee.AddListener(() => print(1));
    ee.AddListener((a) => print(1));
    ee.AddListener((a, b) => print(1));
    ee.AddListener((a, b, c) => print(1));

    // listeners that will only be invoked once
    var once = e.AddOnceListener(() => print(1));
    // still use RemoveListener to remove it
    e.RemoveListener(once);
  }
}
```

As you can see, the `AdvancedEvent` encourages you to use closures instead of methods, and it's more flexible than `UnityEvent`.

Almost all events in UniStart will use `AdvancedEvent` instead of `UnityEvent`.

<details>
<summary>Stability</summary>

Listeners are ensured to be called in the order they are added (no matter it is a normal listener or once listener or listeners with less parameters).

```cs
var e = new AdvancedEvent<int>();
e.AddListener(() => print(1));
e.AddOnceListener(() => print(2));
e.AddListener((a) => print(a));
e.Invoke(3); // guaranteed to print 1, 2, 3
```

You can add/remove listeners during the invocation, but they will only take effect after the current invocation.

Here are examples to demonstrate this:

```cs
// add listeners during invocation
var e = new AdvancedEvent();
e.AddOnceListener(() => e.AddOnceListener(() => print(1)));
e.Invoke(); // this will add the second once listener, but won't invoke it
e.Invoke(); // this will print 1
```

```cs
// remove listeners during invocation
UnityAction a = () => print(1);
var e = new AdvancedEvent();
e.AddListener(() => e.RemoveListener(a));
e.AddListener(a);
e.Invoke(); // this will remove listener 'a' but still will print 1
e.Invoke(); // this will not print 1
```

</details>

### Basics - Composables and Closures

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

    // We also have helper methods for common use cases.
    // E.g. onNextUpdate = onUpdate.AddOnceListener
    this.onNextUpdate(() => print("Test.onNextUpdate"));

    // All events are AdvancedEvent,
    // so listeners with zero params are always acceptable,
    // you can also invoke them immediately.
    this.onCollisionEnter.AddListener(() => print(1)).Invoke();

    // Closures can capture variables, and value types will be boxed as reference types,
    // so you don't need to define variables as class's fields,
    // and you can use local vars safely in multi listeners.
    var i = 0;
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
  public static void ApplyLogic(IComposable cb) {
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

What's more, to use this with other frameworks, you can also use `ComposableBehaviour` as a component, and add it to any `GameObject` you want. For example, if you are using Mirror for networking, you can inherit from `NetworkBehaviour` and use `ComposableBehaviour` as a component.

```cs
public class ComposableComponentApp : NetworkBehaviour {
  void Start() {
    var cb = this.GetOrAddComponent<ComposableBehaviour>();
    cb.onUpdate.AddListener(() => print("Test.onUpdate"));
  }
}
```

### Basics - Global Context Management

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
    var model = this.Add(new MyModel());

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

Just like the `ComposableBehaviour`, you can also use `CBC` as a component, and add it to any `GameObject` you want.

```cs
public class CBCComponentApp : MonoBehaviour {
  void Start() {
    var cbc = this.GetOrAddComponent<CBC>();
    var model = cbc.Get<Model>();
    cbc.onUpdate.AddListener(() => print("Test.onUpdate"));
  }
}
```

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s IoC container, and [jackutea](https://github.com/jackutea)'s deterministic lifecycle management.

### Orchestration - Event Bus

You can register `EventBus` to app to realize cross-component communication. `EventBus` can intercept events and realize additional logics like logging, and you can also use it to decouple your components.

```cs
// define your own event types
public record EventWithoutParams : IEvent;
public record EventWithParams(int a, int b) : IEvent;

public class EventBusApp : Entry {
  // use Awake instead of Start to initialize your app
  void Awake() {
    // register the EventBus as IEventBus.
    var eb = this.Add<IEventBus>(new EventBus());
    // or with a helper method
    eb = this.AddEventBus();
    // or use your own event bus
    eb = this.AddEventBus(new MyEventBus());
    // get the event bus
    eb = this.Get<IEventBus>();
    // or use the helper method
    eb = this.GetEventBus();

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

    // we have a predefined IEventBus wrapper DebugEventBus to print the event name and parameters.
    // this is useful for debugging, and easy to switch between EventBus and DebugEventBus.
    this.AddEventBus(Application.isEditor ? new DebugEventBus() : new EventBus());
    // for short, set `debug` to `true` to wrap the provided EventBus in DebugEventBus in editor mode.
    this.AddEventBus(debug: true);
    // you can also use your own event bus
    this.AddEventBus(new MyEventBus(), debug: true);
    // change the log mode
    this.AddEventBus(new DebugEventBus(mode: DebugEventBusMode.AddListener));
    // or both of mode and bus
    this.AddEventBus(new DebugEventBus(new MyEventBus(), DebugEventBusMode.Invoke));
  }
}

// methods in EventBus is virtual so you can override them.
// here is an example to delay all the events.
// actually we have a DelayedEventBus to achieve the same effect.
public class MyEventBus : EventBus {
  readonly UnityEvent delayed = new();

  public override void Invoke<T>(T e) {
    this.delayed.AddListener(() => base.Invoke(e));
  }

  public void InvokeDelayed() {
    this.delayed.Invoke();
    this.delayed.RemoveAllListeners();
  }
}
```

Besides, there are 2 base interface of `IEventBus`: `IEventListener` and `IEventInvoker`.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s event system.

### Orchestration - Command Bus

`EventBus` lets you add listeners anywhere, but you may have some pre-defined `Commands` which should be listened centrally. `CommandBus` is designed for this.

```cs
// define commands
public record SimpleCommand : ICommand;
public record ComplexCommand(int a, int b) : ICommand;

public class CommandBusEntry : Entry {
  void Awake() {
    // register command bus into app as the readonly ICommandBus
    var cb = this.Add<ICommandBus>(
      // CommandCenter is writable,
      // so we register all commands here centrally
      new CommandCenter()
        .With<SimpleCommand>(() => print(1))
        .With<ComplexCommand>((e) => print(e.a))
    );
    // or use the helper method `AddCommandBus` to register `ICommandBus`
    // just like `AddEventBus`
    this.AddCommandBus(cb, debug: true);
  }
}

public class CommandBusApp : CBC {
  void Start() {
    var cb = this.Get<ICommandBus>();
    // or use the helper method
    cb = this.GetCommandBus();

    // push commands to bus
    cb.Push<SimpleCommand>();
    cb.Push(new ComplexCommand(1, 2));
  }
}
```

Thus, you can separate your game logics in the `CommandBus` from the views in `CBC`. If you modify your view in `CBC` you can still reuse your logics in `CommandBus`.

Commands are often used in state management with CQRS pattern. We will introduce how to manage state with UniStart later.

The default `CommandCenter` will execute commands immediately, but you can also use `DelayedCommandCenter` to delay the execution. This is useful to prevent side-effect in a responsive system.

```cs
public class RecursiveCommandBusApp : Entry {
  void Awake() {
    // the default command center will execute the command immediately
    var cc = new CommandCenter();

    // when this command is executed, it will recursively execute itself!
    cc.Add<SimpleCommand>(() => cc.Push<SimpleCommand>());

    // start the recursion
    cc.Push<SimpleCommand>();
  }
}

public class DelayedCommandBusApp : Entry {
  void Awake() {
    // the delayed command center will execute all buffered commands when `Execute` is called
    var cc = new DelayedCommandCenter();

    // execute all commands from the last frame
    this.onUpdate.AddListener(cc.Execute);
    // or use the helper method
    cc.Mount(this.onUpdate);

    // this is safe because the command will be executed in the next frame
    cc.Add<SimpleCommand>(() => cc.Push<SimpleCommand>());

    cc.Push<SimpleCommand>();
  }
}
```

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s command system.

### Orchestration - Step Executor

You can use `StepExecutor` to realize cross-component ordered event handling.

```cs
public enum SomeEventStep {
  Step1,
  Step2
}

public class StepExecutorEntry : Entry {
  void Awake() {
    // register the IStepExecutor
    var se = this.Add<IStepExecutor<SomeEventStep>>(new StepExecutor<SomeEventStep>());
    // helper method just like `AddEventBus`.
    se = this.AddStepExecutor<SomeEventStep>(debug: true);
    // invoke step listeners in order
    this.onNextUpdate(() => se.Invoke());
  }
}

public class StepApp1 : CBC {
  void Start() {
    // bind to step 1
    // so this will be run first
    this.GetStepExecutor<SomeEventStep>().On(SomeEventStep.Step1).AddListener(() => print(1));
  }
}

public class StepApp2 : CBC {
  void Start() {
    // bind to step 2
    // so this will be run second
    this.GetStepExecutor<SomeEventStep>().On(SomeEventStep.Step2).AddListener(() => print(1));
  }
}
```

You can also pass context to the steps.

```cs
public class StepContext {
  public int a;
}

public class StepExecutorApp : Entry {
  void Awake() {
    // add a context type to the step executor
    var se = this.AddStepExecutor<SomeEventStep, StepContext>(debug: true);

    se.On(SomeEventStep.Step1).AddListener((ctx) => ctx.a++);
    se.On(SomeEventStep.Step2).AddListener((ctx) => print(ctx.a));

    se.Invoke(new StepContext { a = 1 });
  }
}
```

### Responsiveness - Responsive Containers

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

    // use muted commit and manually trigger events
    list.MutedCommit((l) => {
      l.Add(3);
      l.Add(4);
    });
    list.InvokeEvent();
  }
}
```

Besides, we also provide `WatchRef`, `WatchIList` and `WatchIDictionary` for you to build your own responsive containers.

> This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s `BindableProperty`.

### Responsiveness - State Machine

For responsive enum values, besides `Watch`, you can also use `StateMachine`:

```cs
public enum GameState {
  Start,
  Playing,
  GameOver
}

public class StateMachineApp : CBC {
  void Start() {
    // create state machine
    var sm = new StateMachine<GameState>(GameState.Start);

    // listen for state changes
    sm.AddListener(() => print(1));
    sm.OnEnter(GameState.Playing).AddListener(() => print(1));
    sm.OnExit(GameState.Playing).AddListener(() => print(1));

    // read value
    this.onUpdate.AddListener(() => print(sm.Value));

    // change state, trigger events
    sm.Value = GameState.Playing;
  }
}
```

### Lifecycle - State Management

Usually we need to manage the state (or `Model`) of the game across components or game objects, we also want to watch for changes of the state, and commit changes to the state.

Unlike those responsive containers, we don't want the state to be changed by other classes, only the state manager can commit changes to the state.

```cs
// define commands to update the model.
// you can also make these commands local to the model class
record MyCommand : ICommand;

// inherit from StateManager to use helper methods
public class Model : StateManager {
  // state is readonly and watchable
  public readonly IValueState<int> count;
  public readonly IEnumState<GameState> gameState;
  public readonly IListState<int> list;
  public readonly IArrayState<bool> array;
  public readonly IDictionaryState<string, int> dict;

  // you can also use System.Collections.Generic types.
  // use this if they are const values since they are not watchable
  public readonly IReadOnlyList<int> constArray;
  public readonly IReadOnlyDictionary<string, int> constDict;

  // or, a list of state, which is also readonly and watchable
  // use this if the list's length is fixed
  public readonly IReadOnlyList<IValueState<int>> stateArray;
  public readonly IReadOnlyList<IEnumState<GameState>> enumArray;

  // computed values are also readonly
  public readonly Computed<int> computed;
  public readonly LazyComputed<int> lazyComputed;

  // properties are readonly but not watchable.
  public int property => this.count.Value;

  ICommandBus cb;

  public Model(ICommandCenter cc, IEventInvoker eb) {
    // you can use responsive containers as the state,
    // you can also use your custom classes as long as the state interface is implemented
    this.count = new Watch<int>(0);
    this.list = new WatchList<int>();

    // when you assign values to states, they are readonly.
    // if you want to modify states in commands,
    // you need to use the responsive containers directly
    var count = new Watch<int>(0); // this is mutable
    cc.Add<SimpleCommand>(() => {
      // you can update state values in commands
      count.Value = 123;
    });
    this.count = count; // this.count is readonly

    // the helper `StateManager.Init` will init the state
    // and return the default mutable container.
    count = this.Init(ref this.count, 0); // Watch<int>

    // you only need to remember one method called `Init`
    // to init all types of states with the default responsive container.
    // all generic types are inferred!
    var gameState = this.Init(ref this.gameState, GameState.Start); // StateMachine
    var list = this.Init(ref this.list); // WatchList
    var array = this.Init(ref this.array, 1); // WatchArray
    var dict = this.Init(ref this.dict); // WatchDictionary
    var constArray = this.Init(ref this.constArray, 10); // int[]
    var constDict = this.Init(ref this.constDict); // Dictionary<string, int>
    var stateArray = this.Init(ref this.stateArray, 10); // Watch<int>[]
    var enumArray = this.Init(ref this.enumArray, 10); // StateMachine<GameState>[]

    // now you can update states in commands
    cc.Add<MyCommand>(() => {
      list.Add(1); // make changes
      eb.Invoke<EventWithoutParams>(); // publish events
    });

    // computed values are already readonly,
    // you can use them directly
    this.computed = new Computed<int>(() => this.count.Value * 2).Watch(this.count);
    this.lazyComputed = new LazyComputed<int>(() => this.count.Value * 2).Watch(this.count);

    this.cb = cc;
  }

  // you can also add methods for better intellisense in IDE
  public void MyCommand() {
    // command can be inspect by DebugCommandBus
    // so we will know what happened to the model.
    // commands can also be delayed to prevent side effect
    this.cb.Push<MyCommand>();
  }
}

public class ModelAppEntry : Entry {
  void Awake() {
    // use DelayedCommandCenter to prevent side effect
    // when updating the model
    var cb = new DelayedCommandCenter();
    // execute all commands in the next frame
    this.onUpdate.AddListener(() => cb.Execute());

    // enable debug mode to see what happened to the model
    this.AddCommandBus(cb, debug: true);
    // register model to the app
    this.Add(new Model(cb, new EventBus()));
  }
}

public class ModelApp : CBC {
  void Start() {
    var cb = this.GetCommandBus();
    // get readonly model from app
    var model = this.Get<Model>();

    // watch model for changes
    model.list.AddListener((l) => print(l.Count));

    // check model value
    this.onUpdate.AddListener(() => print(model.count.Value));

    // use commands to update model
    cb.Push<MyCommand>();

    // or use methods to update model
    // so that IDE can check if the command exists
    model.MyCommand();
  }
}
```

### Lifecycle - RemoveListener on Destroy

```cs
public class RemoveListenerApp : CBC {
  void Start() {
    var model = this.Get<Model>();
    var el = this.Get<IEventListener>();
    var eb = this.Get<IEventBus>();

    // This function will capture `this` in a closure,
    // we need to remove the listener when the script is destroyed.
    var cb = model.count.AddListener((count) => print(this));
    this.onDestroy.AddOnceListener(() => model.count.RemoveListener(cb));

    // Helper function. Listener will be removed when the script is destroyed.
    this.Watch(model.count, (count) => print(this));

    // You can watch other watchable objects.
    this.Watch(model.list, () => print(this));
    // Invoke your listener immediately.
    this.Watch(model.list, () => print(this)).Invoke();
    // Watch IEventListener/IEventBus
    this.Watch<EventWithParams>(el, () => print(this));
    this.Watch<EventWithParams>(eb, (e) => print(e.a));
    this.Watch(eb, (EventWithParams e) => print(e.a));

    // remove listener on other events
    this.Watch(model.count, this.onDisable, (count) => print(this));

    // Action/UnityEvent can also be watched.
    // UnityEvent may be used with Unity3D's UI system.
    Action a = () => { };
    this.Watch(a, () => print(this));
    this.Watch(this.GetComponent<Button>().onClick, () => print(this));

    // InputSystem event can also be watched.
    var input = new PlayerControl();
    this.Watch(input.Player.Fire, InputActionEventType.Started, (ctx) => print(this));

    // StateMachine and StepExecutor
    var sm = new StateMachine<GameState>(GameState.Start);
    this.Watch(sm.OnEnter(GameState.Start), () => print(1));
    var se = new StepExecutor<SomeEventStep>();
    this.Watch(se.On(SomeEventStep.Step1), () => print(1));

    // In addition, composable events are actually standalone components,
    // except onEnable/onDisable and onDestroy,
    // so if you plan to destroy the script before destroying the game object,
    // and your onUpdate is referencing `this`,
    // maybe you also need to destroy the listener too.
    this.Watch(this.onUpdate, () => print(this));
  }
}
```

### Put Them All Together

Finally, keep the architecture diagram in mind, and put all the pieces together.

![architecture](img/architecture.png)

```cs
using DT.UniStart;
using UnityEngine;

namespace Project {
  // define commands & events
  public record SimpleCommand : ICommand;
  public record SomeCommand(int a, int b) : ICommand;
  public record SomeEvent(int a, int b) : IEvent;

  public class Model : StateManager {
    // store states in readonly model
    public readonly IState<int> count;

    public Model(ICommandRepo cb, IEventInvoker eb) {
      // init states, get writable responsive containers
      var count = this.Init(ref this.count, 0);

      // register model-related commands
      cb.Add<SomeCommand>((e) => {
        // update model in commands
        count.Value = e.a + e.b;
        // publish event to controllers
        eb.Invoke(new SomeEvent(e.a, e.b));
      });
    }
  }

  // attach the entry script to the root game object
  public class App : Entry {
    void Awake() {
      // init context
      var eb = new EventBus();
      var cb = new CommandBus();
      var model = new ModelManager(cb, eb);

      // register context
      this.AddCommandBus(cb, debug: true);
      this.AddEventBus(eb, debug: true);
      this.Add<Model>(model);
    }
  }

  // attach the controller script to other game object
  public class Controller : CBC {
    void Start() {
      // get context
      var cb = this.GetCommandBus();
      var eb = this.GetEventBus();
      var model = this.Get<Model>();

      // update view when model changes
      // or when events are published
      this.Watch(model.count, (v) => print(v));
      this.Watch(eb, (SomeEvent e) => print(e));

      // read model values each frame
      this.onUpdate.AddListener(() => print(model.count.Value));

      // update model when user input
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

## Other Utils

### Timers

Though you can use `MonoBehaviour.Invoke/InvokeRepeating` to realize timers, it's not easy to manage them (e.g. you can't easily stop them or check the progress). `Timer` / `RepeatedTimer` is designed for this.

```cs
public class TimerApp : Entry {
  void Awake() {
    // create a timer with 10s duration
    var timer = new Timer(10);
    // update the timer every frame
    this.onUpdate.AddListener(() => timer.Update(Time.deltaTime));
    // or
    this.onUpdate.AddListener(timer.UpdateWithDelta);
    // or
    timer.Mount(this.onUpdate);
    // stop/start the timer
    // once stopped, the timer will not update
    timer.Stop();
    timer.Start();
    // check timer status
    print(timer.duration);
    print(timer.elapsed);
    print(timer.progress);
    print(timer.finished);
    print(timer.stopped);
    // reset the timer
    timer.Reset();
    // register a callback when the timer finishes
    timer.onFinished.AddListener(() => print("Timer finished!"));
    // you can also register the callback when creating the timer
    new Timer(10, () => print("Timer finished!"));

    // you can also create a repeated timer
    // which is a subclass of Timer.
    // when the repeated timer finishes, it will restart itself
    // so the onFinished event will be called multiple times
    new RepeatedTimer(1);
    new RepeatedTimer(1, () => print("Repeated timer finished!"));
  }
}
```

### Extensions

See [this](https://github.com/DiscreteTom/UniStart/tree/main/Runtime/Extensions) folder.

### Static Utils

See [this](https://github.com/DiscreteTom/UniStart/tree/main/Runtime/Utils) folder.

## Sample Game

See [UniSnake](https://github.com/DiscreteTom/UniStart/tree/main/Samples~/UniSnake). You can also import this sample via Unity3D's package manager.

## Related

- [QFramework](https://github.com/liangxiegame/QFramework) - Which inspired this project.
- [jackutea](https://github.com/jackutea) - Who helped me a lot.

## [CHANGELOG](https://github.com/DiscreteTom/UniStart/blob/main/CHANGELOG.md)
