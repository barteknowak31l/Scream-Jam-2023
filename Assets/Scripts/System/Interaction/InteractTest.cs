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

            // Wygeneruj losow� liczb�
            int randomValue = Random.Range(1, 101);

            // Wypisz losow� liczb� do konsoli
            Debug.Log("Losowa liczba: " + randomValue);

            // Aktywuj obiekt (lub wykonaj inn� logik�, je�li to potrzebne)
            gameObject.SetActive(true);

            // Wywo�aj zdarzenie interakcji, przekazuj�c ten obiekt
            OnInteraction?.Invoke(gameObject);
        }
    }

    private void Interact(GameObject interactedObject)
    {
        // Obs�uga interakcji
        Debug.Log("Interakcja z obiektem: " + interactedObject.name);
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