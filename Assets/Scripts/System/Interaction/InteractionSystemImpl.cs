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
        // Wywo³aj zdarzenie interakcji z okreœlonym obiektem

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
