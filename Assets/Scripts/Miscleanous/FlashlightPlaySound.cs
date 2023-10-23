using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPlaySound : MonoBehaviour
{
    public AudioSource source;

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}
