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
            isActivated = true; //Sprawia ¿e triggera mo¿na u¿yæ tylko raz

            Debug.Log("dziala"); //spradza czy dziala 

            // Aktywuj obiekt (lub wykonaj inn¹ logikê, jeœli to potrzebne)
            gameObject.SetActive(true);

            // Wywo³aj zdarzenie interakcji, przekazuj¹c ten obiekt
            OnInteraction?.Invoke(gameObject);
        }
    }

    private void Interact(GameObject interactedObject)
    {
        Debug.Log("log");
        // Obs³uga interakcji
        myDoor.Play(animationName, 0, 0.0f);
        gameObject.SetActive(false);
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