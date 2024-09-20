using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Editor/ToolsHierarchy.cs
namespace B_Extensions.HierarchyStates 
========
namespace B_extensions.HierarchyStates 
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Editor/ToolsHierarchy.cs
{
    public class ToolsHierarchy
    {
        public static event System.Action OnRestored = null;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Editor/ToolsHierarchy.cs
        [MenuItem("B_Extensions/Navigation Hierarchy/Restore Object In Hierarchy %#e")]
========
        [MenuItem("B_extensions/Navigation Hierarchy/Restore Object In Hierarchy %#e")]
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Editor/ToolsHierarchy.cs
        private static void CallSearch()
        {
            CustomHierarchy.SearchEnablers();
            OnRestored?.Invoke();
        }

    }
}

