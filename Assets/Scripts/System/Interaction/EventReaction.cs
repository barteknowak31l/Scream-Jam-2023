using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReaction : MonoBehaviour
{
    public InventorySystemImpl inventorySystem;//  = new InventorySystemImpl();

    private void OnDisable()
    {
        EventSystem.Interaction -= OnInteractionEvent;
    }
    private void OnDestroy()
    {
        EventSystem.Interaction -= OnInteractionEvent;
    }
    private void OnEnable()
    { 
        EventSystem.Interaction += OnInteractionEvent;
    }
    private void OnInteractionEvent(object sender, EventArgs args)
    {
        if (args is EventArgsInteraction intarks)
        {
            inventorySystem.AddItem(intarks.m_Item); // ogólnie dzia³a tylko nie wiem czemu item dodaj siê 2 razy gdzieœ jest b³¹d pozdrawaiam
            Debug.Log("dziala");
        }
    }
}
