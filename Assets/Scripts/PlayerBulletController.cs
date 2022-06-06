using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    #region PUBLIC VARIBALE 
    public float bulletSpeed = 1.0f;
    public float screenTop = 6f;
    public ScoreManager score;
    #endregion

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position + transform.up * bulletSpeed * Time.deltaTime;
        newPosition.z = 0f;
        transform.position = newPosition;

        if(transform.position.y > screenTop)
        {
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
        }
    }

   
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
            PoolManager.Instance.Recycle(Constants.ASTEROID_PREFAB, collision.gameObject);
            score.ScoreCalculater(5);            
            // EXPLOSION PARTICAL EFFECT
        }
        if(collision.gameObject.tag == "01_Enemy")
        {
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
            PoolManager.Instance.Recycle(Constants.ENEMY_01_SHIP_PREFAB, collision.gameObject);
            score.ScoreCalculater(10);
            // PARTICAL EFFECT
        }
        if (collision.gameObject.name == "02_Enemy")
        {
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
            PoolManager.Instance.Recycle(Constants.ENEMY_BULLET_PREFAB, collision.gameObject);
            // PARTICAL EFFECT
        }
    }
}
