using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Jumpscare", menuName = "Jumpscare")]
public class Jumpscare : ScriptableObject
{
    public string name;
    public GameObject model;
    public AudioClip scream;
    public float duration;
    public Animation animation;
    public Vector3 offset;

}
