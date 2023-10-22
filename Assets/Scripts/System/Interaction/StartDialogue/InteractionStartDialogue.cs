using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionStartDialogue : MonoBehaviour, Interactable
{
    public enum Condition
    {
        ItemInEq,None
    }


    public Dialogue dialogue;

    public bool triggerConditional;
    public Condition condition;
    public Dialogue ConditionalDialogue;
    public List<Item> ItemToHave;

    public bool triggerOnce = true;
    private bool isActivated = false;

    public void TriggerInteraction(GameObject interactedObject)
    {


        if(triggerConditional)
        {
            switch (condition)
            {
                case Condition.ItemInEq:
                {
                    foreach(Item i in ItemToHave)
                        {
                            if(InventorySystemImpl.Instance.items.Contains(i))
                            {
                                if (isActivated && triggerOnce) return;

                                isActivated = true;
                                EventSystem.CallOnInteractionTriggerDialogue(this, new EventArgsInteractionTriggerDialogue { m_DialogueID = ConditionalDialogue.m_Id }); // Wywo³anie eventu
                                return;
                            }
                        }
                        // else
                        EventSystem.CallOnInteractionTriggerDialogue(this, new EventArgsInteractionTriggerDialogue { m_DialogueID = dialogue.m_Id }); // Wywo³anie eventu



                        break;
                }
            }
            
        }
        else
        {
            isActivated = true;
            EventSystem.CallOnInteractionTriggerDialogue(this, new EventArgsInteractionTriggerDialogue { m_DialogueID = dialogue.m_Id }); // Wywo³anie eventu
        }

    }
}
