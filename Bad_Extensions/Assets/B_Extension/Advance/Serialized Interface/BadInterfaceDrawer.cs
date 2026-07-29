using UnityEditor;
using UnityEngine;


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(RequireBadInterfaceAttribute))]

public class BadInterfaceDrawer : PropertyDrawer
{
    private RequireBadInterfaceAttribute badAtribute;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        badAtribute = attribute as RequireBadInterfaceAttribute;

        System.Type requiredType = badAtribute.Type;

        EditorGUI.BeginProperty(position, label, property);

        UnityEngine.Object currentObject = property.objectReferenceValue;
        property.objectReferenceValue = EditorGUI.ObjectField(position, label, currentObject, fieldInfo.FieldType, true);

        if (property.objectReferenceValue != null)
        {
            bool isValid = false;
            var obj = property.objectReferenceValue;

            if (obj is GameObject go)
            {
                isValid = go.GetComponent(requiredType) != null;
            }
            else if (obj is Component comp)
            {
                isValid = comp.gameObject.GetComponent(requiredType) != null;
            }
            else if (requiredType.IsInstanceOfType(obj))
            {
                isValid = true;
            }

            if (!isValid)
            {
                property.objectReferenceValue = null;
                Debug.LogError($"El objeto asignado no tiene un componente que implemente la interfaz {requiredType.Name}");
            }
        }

        EditorGUI.EndProperty();
    }
}
#endif