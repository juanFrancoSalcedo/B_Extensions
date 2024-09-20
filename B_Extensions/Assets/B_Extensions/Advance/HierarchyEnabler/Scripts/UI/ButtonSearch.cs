using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/HierarchyEnabler/Scripts/UI/ButtonSearch.cs
namespace B_Extensions.HierarchyStates
========
namespace B_extensions.HierarchyStates
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/HierarchyEnabler/Scripts/UI/ButtonSearch.cs
{
    public class ButtonSearch : BaseButtonAttendant
    {
        [field: SerializeField] private StateSetter elementFound;
        [field: SerializeField] bool disableParents = false;

        private void Start()
        {
            buttonComponent.onClick.AddListener(Search);
        }

        private void Search()
        {
            NavigationRecordController.Instance.Searcher.SearchElement(elementFound, disableParents);
        }
    }
}