using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region PRIVATE VBARIABLE
    private float timer;
    #endregion

    #region
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Constants.ENEMY_SHIP_SPEED * Time.deltaTime);
        timer = timer + Time.deltaTime;

        if (timer > 3f)
        {
            SpawnManager.Instance.SpawnFire(this.transform.position);
            timer = 0;
        }
        if (transform.position.y < -3f )//|| PlayerController.Instance.isGameOver == true)
        {
            PoolManager.Instance.Recycle(Constants.ENEMY_01_SHIP_PREFAB, this.gameObject);
        }

        timer = 0;
    }
    // decreasing player life on enemy ship collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PLAYER_SHIP_LAYER)
        {
            Debug.Log(collision.gameObject.layer);
            //Destroy(collision.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().LostLife(1);
            PoolManager.Instance.Recycle(Constants.ENEMY_01_SHIP_PREFAB, this.gameObject);
        }
    }
    #endregion
}
