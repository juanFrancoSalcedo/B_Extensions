using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Base/BaseButtonAttendant.cs
namespace B_Extensions
========
namespace B_extensions
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Base/BaseButtonAttendant.cs
{
    [RequireComponent(typeof(Button))]
    public class BaseButtonAttendant : MonoBehaviour
    {
        protected Button buttonComponent => GetComponent<Button>();

        public void Click() => buttonComponent.onClick?.Invoke();
    }
}