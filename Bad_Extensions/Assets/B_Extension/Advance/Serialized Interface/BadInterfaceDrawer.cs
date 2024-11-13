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

        // Obtenemos el valor actual como un `Object`
        UnityEngine.Object currentObject = property.objectReferenceValue;
        property.objectReferenceValue = EditorGUI.ObjectField(position, label, currentObject, typeof(UnityEngine.Object), true);

        // Validar que el objeto asignado implemente la interfaz requerida
        if (property.objectReferenceValue != null &&
            !requiredType.IsInstanceOfType(property.objectReferenceValue))
        {
            property.objectReferenceValue = null;
            Debug.LogWarning($"El objeto asignado no implementa la interfaz {requiredType.Name}");
        }

        EditorGUI.EndProperty();
    }
}
#endif