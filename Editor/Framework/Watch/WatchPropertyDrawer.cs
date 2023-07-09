#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace DT.UniStart.Editor {
  [CustomPropertyDrawer(typeof(Watch<>))]
  public class WatchPropertyDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      var valueProperty = property.FindPropertyRelative("value");

      EditorGUI.BeginProperty(position, label, property);
      EditorGUI.PropertyField(position, valueProperty, label, true);
      EditorGUI.EndProperty();
    }
  }
}

#endif
