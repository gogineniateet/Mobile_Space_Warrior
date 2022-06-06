using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("TurnLeft", true);
            anim.SetBool("TurnRight", true);

        }

        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("TurnLeft", false);
            anim.SetBool("TurnRight", false);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("TurnLeft", true);
            anim.SetBool("TurnRight", true);

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("TurnLeft", false);
            anim.SetBool("TurnRight", false);

        }
    }
}
