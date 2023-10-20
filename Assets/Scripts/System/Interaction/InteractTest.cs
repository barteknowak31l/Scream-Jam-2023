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
            EventSystem.CallOnInteractionPickupItem(this, new EventArgsInteractionPickupItem { m_Item = item }); // Wywo�anie eventu
            gameObject.SetActive(false); //usuwanie obiektu 
        }
    }
    public void OnAttach()
    {
        // Dodaj logik� do obs�ugi do��czania do systemu interakcji (je�li potrzebne)
    }

    public void OnDetach()
    {
        // Dodaj logik� do obs�ugi od��czania od systemu interakcji (je�li potrzebne)
    }

    public void OnUpdate()
    {
        // Dodaj logik� aktualizacji systemu interakcji (je�li potrzebne)
    }
}