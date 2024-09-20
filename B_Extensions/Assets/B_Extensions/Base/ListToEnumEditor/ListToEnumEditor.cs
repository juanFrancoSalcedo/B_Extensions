using System;
using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Base/ListToEnumEditor/ListToEnumEditor.cs
namespace B_Extensions
========
namespace B_extensions
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Base/ListToEnumEditor/ListToEnumEditor.cs
{
    public class ListToEnumEditor : PropertyAttribute
    {
        public Type type = null;
        public string propertyName = "";
        public ListToEnumEditor(Type type, string propertyName)
        {
            this.type = type;
            this.propertyName = propertyName;
        }
    }
}