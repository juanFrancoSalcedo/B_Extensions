using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/SceneLoader/Scripts/Editor/EditorSceneLoader.cs
using B_Extensions.SceneLoader;
========
using B_extensions.SceneLoader;
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/SceneLoader/Scripts/Editor/EditorSceneLoader.cs


#if UNITY_EDITOR
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SceneLoader))]
public class EditorSceneLoader : Editor
{
    SceneLoader controller;

    public override void OnInspectorGUI()
    {
        controller = (SceneLoader)target;

        base.OnInspectorGUI();
    }

}
#endif
