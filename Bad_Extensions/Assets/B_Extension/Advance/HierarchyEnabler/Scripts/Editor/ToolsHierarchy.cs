using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace B_Extensions.HierarchyStates 
{
    public class ToolsHierarchy
    {
        /// <summary>Ctrl+Shift+E: activa cada StateSetter segun su estado guardado (stateEnable).</summary>
        [MenuItem("B_Extensions/Hierarchy Extension/Restore Object In Hierarchy %#e")]
        private static void CallSearch()
        {
            CustomHierarchy.SearchEnablers();
        }
    }
}

