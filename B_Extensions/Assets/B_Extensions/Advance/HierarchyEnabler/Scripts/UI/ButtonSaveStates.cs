<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/UI/ButtonSaveStates.cs
﻿using B_Extensions;
========
﻿using B_extensions;
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/UI/ButtonSaveStates.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CallerNavigationRecordScan))]
public class ButtonSaveStates : BaseButtonAttendant
{    
    void Start()
    {
        var eventOnClick = buttonComponent.onClick;
        buttonComponent.onClick = new Button.ButtonClickedEvent();
        buttonComponent.onClick.AddListener(GetComponent<CallerNavigationRecordScan>().CallRecord);
        buttonComponent.onClick.AddListener(()=> eventOnClick?.Invoke());
    }
}
