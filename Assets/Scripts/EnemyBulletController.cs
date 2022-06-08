using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public AudioSource enemyBulletSound;
    private void Update()
    {
        transform.Translate(Vector3.down * Constants.ENEMY_BULLET_SPEED * Time.deltaTime);
        if (transform.position.y < -7f || PlayerController.Instance.isGameOver == true)
        {
            enemyBulletSound.Play();
            PoolManager.Instance.Recycle("EnemyBullet", this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PlayerController.Instance.LostLife(1);
            PoolManager.Instance.Recycle("EnemyBullet", this.gameObject);
        }
        if(collision.gameObject.layer == 8)
        {
            PoolManager.Instance.Recycle("EnemyBullet", this.gameObject);
        }
    }

}
