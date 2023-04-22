using UnityEngine.Events;

namespace DT.UniStart {
  public interface IWatchable {
    UnityAction AddListener(UnityAction f);
    UnityAction RemoveListener(UnityAction f);
  }
}