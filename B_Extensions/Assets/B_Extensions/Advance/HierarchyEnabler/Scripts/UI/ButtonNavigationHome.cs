<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/UI/ButtonNavigationHome.cs
﻿using B_Extensions.HierarchyStates;
========
﻿using B_extensions.HierarchyStates;
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/UI/ButtonNavigationHome.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationHome : MonoBehaviour
{
    Button buttonComponent => GetComponent<Button>();

    private void Start()
    {
        buttonComponent.onClick.AddListener(Home);
    }

    private void Home() 
    {
        NavigationRecordController.Instance.ClearRecord();
        NavigationRecordController.Instance.Activator.RestoreObjects();
    }
}
