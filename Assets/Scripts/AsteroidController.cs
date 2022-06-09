using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region PRIVATE VARIABLES
    private float timer;
    #endregion

    #region MONOBEHAVIOUR METHODS

    // Update is called once per frame
    void Update()
    {
        timer = timer+ Time.deltaTime;
        if(timer > 2f)
        {
            transform.Translate(Vector3.down * Constants.ASTEROID_SPEED* Time.deltaTime);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided Bullet : " + collision.gameObject.layer);

        if (collision.gameObject.layer == Constants.PLAYER_SHIP_LAYER)
        {
            collision.gameObject.GetComponent<PlayerController>().LostLife(1);
            PoolManager.Instance.Recycle(Constants.ASTEROID_PREFAB, this.gameObject);
        }
    }
    #endregion

}
