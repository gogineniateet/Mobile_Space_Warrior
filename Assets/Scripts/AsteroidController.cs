using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region PRIVATE VARIABLES
    private float timer;
    #endregion

    #region MONOBEHAVIOUR METHODS
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer+ Time.deltaTime;
        if(timer > 2f)
        {
            transform.Translate(Vector3.down * Constants.ASTEROID_SPEED* Time.deltaTime);
        }        
    }
    #endregion

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == Constants.ENEMY_01_SHIP_LAYER)
    //    {
    //        PoolManager.Instance.Recycle(Constants.ASTEROID_PREFAB, collision.gameObject);
    //    }
    //}
}
