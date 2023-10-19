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
            inventorySystem.AddItem(intarks.m_Item); // og�lnie dzia�a tylko nie wiem czemu item dodaj si� 2 razy gdzie� jest b��d pozdrawaiam
            Debug.Log("dziala");
        }
    }
}
