using System;
using UnityEngine;

namespace B_Extensions.HierarchyStates
{
    //is monobehaviour in case a button wants use it
    public class HierarchyActivator : MonoBehaviour
    {
        public void RestoreObjectsByParent(Transform parent, bool justChildrens)
        {
            var compon = parent.GetComponentsInChildren<StateSetter>();
            Array.ForEach(compon, c => {
                if(!ReferenceEquals(c, parent.GetComponent<StateSetter>()))
                    c.EnableOnHierarchy();
                else if(!justChildrens)
                    c.EnableOnHierarchy();
            });
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