using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableTest : MonoBehaviour, InteractionSystem
{
    private bool isActivated = false;
    public Item item;


    public event System.Action<GameObject> OnInteraction;
    InventorySystemImpl inventorySystem = new InventorySystemImpl();
    public void Awake()
    {
    }
    
    public void TriggerInteraction(GameObject interactedObject)
    {
        if (!isActivated)
        {
            isActivated = true; //Sprawia �e triggera mo�na u�y� tylko raz

            Debug.Log("dziala"); //spradza czy dziala 

            // Aktywuj obiekt (lub wykonaj inn� logik�, je�li to potrzebne)
            gameObject.SetActive(true);

        }
        if (item != null)
        {
            inventorySystem.AddItem(item);
            gameObject.SetActive(false);
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