using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableTest : MonoBehaviour, InteractionSystem
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private string animationName;
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
            isActivated = true; //Sprawia �e triggera mo�na u�y� tylko raz

            Debug.Log("dziala"); //spradza czy dziala 

            // Aktywuj obiekt (lub wykonaj inn� logik�, je�li to potrzebne)
            gameObject.SetActive(true);

            // Wywo�aj zdarzenie interakcji, przekazuj�c ten obiekt
            OnInteraction?.Invoke(gameObject);
        }
    }

    private void Interact(GameObject interactedObject)
    {
        Debug.Log("log");
        // Obs�uga interakcji
        myDoor.Play(animationName, 0, 0.0f);
        gameObject.SetActive(false);
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