using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemImpl : MonoBehaviour, InventorySystem
{
    public void OnAttach()
    {
        Debug.Log(this.GetType() + " OnAttach");


        EventSystem.DialogueStart += OnDialogueStart;
        EventSystem.DialogueNext += OnDialogueNext;
        EventSystem.DialogueEnd += OnDialogueEnd;
    }


    public void OnDetach()
    {
        Debug.Log(this.GetType() + " OnDetach");


        EventSystem.DialogueStart -= OnDialogueStart;
        EventSystem.DialogueNext -= OnDialogueNext;
        EventSystem.DialogueEnd -= OnDialogueEnd;
    }

    public void OnDialogueStart(object sender, EventArgs args)
    {
        if(args is EventArgsDialogueStart dialogueArgs)
        {
            Debug.Log(this.GetType() + ": OnDialogueStart Event: dialogue id: " + dialogueArgs.m_DialogueID);
        }

    }

    public void OnDialogueNext(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueNext dialogueArgs)
        {
            Debug.Log(this.GetType() + ": OnDialogueNext Event: dialogue id: " + dialogueArgs.m_DialogueID + ", dialogue line: " + dialogueArgs.m_CurrentLine);
        }
    }

    public void OnDialogueEnd(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueEnd dialogueArgs)
        {
            Debug.Log(this.GetType() + ": OnDialogueEnd Event: dialogue id: " + dialogueArgs.m_DialogueID);
        }
    }



    public void OnUpdate()
    {
       
    }


    void OnEnable()
    {
        CustomSystemImpl.Instance.Attach(this);
    }

    void OnDisable()
    {
        CustomSystemImpl.Instance.Detach(this);
    }

    void OnDestroy()
    {
        CustomSystemImpl.Instance.Detach(this);
    }
}
