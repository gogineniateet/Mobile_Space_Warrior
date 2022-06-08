using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{    
    #region PUBLIC VARIABLES
    public ObjectToPool[] prefabsToPool;
    #endregion

    #region PRIVATE VARIABLES
    private Dictionary<string, ObjectPool> pools;
    #endregion

    #region SINGLETON 
    public static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PoolManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("PoolManager");
                    _instance = container.AddComponent<PoolManager>();
                }
            }
            return _instance;
        }
    }
    #endregion

    #region MONOBEHAVIOUR METHOD
    void Start()
    {
        for (int i = 0; i < prefabsToPool.Length; i++)
        {
            CreatePool(prefabsToPool[i].prefab, prefabsToPool[i].initialCapacity);
        }
    }
    #endregion

    #region PUBLIC METHOD
    // Create a new pool of objects at runtime.
    public void CreatePool(GameObject prefab, int initialCapacity)
    {
        if (pools == null)
        {
            pools = new Dictionary<string, ObjectPool>();
        }   
        ObjectPool newPool = new ObjectPool(prefab, initialCapacity);
        pools.Add(prefab.name, newPool);
    }
    // Spawn an object with the given name.
    public GameObject Spawn(string prefabName)
    {
        if (!pools.ContainsKey(prefabName))
            return null;

        return pools[prefabName].Spawn();
    }
    // Recycle an object with the given name.
    public void  Recycle(string prefabName, GameObject gameObj)
    {
        if (!pools.ContainsKey(prefabName))
        {
            return;
        }
      pools[prefabName].Recycle(gameObj);
    }
    #endregion
}






[System.Serializable]
public class ObjectToPool
{
    public GameObject prefab;
    public int initialCapacity;
}