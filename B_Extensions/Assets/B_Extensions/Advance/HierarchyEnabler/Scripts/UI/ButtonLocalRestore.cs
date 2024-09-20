using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/UI/ButtonLocalRestore.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/UI/ButtonLocalRestore.cs
{
    [RequireComponent(typeof(ParentLocalRestoreHierarchy))]
    public class ButtonLocalRestore : BaseButtonAttendant
    {
        void Start() => buttonComponent.onClick.AddListener(LocalRestore);
        public void LocalRestore() => GetComponent<ParentLocalRestoreHierarchy>().LocalRestore();
    }
}