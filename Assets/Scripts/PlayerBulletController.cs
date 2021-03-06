using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    #region PUBLIC VARIBALE 
    public float bulletSpeed = 1.0f;
    public float screenTop = 6f;
    public ScoreManager kills;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] GameObject asteroidenemyPrefab;

    #endregion


    #region MONOBEHAVIOUR METHOD
    private void Start()
    {
        kills = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position + transform.up * bulletSpeed * Time.deltaTime;
        newPosition.z = 0f;
        transform.position = newPosition;

        if (transform.position.y > screenTop)
        {
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
        }
    }
    #endregion


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Collided : " + collision.gameObject.name);
        if (collision.gameObject.layer == Constants.ASTEROID_LAYER)
        {
            Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
            PoolManager.Instance.Recycle(Constants.ASTEROID_PREFAB, collision.gameObject);
            kills.ScoreCalculater(5);
           
            

            // EXPLOSION PARTICAL EFFECT
        }
        
        if (collision.gameObject.layer == Constants.ENEMY_01_SHIP_LAYER)
        {
            Instantiate(explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
            PoolManager.Instance.Recycle(Constants.ENEMY_01_SHIP_PREFAB, collision.gameObject);

            kills.ScoreCalculater(10);

            //collision.gameObject.GetComponent<EnemyController>().Damage();
            // PARTICAL EFFECT
        }
        if (collision.gameObject.layer == Constants.ENEMY_BULLET_LAYER)
        {
            Instantiate(asteroidenemyPrefab, transform.position, Quaternion.identity);
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
            PoolManager.Instance.Recycle(Constants.ENEMY_BULLET_PREFAB, collision.gameObject);
           
        }
    }

    
}
