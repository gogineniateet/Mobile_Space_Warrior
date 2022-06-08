using System;
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
    public AudioSource enemybulletSound;
    public Transform playerPosition;
    bool spawning = false;



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
        MethodToSpawn();
        if (transform.position.y < -6f )
        {
            PoolManager.Instance.Recycle(Constants.ENEMY_01_SHIP_PREFAB, this.gameObject);
        }
       
    }

    private void MethodToSpawn()
    {
        // float distShip = Vector3.Distance(playerPosition.position, transform.position);
        float distShip = transform.position.y - playerPosition.position.y;
        //Debug.Log(distShip);
        if (spawning == false && distShip < 6f)
        {
            Debug.Log(distShip);

            SpawnManager.Instance.SpawnFire(this.transform.position);
            spawning = true;


            enemybulletSound.Play();

        }
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
