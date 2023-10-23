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
        None, DialogueStart,RemoveItem,PickItem,DoorOpened, ItemNotInEq
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
    public Item itemNotInEq;

    [HideInInspector]
    public Door door;

    public Dialogue dialogue;

    public bool isDialog = false;
    public int lineNumber = 0;
    private void skipDialog()
    {
        if(lineNumber + 1 <= dialogue.m_Lines.Count)
        {
            StopAllCoroutines();
            lineNumber++;
            StartCoroutine(DialogueSkippedCoroutine());
        }
        else
        {
            lineNumber = -1;
            isDialog = false;
            EventSystem.CallDialogueEnd(this, new EventArgsDialogueEnd { m_DialogueID = dialogue.m_Id });
            FindObjectOfType<DialogueCanvas>().Canvas("", dialogue.color);
        }
    }


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
        isDialog = true;
        lineNumber = -1;
        hasBeenTriggeded = true;
        foreach (string lineOfDialogues in dialogue.m_Lines)
        {
            EventSystem.CallDialogueNext(this, new EventArgsDialogueNext { m_DialogueID = dialogue.m_Id, m_CurrentLine  = dialogue.m_CurrentLine  });
            FindObjectOfType<DialogueCanvas>().Canvas(lineOfDialogues, dialogue.color);
            lineNumber++;
            yield return new WaitForSeconds(dialogue.duration);

        }
        
        EventSystem.CallDialogueEnd(this, new EventArgsDialogueEnd { m_DialogueID = dialogue.m_Id });
        isDialog = false;


        FindObjectOfType<DialogueCanvas>().Canvas("", dialogue.color);


    }

    IEnumerator DialogueSkippedCoroutine()
    {

        for(int i = lineNumber; i < dialogue.m_Lines.Count; i++)
        {

            EventSystem.CallDialogueNext(this, new EventArgsDialogueNext { m_DialogueID = dialogue.m_Id, m_CurrentLine = dialogue.m_CurrentLine });

            string line = dialogue.m_Lines[i];
            FindObjectOfType<DialogueCanvas>().Canvas(line, dialogue.color);
            yield return new WaitForSeconds(dialogue.duration);
            lineNumber++;


        }
        EventSystem.CallDialogueEnd(this, new EventArgsDialogueEnd { m_DialogueID = dialogue.m_Id });
        isDialog = false;


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
                        if (dArgs.m_Door.doorID == door.doorID)
                            StartDialogueCoroutine();
                    }
                    break;
                }
            case SupportedEvents.ItemNotInEq:
                {

                    if (args is EventArgsInventoryItemNotInEq iArgs)
                    {
                        if (iArgs.m_ItemID == itemNotInEq.itemID)
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
            case SupportedEvents.ItemNotInEq:
                {

                    EventSystem.InventoryItemNotInEq += OnEvent;
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
            case SupportedEvents.ItemNotInEq:
                {

                    EventSystem.InventoryItemNotInEq -= OnEvent;
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



    // KEYPAD TRIGGER
    private int errors = 0;
    private bool triggeredKeypadErrorMessage = false;

    private void Update()
    {
        if(errors == 1 && triggeredKeypadErrorMessage == false)
        {
            triggeredKeypadErrorMessage = true;
            StartDialogueCoroutine();
        }

        if(isDialog && Input.GetKeyDown(KeyCode.Space))
        {
            skipDialog();
        }


    }

    public void ReportError()
    {
        errors = 1;
    }


}
