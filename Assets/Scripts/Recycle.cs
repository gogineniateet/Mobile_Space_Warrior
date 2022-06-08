using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Triggered : " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            PoolManager.Instance.Recycle(Constants.PLAYER_BULLET_PREFAB, this.gameObject);
        }
    }
}
