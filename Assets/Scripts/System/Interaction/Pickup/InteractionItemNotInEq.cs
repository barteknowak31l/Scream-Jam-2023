using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItemNotInEq : MonoBehaviour, Interactable
{
    public bool TriggerOnlyOnce = true;
    private bool isActivated = false;

    [SerializeField]
    public Item item;

    public void TriggerInteraction(GameObject interactedObject)
    {
        if (isActivated && TriggerOnlyOnce) return;

        isActivated = true;
        if(!InventorySystemImpl.Instance.HasItem(item))
        EventSystem.CallInventoryItemNotInEq(this, new EventArgsInventoryItemNotInEq { m_ItemID = item.itemID}); // Wywo³anie eventu

    }
}
