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

    public float randomTimeBase = 40.0f;
    public float randomOffset = 15.0f;


    void Start()
    {
        light = GetComponent<Light>();
        animator = GetComponent<Animator>();
        StartCoroutine(LightCycle());

    }
    void Update()
    {
/*        if (Input.GetKeyDown(flashlightKey))
        {
            animator.SetTrigger("Enable");
        }else if (Input.GetKeyDown(flickeringTrigger))
            {
            animator.SetTrigger("StartFlickering");
            Invoke("StopFlickering", 4);
            }*/
    }
    void StopFlickering()
    {
        animator.SetTrigger("StopFlickering");
    }

    IEnumerator LightCycle()
    {
        float randTime = 0.0f;
        while(true)
        {
            randTime = randomTimeBase + Random.Range(-randomOffset, randomOffset);

            yield return new WaitForSeconds(randTime);
            animator.SetTrigger("StartFlickering");
            Invoke("StopFlickering", 4);



        }
    }

}
