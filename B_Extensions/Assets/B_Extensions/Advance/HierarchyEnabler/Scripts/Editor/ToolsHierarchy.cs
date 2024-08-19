using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace B_extensions.HierarchyStates 
{
    public class ToolsHierarchy
    {
        public static event System.Action OnRestored = null;

        [MenuItem("B_extensions/Navigation Hierarchy/Restore Object In Hierarchy %#e")]
        private static void CallSearch()
        {
            CustomHierarchy.SearchEnablers();
            OnRestored?.Invoke();
        }

    }
}

