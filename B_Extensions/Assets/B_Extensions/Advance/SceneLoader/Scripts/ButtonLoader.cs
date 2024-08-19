using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using B_extensions;
using B_extensions.SceneLoader;

[RequireComponent(typeof(CallerSceneLoader))]
public class ButtonLoader : BaseButtonAttendant
{
    private void Start() => buttonComponent.onClick.AddListener(LoadScene);
    private void LoadScene() => GetComponent<CallerSceneLoader>().LoadScene();
}