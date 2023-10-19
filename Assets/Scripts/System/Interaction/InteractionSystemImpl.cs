using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystemImpl : MonoBehaviour, InteractionSystem
{
    public Transform InteractorSource;
    public float InteractRange;

    public event Action<GameObject> OnInteraction;

    // Zdarzenie interakcji

    public void TriggerInteraction(GameObject interactedObject)
    {
        // Wywo�aj zdarzenie interakcji z okre�lonym obiektem

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

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out InteractionSystem interactObj))
                {
                    interactObj.TriggerInteraction(hitInfo.collider.gameObject);
                }
            }
        }
    }
}
