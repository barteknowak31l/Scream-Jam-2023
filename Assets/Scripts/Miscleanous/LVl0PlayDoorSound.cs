using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVl0PlayDoorSound : MonoBehaviour
{

    public AudioSource doorSource;

    public void PlayDoor()
    {
        doorSource.Play();
    }

}
