using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    //Small projectiles
    [SerializeField] private List<GameObject> smallProjectilesToPool;
    [SerializeField] private int amountOfSmallProjectilesToPool;
    private List<GameObject> _pooledSmallProjectiles;
    
    //Medium projectiles
    [SerializeField] private List<GameObject> mediumProjectilesToPool;
    [SerializeField] private int amountOfMediumProjectilesToPool;
    private List<GameObject> _pooledMediumProjectiles;
    
    //Enemies
    [SerializeField] private List<GameObject> enemyTankToPool;
    [SerializeField] private int amountOfEnemiesToPool;
    private List<GameObject> _pooledEnemies;

    private void Awake()
    {
        Instance = this;
        
        _pooledSmallProjectiles = new List<GameObject>();
        _pooledMediumProjectiles = new List<GameObject>();
        _pooledEnemies = new List<GameObject>();
    }

    private void Start()
    {
        AddObjectsToPool(smallProjectilesToPool, amountOfSmallProjectilesToPool,_pooledSmallProjectiles);
        AddObjectsToPool(mediumProjectilesToPool, amountOfMediumProjectilesToPool,_pooledMediumProjectiles);
        AddObjectsToPool(enemyTankToPool, amountOfEnemiesToPool, _pooledEnemies);
    }

    private void AddObjectsToPool(List<GameObject> objToPool, int amount, List<GameObject> pooledObj)
    {
        for (int i = 0; i < amount; i++)
        {
            for (int j = 0; j < objToPool.Count; j++)
            {
                GameObject obj = (GameObject) Instantiate(objToPool[j], this.transform, true);
                obj.SetActive(false);
                pooledObj.Add(obj);
            }
        }
    }

    public GameObject GetPooledSmallProjectile()
    {
        for (int i = 0; i < _pooledSmallProjectiles.Count; i++)
        {
            if (!_pooledSmallProjectiles[i].activeInHierarchy)
                return _pooledSmallProjectiles[i];
        }

        return null;
    }
    
    public GameObject GetPooledMediumProjectile()
    {
        for (int i = 0; i < _pooledMediumProjectiles.Count; i++)
        {
            if (!_pooledMediumProjectiles[i].activeInHierarchy)
                return _pooledMediumProjectiles[i];
        }

        return null;
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < _pooledEnemies.Count; i++)
        {
            if (!_pooledEnemies[i].activeInHierarchy)
                return _pooledEnemies[i];
        }

        return null;
    }
}
