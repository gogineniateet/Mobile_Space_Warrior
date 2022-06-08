using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    #region PRIVATE VBARIABLE
    private float timer;
    private Animator animator;
    //private bool shoot = false;
    //Scene scene;
    #endregion
    public GameObject explosionPrefab;



    private void Start()
    {
        //scene = SceneManager.GetActiveScene();
        animator = GetComponent<Animator>();
        //if(scene.buildIndex == 2)
        //{
        //    shoot = true;
        //}
        //else
        //{
        //    shoot = false;
        //}

    }


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
        if (transform.position.y < -6f )
        {
            PoolManager.Instance.Recycle(Constants.ENEMY_01_SHIP_PREFAB, this.gameObject);
        }
        timer = 0;
    }

    // decreasing player life on enemy ship collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided Bullet : " + collision.gameObject.layer);

        if (collision.gameObject.layer == Constants.PLAYER_SHIP_LAYER)
        {
            collision.gameObject.GetComponent<PlayerController>().LostLife(1);
            PoolManager.Instance.Recycle(Constants.ENEMY_01_SHIP_PREFAB, this.gameObject);
        }
    }

    #endregion


}
