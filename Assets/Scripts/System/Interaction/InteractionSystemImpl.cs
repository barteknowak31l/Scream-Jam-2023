using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystemImpl : MonoBehaviour, InteractionSystem
{
    // Zmienilem na private bo to zawsze bedzie ustawione na kamere, wiec zrobie to w onAttach
    private Transform InteractorSource;
    
    public float InteractRange = 1; // dalem defaultowo 1

    public event Action<GameObject> OnInteraction;

    // Zdarzenie interakcji

    public void TriggerInteraction(GameObject interactedObject)
    {
        // Wywo�aj zdarzenie interakcji z okre�lonym obiektem

    }

    public void OnAttach()
    {
        // Dodaj logik� do obs�ugi do��czania do systemu interakcji (je�li potrzebne)
        Debug.Log(this.GetType() + "OnAttach");

        // To zadziala, bo jest tylko 1 kamera
        InteractorSource = GameObject.FindAnyObjectByType<Camera>().transform; 

    }

    public void OnDetach()
    {
        // Dodaj logik� do obs�ugi od��czania od systemu interakcji (je�li potrzebne)
        Debug.Log(this.GetType() + "OnDetach");

    }

    private void OnEnable()
    {
        CustomSystemImpl.Instance.Attach(this);
    }

    private void OnDisable()
    {
        CustomSystemImpl.Instance.Detach(this);

    }

    private void OnDestroy()
    {
        CustomSystemImpl.Instance.Detach(this);

    }


    public void OnUpdate()
    {
        CheckInteraction();
    }

    public void CheckInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObj))
                {
                    interactObj.TriggerInteraction(hitInfo.collider.gameObject);
                }
            }
        }
    }
}
