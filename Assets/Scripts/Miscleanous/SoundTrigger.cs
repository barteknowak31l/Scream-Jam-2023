using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource source;
    public bool playOnce = true;
    private bool played = false;


    private void OnTriggerEnter(Collider other)
    {

        if (played && playOnce) return;
        played = true;
        source.Play();

    }


}
