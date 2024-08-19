using System;
using UnityEngine;

namespace B_extensions
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