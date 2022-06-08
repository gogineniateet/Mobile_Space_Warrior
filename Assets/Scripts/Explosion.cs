using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEnemy()); 
    }


    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
