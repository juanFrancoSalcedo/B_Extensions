using UnityEditor;
using UnityEngine;


[InitializeOnLoad]
public static class BExtensionVersion
{
    static string versionKey = "BExtensionVersion_Shown";
    static string version = "1.1.23";
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
