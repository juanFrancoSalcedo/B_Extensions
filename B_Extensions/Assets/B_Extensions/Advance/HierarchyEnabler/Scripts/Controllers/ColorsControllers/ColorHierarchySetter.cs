using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Controllers/ColorsControllers/ColorHierarchySetter.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Controllers/ColorsControllers/ColorHierarchySetter.cs
{
    //[DisallowMultipleComponent]
    public class ColorHierarchySetter : MonoBehaviour
    {
        public Color colorInHierarchy = new Color(1, 1, 1, 1);

        private void OnValidate()
        {
            hideFlags = HideFlags.HideInInspector;
            if (colorInHierarchy.a > 0.5f)
                colorInHierarchy.a = 0.5f;
        }
        public void SetColor(Color newColor) => colorInHierarchy = newColor;

    }
}
