using System;
using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Controllers/HierarchyState/HierarchyActivator.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Controllers/HierarchyState/HierarchyActivator.cs
{
    //is monobehaviour in case a button wants use it
    public class HierarchyActivator : MonoBehaviour
    {
        public void RestoreObjectsByParent(Transform parent, bool justChildrens)
        {
            var compon = parent.GetComponentsInChildren<StateSetter>();
            Array.ForEach(compon, c => c.EnableOnHierarchy());
            if (parent.GetComponent<StateSetter>() && !justChildrens)
                parent.GetComponent<StateSetter>().EnableOnHierarchy();
        }

        public void RestoreObjects()
        {
            StateSetter[] compon = null;
#if UNITY_2019
            compon = Resources.FindObjectsOfTypeAll<StateSetter>();
#else
        compon = FindObjectsOfType<StateSetter>(true);
#endif
            Array.ForEach(compon, c => c.EnableOnHierarchy());
        }
    }
}