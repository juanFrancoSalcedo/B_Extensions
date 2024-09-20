using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/NavigationRecordInstaller.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/NavigationRecordInstaller.cs
{
    public class NavigationRecordInstaller : MonoBehaviour
    {
        private void OnValidate()
        {
            InstanciateActivator();
            InstanciateSearch();
        }

        private void InstanciateActivator()
        {
            if (transform.childCount == 0 || transform.GetChild(0) == null)
            {
                GameObject obj = new GameObject();
                obj.AddComponent(typeof(HierarchyActivator));
                obj.transform.SetParent(transform);
                obj.name = "HierarchyActivator";
            }
        }

        private void InstanciateSearch()
        {
            if (transform.childCount == 1 || transform.GetChild(1) == null)
            {
                GameObject obj = new GameObject();
                obj.AddComponent(typeof(NavigationRecordSearch));
                obj.transform.SetParent(transform);
                obj.name = "NavigationRecordSearch";
            }
        }
    }
}