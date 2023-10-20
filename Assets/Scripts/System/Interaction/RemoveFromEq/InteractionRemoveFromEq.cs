using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRemoveFromEq : MonoBehaviour, Interactable
{

    public Item item;
    private bool isActivated = false;
    public bool TriggerOnlyOnce = false;

    public void TriggerInteraction(GameObject interactedObject)
    {
        if(TriggerOnlyOnce)
        {
            if (!isActivated)
            {
                isActivated = true;
                InventorySystemImpl.Instance.RemoveItem(item.itemID);
            }
        }
        else
        {
            isActivated = true;
            InventorySystemImpl.Instance.RemoveItem(item.itemID);
        }


    }
}
