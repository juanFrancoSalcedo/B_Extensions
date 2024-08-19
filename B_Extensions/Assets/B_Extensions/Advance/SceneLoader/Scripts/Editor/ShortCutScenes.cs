using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace B_extensions.SceneLoader
{ 
    public class ShortCutScenes
    {
        #if UNITY_EDITOR
    
        public static void DisplayTwo()
        {
            EditorSceneManager.OpenScene(WindowSceneSelection.previousScenePath);
        }
        #endif
    }
}
