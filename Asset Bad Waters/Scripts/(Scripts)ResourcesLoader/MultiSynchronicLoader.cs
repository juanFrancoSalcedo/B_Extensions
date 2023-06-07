using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiSynchronicLoader : BaseResourcesLoader
{
    [SerializeField] private SynchronicLoader[] synchronicLoaders;
    [SerializeField] private bool loadOnAwake = true;
    [SerializeField] private UnityEvent OnWholeResourceLoaded = null;

    private void OnValidate()
    {
        foreach (var item in synchronicLoaders)
        {
            item.LoadOnAwake = false;
        }
    }

    private void Awake()
    {
        if (loadOnAwake)
            CallInstanciate();
    }

    public override void CallInstanciate()
    {
        StartCoroutine(InstanciateFromResources());
    }


    IEnumerator InstanciateFromResources()
    {
        foreach (var item in synchronicLoaders)
            yield return item.InstanciateFromResources();
        OnWholeResourceLoaded?.Invoke();
    }
}
