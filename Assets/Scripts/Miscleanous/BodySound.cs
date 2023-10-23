using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySound : MonoBehaviour
{
    public AudioSource source;
    public Dialogue dialogue;

    private void Start()
    {
        EventSystem.DialogueStart += OnDialogueStart;
    }

    public void OnDialogueStart(object sender, EventArgs args)
    {
        if(args is EventArgsDialogueStart dArgs)
        {
            if(dArgs.m_DialogueID == dialogue.m_Id)
            {
                source.Play();
            }
        }
    }
}
