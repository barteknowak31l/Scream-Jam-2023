using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Jumpscare", menuName = "Jumpscare")]
public class Jumpscare : ScriptableObject
{
    public string m_Name;
    public GameObject m_Model;
    public AudioClip m_Scream;
    public float m_Duration;
    public Animation m_Animation;

}
