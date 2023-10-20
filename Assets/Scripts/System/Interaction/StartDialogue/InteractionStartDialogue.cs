using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionStartDialogue : MonoBehaviour, Interactable
{
    public Dialogue dialogue;
    private bool isActivated = false;

    public void TriggerInteraction(GameObject interactedObject)
    {
        if (!isActivated)
        {
            isActivated = true;
            EventSystem.CallDialogueStart(this, new EventArgsDialogueStart { m_DialogueID = dialogue.m_Id }); // Wywo³anie eventu
        }
    }
}
