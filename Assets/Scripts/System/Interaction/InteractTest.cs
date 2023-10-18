using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableTest : MonoBehaviour, InteractionSystem
{
    private bool isActivated = false;

    public event System.Action<GameObject> OnInteraction;

    private void Awake()
    {
        // Subskrybuj zdarzenie interakcji w momencie uruchomienia obiektu
        OnInteraction += Interact;
    }

    public void TriggerInteraction(GameObject interactedObject)
    {
        if (!isActivated)
        {
            isActivated = false;

            // Wygeneruj losow¹ liczbê
            int randomValue = Random.Range(1, 101);

            // Wypisz losow¹ liczbê do konsoli
            Debug.Log("Losowa liczba: " + randomValue);

            // Aktywuj obiekt (lub wykonaj inn¹ logikê, jeœli to potrzebne)
            gameObject.SetActive(true);

            // Wywo³aj zdarzenie interakcji, przekazuj¹c ten obiekt
            OnInteraction?.Invoke(gameObject);
        }
    }

    private void Interact(GameObject interactedObject)
    {
        // Obs³uga interakcji
        Debug.Log("Interakcja z obiektem: " + interactedObject.name);
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