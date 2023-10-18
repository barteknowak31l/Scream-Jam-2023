using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {

        EventSystem.CallDialogueStart(this, new EventArgsDialogueStart { m_DialogueID = dialogue.m_Id });

        StartCoroutine(DialogueCoroutine());


    }

    public void OnJumpscareTriggered(object sender, EventArgs args)
    {

     //   if(args is )
    }

    IEnumerator DialogueCoroutine()
    {
        foreach (string lineOfDialogues in dialogue.m_Lines)
        {

            EventSystem.CallDialogueNext(this, new EventArgsDialogueNext { m_DialogueID = dialogue.m_Id, m_CurrentLine  = dialogue.m_CurrentLine  });

            FindObjectOfType<DialogueCanvas>().Canvas(lineOfDialogues);
            yield return new WaitForSeconds(dialogue.duration);

        }
        
        EventSystem.CallDialogueEnd(this, new EventArgsDialogueEnd { m_DialogueID = dialogue.m_Id });


        FindObjectOfType<DialogueCanvas>().Canvas(null);


    }



}
