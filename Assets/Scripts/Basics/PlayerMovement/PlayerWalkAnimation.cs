using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("Walk", IsMoving());
    }


    private bool IsMoving()
    {
        if(Input.GetKey(KeyCode.W))
        {
            return true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            return true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            return true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            return true;
        }



        return false;
    }

}
