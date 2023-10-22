using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private Animator anim;
    public Dialogue dialog;

    private void Start()
    {
        anim = GetComponent<Animator>();
        EventSystem.DialogueEnd += OnDialogEnd;

    }

    public void OnDialogEnd(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueEnd dArgs)
        {
            if (dArgs.m_DialogueID == dialog.m_Id)
            {
                anim.Play("credits");
            }
        }
    }


}
