using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/CallerNavigationRecordScan.cs
using B_Extensions.HierarchyStates;
========
using B_extensions.HierarchyStates;
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/CallerNavigationRecordScan.cs

public class CallerNavigationRecordScan : MonoBehaviour
{
    public void CallRecord() => NavigationRecordController.Instance.ScanElements();
}
