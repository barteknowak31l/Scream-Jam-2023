using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, EventReaction
{
    public enum TriggerType
    {
        OnTriggerEnter, OnEvent
    }

    public enum SupportedEvents
    {
        None, DialogueStart,RemoveItem,PickItem,DoorOpened
    }

    public string m_Name;
    public bool TriggerOnlyOnce = true;
    private bool hasBeenTriggeded = false;
    [HideInInspector]
    public TriggerType triggerType = TriggerType.OnTriggerEnter;

    [HideInInspector]
    public SupportedEvents eventType = SupportedEvents.None;

    [HideInInspector]
    public Item itemToRemove;

    [HideInInspector]
    public Item itemToPick;

    [HideInInspector]
    public Door door;

    public Dialogue dialogue;
 
    private void Start()
    {
        SubscribeToEvent();

    }
    private void OnEnable()
    {
        SubscribeToEvent();

    }
    private void OnDestroy()
    {
        UnsubscribeFromEvent();

    }
    private void OnDisable()
    {
        UnsubscribeFromEvent();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (triggerType != TriggerType.OnTriggerEnter) return;



        StartDialogueCoroutine();


    }

    public void OnDialogueStart(object sender, EventArgs args)
    {
        if(args is EventArgsDialogueStart jumpArgs)
        {
            if(jumpArgs.m_DialogueID != dialogue.m_Id)
            StopAllCoroutines();

        }
    }

    IEnumerator DialogueCoroutine()
    {

        EventSystem.CallDialogueStart(this, new EventArgsDialogueStart { m_DialogueID = dialogue.m_Id });
        hasBeenTriggeded = true;
        foreach (string lineOfDialogues in dialogue.m_Lines)
        {

            EventSystem.CallDialogueNext(this, new EventArgsDialogueNext { m_DialogueID = dialogue.m_Id, m_CurrentLine  = dialogue.m_CurrentLine  });

            FindObjectOfType<DialogueCanvas>().Canvas(lineOfDialogues, dialogue.color);
            yield return new WaitForSeconds(dialogue.duration);

        }
        
        EventSystem.CallDialogueEnd(this, new EventArgsDialogueEnd { m_DialogueID = dialogue.m_Id });


        FindObjectOfType<DialogueCanvas>().Canvas("", dialogue.color);


    }

    public void OnEvent(object sender, EventArgs args)
    {
        switch (eventType)
        {
            case SupportedEvents.None:
                {
                    break;
                }
            case SupportedEvents.DialogueStart:
                {

                    if (args is EventArgsInteractionTriggerDialogue dialogueArgs)
                    {
                        if(dialogueArgs.m_DialogueID == dialogue.m_Id)
                            StartDialogueCoroutine();
                    }
                    break;
                }
            case SupportedEvents.RemoveItem:
                {

                    if (args is EventArgsInventoryItemRemove iArgs)
                    {
                        if (iArgs.m_ItemID == itemToRemove.itemID)
                            StartDialogueCoroutine();
                    }
                    break;
                }
            case SupportedEvents.PickItem:
                {

                    if (args is EventArgsInventoryItemAdd iArgs)
                    {
                        if (iArgs.m_ItemID == itemToPick.itemID)
                            StartDialogueCoroutine();
                    }
                    break;
                }

            case SupportedEvents.DoorOpened:
                {

                    if (args is EventArgsDoorUnlocked dArgs)
                    {
                        if (dArgs.m_Door.doorID == door.doorID)
                            StartDialogueCoroutine();
                    }
                    break;
                }
        }
    }

    public void SubscribeToEvent()
    {

        EventSystem.DialogueStart += OnDialogueStart;


        if (triggerType != TriggerType.OnEvent) return;

        switch (eventType)
        {
            case SupportedEvents.None:
                {
                    break;
                }
            case SupportedEvents.DialogueStart:
                {
                    EventSystem.InteractionTriggerDialogue += OnEvent;
                    break;
                }
            case SupportedEvents.RemoveItem:
                {

                    EventSystem.InventoryItemRemove += OnEvent;
                    break;
                }
            case SupportedEvents.PickItem:
                {

                    EventSystem.InventoryItemAdd += OnEvent;
                    break;
                }
            case SupportedEvents.DoorOpened:
                {

                    EventSystem.DoorUnlocked += OnEvent;
                    break;
                }
        }
    }

    public void UnsubscribeFromEvent()
    {
        EventSystem.DialogueStart -= OnDialogueStart;


        if (triggerType != TriggerType.OnEvent) return;

        switch (eventType)
        {
            case SupportedEvents.None:
                {
                    break;
                }
            case SupportedEvents.DialogueStart:
                {
                    EventSystem.InteractionTriggerDialogue -= OnEvent;
                    break;
                }
            case SupportedEvents.RemoveItem:
                {

                    EventSystem.InventoryItemRemove -= OnEvent;
                    break;
                }
            case SupportedEvents.PickItem:
                {

                    EventSystem.InventoryItemAdd -= OnEvent;
                    break;
                }
            case SupportedEvents.DoorOpened:
                {

                    EventSystem.DoorUnlocked -= OnEvent;
                    break;
                }
        }
    }


    private void OnValidate()
    {
        if (triggerType == TriggerType.OnTriggerEnter)
        {
            Collider myCollider = GetComponent<Collider>();

            if (myCollider == null)
            {
                Debug.LogError("DialogueTrigger " + m_Name + " nie ma aktywnego Collider'a!");
            }
        }
    }

    private void StartDialogueCoroutine()
    {
        if (TriggerOnlyOnce && hasBeenTriggeded) return;
        StartCoroutine(DialogueCoroutine());
    }
}
