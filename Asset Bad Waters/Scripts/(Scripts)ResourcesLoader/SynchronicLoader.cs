using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SynchronicLoader : BaseResourcesLoader
{
    [Tooltip("EL OBJETO DEBE ESTAR EN LA CARPETA Resources")]
    [SerializeField] private string pathPrefab;
    public static event Action<GameObject> OnObjectCreated = null;
    [field:SerializeField] public bool LoadOnAwake { get; set; } = false;
    [SerializeField] Transform parent = null;
    [SerializeField] private int siblingIndex = 0;
    [SerializeField] Transform transformOriginal = null;

    private void Awake()
    {
        if(LoadOnAwake)
            StartCoroutine(InstanciateFromResources());
    }

    public override void CallInstanciate() => StartCoroutine(InstanciateFromResources());

    public IEnumerator InstanciateFromResources()
    {
        GameObject obj = null;
        var resource = Resources.LoadAsync(pathPrefab);
        if (resource == null)
        {
            Debug.LogError("EL RECURSO NO EXISTE, REVISE EL pathPrefab");
            yield break;
        }
        while (!resource.isDone)
            yield return null;

        var resourceAsset = (GameObject)resource.asset;
        obj = Instantiate(resourceAsset, transformOriginal.position, transformOriginal.rotation, parent);
        obj.transform.SetSiblingIndex(siblingIndex);
        OnObjectCreated?.Invoke(obj);
    }
}
