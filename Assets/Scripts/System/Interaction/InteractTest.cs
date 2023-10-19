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
            isActivated = true; //Sprawia ¿e triggera mo¿na u¿yæ tylko raz

            Debug.Log("dziala"); //spradza czy dziala 

            // Aktywuj obiekt (lub wykonaj inn¹ logikê, jeœli to potrzebne)
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