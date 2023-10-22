using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickup : MonoBehaviour, Interactable
{
    public bool TriggerOnlyOnce = true;
    private bool isActivated = false;
    public Item item;

    public bool ConditionalPick = false;
    public Item ItemToHave;

    public void TriggerInteraction(GameObject interactedObject)
    {
        if (isActivated && TriggerOnlyOnce) return;

        if(ConditionalPick)
        {
            if (InventorySystemImpl.Instance.HasItem(ItemToHave) == false)
                return;
        }

        isActivated = true;
        EventSystem.CallOnInteractionPickupItem(this, new EventArgsInteractionPickupItem { m_Item = item }); // Wywo³anie eventu
        //InventorySystemImpl.Instance.AddItem(item);
    }

}
