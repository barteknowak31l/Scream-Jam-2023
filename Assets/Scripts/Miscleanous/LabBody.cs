using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabBody : MonoBehaviour, Interactable
{
    public bool isEmpty;
    public Dialogue dialogue;
    public Item item;

    public void TriggerInteraction(GameObject interactedObject)
    {

        if(isEmpty)
        {
            EventSystem.CallDialogueStart(this, new EventArgsDialogueStart { m_DialogueID = dialogue.m_Id });
        }
        else
        {
            EventSystem.CallDialogueStart(this, new EventArgsDialogueStart { m_DialogueID = dialogue.m_Id });

            EventSystem.CallOnInteractionPickupItem(this, new EventArgsInteractionPickupItem { m_Item = item });
            Destroy(this);
        }


    }
}
