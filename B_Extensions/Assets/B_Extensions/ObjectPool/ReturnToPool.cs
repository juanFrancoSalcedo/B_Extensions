using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
// This component returns the particle system to the pool when the OnParticleSystemStopped event is received.

public class ReturnToPool : MonoBehaviour
{
    public IObjectPool<GameObject> pool;
    [Tooltip("set zero for not disable player")][SerializeField] private float timeDisable =4f;
    public event System.Action<ReturnToPool> OnLocalReturned;
    private Coroutine coroutine;
    private void OnEnable()
    {
        if (timeDisable > 0)
            if(coroutine == null)
                coroutine = StartCoroutine(WaitDisable());
    }

    private IEnumerator WaitDisable()
    {
        yield return new WaitForSecondsRealtime(timeDisable);
        gameObject.SetActive(false);
        coroutine = null;
    }

    private void OnDisable()
    {
        pool.Release(gameObject);
        OnLocalReturned?.Invoke(this);
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}
