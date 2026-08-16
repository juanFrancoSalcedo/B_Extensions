using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPrefsEventListener : MonoBehaviour
{
    [Header("Trigger Settings")]
    [Tooltip("Run CheckExist once when the component awakens.")]
    [SerializeField] protected bool onAwake;
    [Tooltip("Run CheckExist every time the component is enabled.")]
    [SerializeField] protected bool onEnable;
    [Tooltip("Run CheckExist every second while the component is enabled.")]
    [SerializeField] protected bool periodic;

    [Header("Key Settings")]
    [Tooltip("PlayerPrefs key to check and compare.")]
    [SerializeField] protected string key;
    [Tooltip("Type used to read the value from PlayerPrefs.")]
    [SerializeField] protected ValueType valueType;
    [Tooltip("Value to compare against the stored PlayerPrefs value (parsed according to ValueType).")]
    [SerializeField] protected string compareValue;

    [Header("Existence Events")]
    [Tooltip("Invoked when the key exists in PlayerPrefs.")]
    [SerializeField] protected UnityEvent onExistKey;
    [Tooltip("Invoked when the key does not exist in PlayerPrefs.")]
    [SerializeField] protected UnityEvent onDoesntExistKey;

    [Header("Comparison Events")]
    [Tooltip("Invoked when the stored value equals compareValue.")]
    [SerializeField] protected UnityEvent onValueMatches;
    [Tooltip("Invoked when the stored value differs from compareValue.")]
    [SerializeField] protected UnityEvent onValueDiffers;

    public event System.Action<bool> OnExistKey;
    public event System.Action<bool> OnValueMatches;

    protected void OnEnable()
    {
        if (onEnable)
            CheckExist();

        if (periodic)
            StartCoroutine(DoPeriodicCheck());
    }

    private void OnDisable() => StopAllCoroutines();

    protected void Awake()
    {
        if (onAwake)
            CheckExist();
    }

    private IEnumerator DoPeriodicCheck()
    {
        while (periodic)
        {
            yield return new WaitForSecondsRealtime(1f);
            CheckExist();
        }
    }

    public void CheckExist()
    {
        bool exists = PlayerPrefs.HasKey(key);
        OnExistKey?.Invoke(exists);

        if (exists)
        {
            onExistKey?.Invoke();
            CompareValue();
        }
        else
        {
            onDoesntExistKey?.Invoke();
        }
    }

    public void CompareValue()
    {
        if (!PlayerPrefs.HasKey(key))
            return;

        bool matches = valueType switch
        {
            ValueType.Int => PlayerPrefs.GetInt(key) == SafeParseInt(compareValue),
            ValueType.Float => PlayerPrefs.GetFloat(key) == SafeParseFloat(compareValue),
            ValueType.String => PlayerPrefs.GetString(key) == compareValue,
            _ => false
        };

        OnValueMatches?.Invoke(matches);
        if (matches)
            onValueMatches?.Invoke();
        else
            onValueDiffers?.Invoke();
    }

    private static int SafeParseInt(string s) => int.TryParse(s, out var v) ? v : 0;
    private static float SafeParseFloat(string s) => float.TryParse(s, out var v) ? v : 0f;
}

public enum ValueType
{
    Int,
    Float,
    String
}
