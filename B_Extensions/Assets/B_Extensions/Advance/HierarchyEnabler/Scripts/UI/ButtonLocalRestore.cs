using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace B_extensions.HierarchyStates
{
    [RequireComponent(typeof(ParentLocalRestoreHierarchy))]
    public class ButtonLocalRestore : BaseButtonAttendant
    {
        void Start() => buttonComponent.onClick.AddListener(LocalRestore);
        public void LocalRestore() => GetComponent<ParentLocalRestoreHierarchy>().LocalRestore();
    }
}