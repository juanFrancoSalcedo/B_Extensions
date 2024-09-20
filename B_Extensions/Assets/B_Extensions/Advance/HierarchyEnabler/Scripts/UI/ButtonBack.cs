using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/UI/ButtonBack.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/UI/ButtonBack.cs
{
    public class ButtonBack : BaseButtonAttendant
    {
        void Start() => buttonComponent.onClick.AddListener(Back);
        private void Back() => NavigationRecordController.Instance.PopElement();
    }
}