using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    #region PRIVATE VARIABLE
    private float timer1;
    private float timer2;
    #endregion

    #region PUBLIC VARIABLE
    public Canvas  canvas;
    private Vector2 spawnPos;
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
                    GameObject container = new GameObject("SpawnManager");
                    instance = container.AddComponent<SpawnManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    private void Start()
    {
        Vector2 center = Camera.main.ScreenToWorldPoint(canvas.GetComponent<RectTransform>().rect.center);
        Debug.Log(center);
        spawnPos.x = Mathf.Abs(center.x + 0.5f);
        spawnPos.y = Mathf.Abs(center.y - 0.7f);
        Debug.Log(spawnPos);
    }

    #region MONOBEHAVIOUR METHOD
    // Update is called once per frame
    void Update()
    {
        timer1 = timer1 + Time.deltaTime;
        if (timer1 > 2f)
        {
            SpawnEnemyShip01();
            timer1 = 0f;
        }

        timer2 = timer2 + Time.deltaTime;
        if (timer2 > 5)
        {
            SpawnAsteroid();
            timer2 = 0f;
        }
    }
    #endregion


    #region PUBLIC METHODS
    public void SpawnEnemyShip01()
    {
        GameObject tempEnemy = PoolManager.Instance.Spawn(Constants.ENEMY_01_SHIP_PREFAB);
        tempEnemy.transform.position = new Vector3(Random.Range(-spawnPos.x, spawnPos.x), spawnPos.y, 0f);
        //tempEnemy.transform.position = new Vector3(Random.Range(-2, 2), transform.position.y, 0f);
        //tempEnemy.transform.position = transform.position;
    }
    public void SpawnFire(Vector3 enemyPosition)
    {
        GameObject tempFire = PoolManager.Instance.Spawn(Constants.ENEMY_BULLET_PREFAB);
        tempFire.transform.position = enemyPosition + new Vector3(0f, -0.8f, 0f);
    }
    public void SpawnAsteroid()
    {
        GameObject tempAsteroid = PoolManager.Instance.Spawn(Constants.ASTEROID_PREFAB);
        tempAsteroid.transform.position = new Vector3(Random.Range(-spawnPos.x, spawnPos.x), spawnPos.y, 0f);
        //tempAsteroid.transform.position = new Vector3(Random.Range(Screen.width, Screen.width), Screen.height, 0f);
    }
    
    #endregion
}
