using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Transistor : MonoBehaviour
{
    public LevelTransition t;
    public AudioSource source;

    void Start()
    {

        EventSystem.JumpscareEnded += OnJumpScareEnded;
        
    }

    public void OnJumpScareEnded(object sender, EventArgs args)
    {
        EventSystem.JumpscareEnded -= OnJumpScareEnded;

        t.Transition();
        source.Play();
    }

}
