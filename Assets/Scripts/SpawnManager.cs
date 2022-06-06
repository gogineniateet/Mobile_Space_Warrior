using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    #region PRIVATE VARIABLE
    private float timer1;
    private float timer2;
    #endregion

    #region SINGLETON
    public static SpawnManager instance;
    public static SpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SpawnManager>();
                if (instance == null)
                {
                    GameObject container = new GameObject("Spawn Manager");
                    instance = container.AddComponent<SpawnManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    #region MONOBEHAVIOUR METHOD
    // Update is called once per frame
    void Update()
    {
        timer1 = timer1 + Time.deltaTime;
        if (timer1 > 2f)
            SpawnEnemyShip01();
        timer2 = timer2 + Time.deltaTime;
        if (timer2 > 5)
            SpawnAsteroid();
    }
    #endregion


    #region PUBLIC METHODS
    public void SpawnEnemyShip01()
    {
        GameObject tempEnemy = PoolManager.Instance.Spawn(Constants.ENEMY_01_SHIP_PREFAB);
        tempEnemy.transform.position = new Vector3(Random.Range(Screen.width, Screen.width), Screen.height, 0f); 
        timer1 = 0;
    }
    public void SpawnFire(Vector3 enemyPosition)
    {
        GameObject tempFire = PoolManager.Instance.Spawn(Constants.ENEMY_BULLET_PREFAB);
        tempFire.transform.position = enemyPosition + new Vector3(0f, -0.8f, 0f);
    }
    public void SpawnAsteroid()
    {
        GameObject tempAsteroid = PoolManager.Instance.Spawn(Constants.ASTEROID_PREFAB);
        tempAsteroid.transform.position = new Vector3(Random.Range(Screen.width, Screen.width), Screen.height, 0f);
        timer2 = 0;
    }
    #endregion
}
