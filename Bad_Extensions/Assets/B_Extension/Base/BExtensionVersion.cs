using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[InitializeOnLoad]
public static class BExtensionVersion
{
    static string versionKey = "BExtensionVersion_Shown";
    static string version = "1.1.4";
    static BExtensionVersion()
    {

        if (!SessionState.GetBool("FirstInitDone", false))
        {
            // Startup code here...
            Debug.Log($"B_Extension version {version}");
            SessionState.SetBool("FirstInitDone", true);
        }
    }
}
#endif
