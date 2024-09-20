using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/SceneLoader/Scripts/Editor/ShortCutScenes.cs
namespace B_Extensions.SceneLoader
========
namespace B_extensions.SceneLoader
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/SceneLoader/Scripts/Editor/ShortCutScenes.cs
{ 
    public class ShortCutScenes
    {
        #if UNITY_EDITOR
    
<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/SceneLoader/Scripts/Editor/ShortCutScenes.cs
        [MenuItem("B_Extensions/SceneLoader/Previous Scene #%LEFT")]
========
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/SceneLoader/Scripts/Editor/ShortCutScenes.cs
        public static void DisplayTwo()
        {
            EditorSceneManager.OpenScene(WindowSceneSelection.previousScenePath);
        }
        #endif
    }
}
