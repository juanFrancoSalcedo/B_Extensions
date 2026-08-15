using UnityEngine;

public class PlayerPrefsSaveCaller : MonoBehaviour
{
    public enum ValueType
    {
        Int,
        Float,
        String
    }
    [SerializeField] private ValueType valueType;
    [SerializeField] protected string key;

    public void CallSaveInt(int value) => PlayerPrefs.SetInt(key, value);

    public void CallSaveFloat(float value) => PlayerPrefs.SetFloat(key, value);

    public void CallSaveString(string value) => PlayerPrefs.SetString(key, value);

}