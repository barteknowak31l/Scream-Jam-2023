using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    new Light light;
    Animator animator;

    public FlashlightPlaySound sound;

    public KeyCode flashlightKey = KeyCode.F;
    public KeyCode flickeringTrigger = KeyCode.U;

    public float randomTimeBase = 40.0f;
    public float randomOffset = 15.0f;

    public bool enableFlickering = true;

    void Start()
    {
        light = GetComponent<Light>();
        animator = GetComponent<Animator>();

        if (enableFlickering) ;
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
            if(enableFlickering)
            {
                animator.SetTrigger("StartFlickering");
                Invoke("StopFlickering", 4);
            }



        }
    }

    public void DisableFlickering()
    {
        StopAllCoroutines();
        animator.SetTrigger("StopFlickering");
        sound.Stop();


    }

}
