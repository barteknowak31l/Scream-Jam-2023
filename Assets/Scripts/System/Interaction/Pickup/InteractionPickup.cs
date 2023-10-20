using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickup : MonoBehaviour, Interactable
{

    private bool isActivated = false;
    public Item item;

    public void TriggerInteraction(GameObject interactedObject)
    {
        if (!isActivated)
        {
            Debug.Log("Event sie calluje id:" + item.itemID);

            isActivated = true;
            EventSystem.CallOnInteractionPickupItem(this, new EventArgsInteractionPickupItem { m_Item = item }); // Wywo³anie eventu
            Debug.Log("Event sie calluje 2");
        }
    }

}
