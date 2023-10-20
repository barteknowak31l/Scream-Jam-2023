using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionStartDialogue : MonoBehaviour, Interactable
{
    public Dialogue dialogue;
    public bool triggerOnce = true;
    private bool isActivated = false;

    public void TriggerInteraction(GameObject interactedObject)
    {

        if (isActivated && triggerOnce) return;

        isActivated = true;
        EventSystem.CallOnInteractionTriggerDialogue(this, new EventArgsInteractionTriggerDialogue { m_DialogueID = dialogue.m_Id }); // Wywo³anie eventu
    }
}
