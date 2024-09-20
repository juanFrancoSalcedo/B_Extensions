<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/SceneLoader/Scripts/CallerSceneLoader.cs
﻿using B_Extensions;
========
﻿using B_extensions;
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/SceneLoader/Scripts/CallerSceneLoader.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<<< HEAD:B_Extensions/Assets/B_Extension/Advance/SceneLoader/Scripts/CallerSceneLoader.cs
namespace B_Extensions.SceneLoader
========
namespace B_extensions.SceneLoader
>>>>>>>> 9c4bc29519a438132e66a381b77b02e5aa7eca6e:B_Extensions/Assets/B_Extensions/Advance/SceneLoader/Scripts/CallerSceneLoader.cs
{
    public class CallerSceneLoader : MonoBehaviour
    {
        public static List<string> listScenes = new List<string>();
        [ListToEnumEditor(typeof(CallerSceneLoader), nameof(listScenes))]
        public string sceneName;//= System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(0));

        public void LoadScene()
        {
            SceneLoader.Instance.LoadScene(sceneName);
        }

        #region EditorMethods
        private void OnValidate()
        {
            ReadScenes();
        }

        [ContextMenu("Read Scenes")]
        public void ReadScenes()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            listScenes.Clear();

            for (int i = 0; i < sceneCount; i++)
            {
                listScenes.Add(System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)));
            }
        }
        #endregion
    }
}