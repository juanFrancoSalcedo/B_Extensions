using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Toggle))]
public class BaseToggle : MonoBehaviour
{
    protected Toggle toggleComponent => GetComponent<Toggle>();
    public void Click(bool isOn) => toggleComponent.onValueChanged?.Invoke(isOn);
    public bool IsOn => toggleComponent.isOn;
}
