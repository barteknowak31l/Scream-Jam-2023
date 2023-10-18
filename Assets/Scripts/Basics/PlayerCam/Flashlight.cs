using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    new Light light;
    Animator animator;


    public KeyCode flashlightKey = KeyCode.F;
    public KeyCode flickeringTrigger = KeyCode.U;
    void Start()
    {
        light = GetComponent<Light>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(flashlightKey))
        {
            animator.SetTrigger("Enable");
        }else if (Input.GetKeyDown(flickeringTrigger))
            {
            animator.SetTrigger("StartFlickering");
            Invoke("StopFlickering", 4);
            }
    }
    void StopFlickering()
    {
        animator.SetTrigger("StopFlickering");
    }
}
