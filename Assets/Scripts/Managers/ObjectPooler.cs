using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    //Small projectiles
    private List<GameObject> _pooledSmallProjectiles;
    public GameObject smallProjectilesToPool;
    public int amountOfSmallProjectilesToPool;
    
    //Medium projectiles
    private List<GameObject> _pooledMediumProjectiles;
    public GameObject mediumProjectilesToPool;
    public int amountOfMediumProjectilesToPool;
    
    //Enemies
    private List<GameObject> _pooledEnemies;
    public GameObject lightEnemyTankToPool;
    public GameObject heavyEnemyTankToPool;
    public int amountOfEnemiesToPool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _pooledSmallProjectiles = new List<GameObject>();
        for (int i = 0; i < amountOfSmallProjectilesToPool; i++)
        {
            GameObject proj = (GameObject)Instantiate(smallProjectilesToPool, this.transform, true);
            proj.SetActive(false);
            _pooledSmallProjectiles.Add(proj);
        }
        
        _pooledMediumProjectiles = new List<GameObject>();
        for (int i = 0; i < amountOfMediumProjectilesToPool; i++)
        {
            GameObject proj = (GameObject)Instantiate(mediumProjectilesToPool, this.transform, true);
            proj.SetActive(false);
            _pooledMediumProjectiles.Add(proj);
        }

        _pooledEnemies = new List<GameObject>();
        for (int i = 0; i < amountOfEnemiesToPool; i++)
        {
            GameObject lightTank = Instantiate(lightEnemyTankToPool, this.transform, true);
            GameObject heavyTank = Instantiate(heavyEnemyTankToPool, this.transform, true);
            lightTank.SetActive(false);
            heavyTank.SetActive(false);
            _pooledEnemies.Add(lightTank);
            _pooledEnemies.Add(heavyTank);
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
