
using UnityEngine;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/NavigationRecordControllerExtensions.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/NavigationRecordControllerExtensions.cs
{
    public static class NavigationRecordControllerExtensions 
    {
        public static StateSetter GetSetterById(this NavigationRecordController controller , StateReference _reference)
        {
            foreach (var item in controller.sceneSetters)
            {
                bool f = (item.reference.UniqueId.Equals(_reference.UniqueId));
            }
            //wholeSetters.ForEach(t => print(t.reference.uniqueId));
            var element = controller.sceneSetters.Find(e => e.reference.UniqueId.Equals(_reference.UniqueId));
            return element;
        }
    }
}
