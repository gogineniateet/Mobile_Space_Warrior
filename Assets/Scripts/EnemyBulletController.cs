using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    #region PUBLIC VARIABLES 
    public AudioSource enemyBulletSound;
    #endregion

    #region MONOBEHAVIOUR METHODS
    private void Update()
    {
        transform.Translate(Vector3.down * Constants.ENEMY_BULLET_SPEED * Time.deltaTime); //movement of the enemy bullet
        enemyBulletSound.Play();
        if (transform.position.y < -7f)
        {         
            PoolManager.Instance.Recycle("EnemyBullet", this.gameObject);
        }
    }
    #endregion
    #region PUBLIC METHODS

    //Checking Enemy bullet collision with Player 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PLAYER_SHIP_LAYER)
        {
            PlayerController.Instance.LostLife(1);
            PoolManager.Instance.Recycle("EnemyBullet", this.gameObject);
        }
       
    }
    #endregion

}
