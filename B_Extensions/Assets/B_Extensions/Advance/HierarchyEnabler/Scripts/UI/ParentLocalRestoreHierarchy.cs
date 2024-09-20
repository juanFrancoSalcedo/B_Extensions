using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/UI/ParentLocalRestoreHierarchy.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/UI/ParentLocalRestoreHierarchy.cs
{
    public class ParentLocalRestoreHierarchy: MonoBehaviour
    {
        [SerializeField] private Transform transformToRestore;
        [SerializeField] private bool justDisableChildren = true;
        public void LocalRestore() => NavigationRecordController.Instance.Activator.RestoreObjectsByParent(transformToRestore, justDisableChildren);
    }
}