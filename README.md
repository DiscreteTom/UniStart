# UniStart

An experimental Unity3D framework which can boost your development speed several times over.

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

By using these events and closures, you can write your logic _at the same place_, instead of writing your logic in many different locations like `Start`(to initialize), `Update`, and some other functions you defined. This is inspired by [Vue Composition API](https://vuejs.org/guide/extras/composition-api-faq.html#more-flexible-code-organization).

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

This is inspired by [QFramework](https://github.com/liangxiegame/QFramework)'s IoC container, and [jackutea](https://github.com/jackutea)'s deterministic lifecycle management

### Responsive Containers and EventBus

In UniStart, we have many built-in responsive containers/collections:

```cs
public class Model {
  public Watch<int> Count { get; private set; }
  public WatchList<int> List { get; private set; }
  public WatchArray<bool> Array { get; private set; }
  public WatchDictionary<string, int> Dictionary { get; private set; }

  public Model(int count) {
    // set the initial value
    this.Count = new Watch<int>(count);
    this.List = new WatchList<int>(); // init an empty list
    this.Array = new WatchArray<bool>(10); // init an array with 10 elements
    this.Dictionary = new WatchDictionary<string, int>(); // init an empty dictionary
  }
}
```
