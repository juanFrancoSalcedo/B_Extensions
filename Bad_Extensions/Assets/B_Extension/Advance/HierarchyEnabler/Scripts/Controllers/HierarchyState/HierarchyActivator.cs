using UnityEngine;

namespace B_Extensions.HierarchyStates
{
    //is monobehaviour in case a button wants use it
    public class HierarchyActivator : MonoBehaviour
    {
        public void RestoreObjectsByParent(Transform parent, bool justChildrens)
        {
            var compon = parent.GetComponentsInChildren<StateSetter>(true);
            foreach (var c in compon)
            {
                if (c.transform == parent && justChildrens) continue;
                c.EnableOnHierarchy();
            }
        }

        
        public void RestoreObjects()
        {
#if UNITY_6000_6_OR_NEWER
            StateSetter[] compon = FindObjectsByType<StateSetter>(FindObjectsInactive.Include);
#elif UNITY_2023_1_OR_NEWER
            StateSetter[] compon = FindObjectsByType<StateSetter>(FindObjectsInactive.Include, FindObjectsSortMode.None);
#else
            StateSetter[] compon = FindObjectsOfType<StateSetter>(true);
#endif
            foreach (var c in compon)
                c.EnableOnHierarchy();
        }
    }
}
