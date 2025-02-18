using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[InitializeOnLoad]
public static class BExtensionVersion
{
    static string versionKey = "BExtensionVersion_Shown";
    static string version = "1.4.1";
    static BExtensionVersion()
    {

        if (!SessionState.GetBool(versionKey, false))
        {
            Debug.Log($"B_Extension version {version}");
            SessionState.SetBool(versionKey, true);
        }
    }
}
#endif
