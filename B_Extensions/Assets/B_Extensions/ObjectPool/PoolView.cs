using UnityEngine;
using UnityEngine.Pool;
// This example spans a random number of ParticleSystems using a pool so that old systems can be reused.
public class PoolView : MonoBehaviour
{

    [field:SerializeField] public GameObject Prefab { get; set; }

    // Collection checks will throw errors if we try to release an item that is already in the pool.
    public bool collectionChecks = true;
    public int maxPoolSize = 10;

    IObjectPool<GameObject> m_Pool;

    public IObjectPool<GameObject> Pool
    {
        get
        {
            if (m_Pool == null)
            {
                m_Pool = new LinkedPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
            }
            return m_Pool;
        }
    }

    GameObject CreatePooledItem()
    {
        var go = Instantiate(Prefab);
        // TODO IMPROVE THIS WITH CONFIGURE METHOD
        var returnToPool = go.GetComponent<ReturnToPool>();
        returnToPool.pool = Pool;
        return go;
    }

    // Called when an item is returned to the pool using Release
    void OnReturnedToPool(GameObject system)
    {
        system.gameObject.SetActive(false);
    }

    // Called when an item is taken from the pool using Get
    void OnTakeFromPool(GameObject system)
    {
        system.gameObject.SetActive(true);
    }

    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    void OnDestroyPoolObject(GameObject system)
    {
        Destroy(system.gameObject);
    }
}
