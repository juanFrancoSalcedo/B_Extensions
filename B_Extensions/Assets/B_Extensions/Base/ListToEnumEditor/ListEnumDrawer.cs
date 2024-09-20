using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Base/ListToEnumEditor/ListEnumDrawer.cs
namespace B_Extensions
========
namespace B_extensions
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Base/ListToEnumEditor/ListEnumDrawer.cs
{
    [CustomPropertyDrawer(typeof(ListToEnumEditor))]
    public class ListEnumDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ListToEnumEditor atb = attribute as ListToEnumEditor;
            List<string> stringList = null;

            //base.OnGUI(position, property, label);
            //System.Array.ForEach(atb.type.GetFields(), e => Debug.Log(e.Name));
            if (atb.type.GetField(atb.propertyName) != null)
            {
                stringList = atb.type.GetField(atb.propertyName).GetValue(atb.type) as List<string>;
            }

            if (stringList != null && stringList.Count > 0)
            {
                int selectedIndex = Mathf.Max(stringList.IndexOf(property.stringValue), 0);
                selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, stringList.ToArray());
                property.stringValue = stringList[selectedIndex];
            }
            else
            {
                label.text = "ASINGA UN ELEMENTO";
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}

#endif


