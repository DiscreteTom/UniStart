using DT.UniStart.AdvancedEventBase;

namespace DT.UniStart {
  public class AdvancedEvent : BaseAdvancedEvent<ActionItem> {
    public void Invoke() {
      foreach (var item in this.e) {
        switch (item.paramCount) {
          default:
            item.action0.Invoke();
            break;
        }
      }
      foreach (var item in this.once) {
        switch (item.paramCount) {
          default:
            this.RemoveListener(item.action0);
            break;
        }
      }
      this.once.Clear();
    }
  }

  public class AdvancedEvent<T0> : BaseAdvancedEvent<T0, ActionItem<T0>> {
    public void Invoke(T0 arg0) {
      foreach (var item in this.e) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._1:
            item.action1.Invoke(arg0);
            break;
          default:
            item.action0.Invoke();
            break;
        }
      }
      foreach (var item in this.once) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._1:
            this.RemoveListener(item.action1);
            break;
          default:
            this.RemoveListener(item.action0);
            break;
        }
      }
      this.once.Clear();
    }
  }

  public class AdvancedEvent<T0, T1> : BaseAdvancedEvent<T0, T1, ActionItem<T0, T1>> {
    public void Invoke(T0 arg0, T1 arg1) {
      foreach (var item in this.e) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._2:
            item.action2.Invoke(arg0, arg1);
            break;
          case AdvancedEventParamCount._1:
            item.action1.Invoke(arg0);
            break;
          default:
            item.action0.Invoke();
            break;
        }
      }
      foreach (var item in this.once) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._2:
            this.RemoveListener(item.action2);
            break;
          case AdvancedEventParamCount._1:
            this.RemoveListener(item.action1);
            break;
          default:
            this.RemoveListener(item.action0);
            break;
        }
      }
      this.once.Clear();
    }
  }

  public class AdvancedEvent<T0, T1, T2> : BaseAdvancedEvent<T0, T1, T2, ActionItem<T0, T1, T2>> {
    public void Invoke(T0 arg0, T1 arg1, T2 arg2) {
      foreach (var item in this.e) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._3:
            item.action3.Invoke(arg0, arg1, arg2);
            break;
          case AdvancedEventParamCount._2:
            item.action2.Invoke(arg0, arg1);
            break;
          case AdvancedEventParamCount._1:
            item.action1.Invoke(arg0);
            break;
          default:
            item.action0.Invoke();
            break;
        }
      }
      foreach (var item in this.once) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._3:
            this.RemoveListener(item.action3);
            break;
          case AdvancedEventParamCount._2:
            this.RemoveListener(item.action2);
            break;
          case AdvancedEventParamCount._1:
            this.RemoveListener(item.action1);
            break;
          default:
            this.RemoveListener(item.action0);
            break;
        }
      }
      this.once.Clear();
    }
  }

  public class AdvancedEvent<T0, T1, T2, T3> : BaseAdvancedEvent<T0, T1, T2, T3, ActionItem<T0, T1, T2, T3>> {
    public void Invoke(T0 arg0, T1 arg1, T2 arg2, T3 arg3) {
      foreach (var item in this.e) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._4:
            item.action4.Invoke(arg0, arg1, arg2, arg3);
            break;
          case AdvancedEventParamCount._3:
            item.action3.Invoke(arg0, arg1, arg2);
            break;
          case AdvancedEventParamCount._2:
            item.action2.Invoke(arg0, arg1);
            break;
          case AdvancedEventParamCount._1:
            item.action1.Invoke(arg0);
            break;
          default:
            item.action0.Invoke();
            break;
        }
      }
      foreach (var item in this.once) {
        switch (item.paramCount) {
          case AdvancedEventParamCount._4:
            this.RemoveListener(item.action4);
            break;
          case AdvancedEventParamCount._3:
            this.RemoveListener(item.action3);
            break;
          case AdvancedEventParamCount._2:
            this.RemoveListener(item.action2);
            break;
          case AdvancedEventParamCount._1:
            this.RemoveListener(item.action1);
            break;
          default:
            this.RemoveListener(item.action0);
            break;
        }
      }
      this.once.Clear();
    }
  }
}