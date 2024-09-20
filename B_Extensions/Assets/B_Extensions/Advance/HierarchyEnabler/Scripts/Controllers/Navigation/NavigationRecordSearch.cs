using UnityEngine;
using System;
using System.Collections.Generic;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/NavigationRecordSearch.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/Controllers/Navigation/NavigationRecordSearch.cs
{
    //is monobehaviour in case a button wants use it
    public class NavigationRecordSearch : MonoBehaviour
    {
        List<GameObject> bufferParents = new List<GameObject>();
        public void SearchElement(StateSetter element, bool disableParents)
        {
            Transform _parent = element.transform.parent;
            while (_parent != null)
            {
                _parent = WriteParent(_parent, disableParents);
            }
            element.SetActive(true);
        }

        private Transform WriteParent(Transform _parent, bool disableParents)
        {
            if (!_parent.gameObject.activeInHierarchy && disableParents)
                bufferParents.Add(_parent.gameObject);
            _parent.gameObject.SetActive(true);
            _parent = _parent.parent;
            return _parent;
        }
    }
}