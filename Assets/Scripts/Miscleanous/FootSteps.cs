using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioClip footstepSound;
    private AudioSource audioSource;
    private bool isMoving;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = footstepSound;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
