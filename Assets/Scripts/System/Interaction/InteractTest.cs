using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableTest : MonoBehaviour, Interactable
{
    private bool isActivated = false;
    public Item item;


   // public event System.Action<GameObject> OnInteraction;
    //InventorySystemImpl inventorySystem = new InventorySystemImpl();
    public void Awake()
    {

    }

    public void TriggerInteraction(GameObject interactedObject)
    {
        Debug.Log("test");
        if (!isActivated)
        {
            Debug.Log("test2");
            isActivated = true;
            EventSystem.CallOnInteractionPickupItem(this, new EventArgsInteractionPickupItem { m_Item = item }); // Wywo³anie eventu
            gameObject.SetActive(false); //usuwanie obiektu 
        }
    }
    public void OnAttach()
    {
        // Dodaj logikê do obs³ugi do³¹czania do systemu interakcji (jeœli potrzebne)
    }

    public void OnDetach()
    {
        // Dodaj logikê do obs³ugi od³¹czania od systemu interakcji (jeœli potrzebne)
    }

    public void OnUpdate()
    {
        // Dodaj logikê aktualizacji systemu interakcji (jeœli potrzebne)
    }
}