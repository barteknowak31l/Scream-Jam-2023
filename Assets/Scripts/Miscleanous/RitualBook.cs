using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualBook : MonoBehaviour, Interactable
{

    public LightCandle c1;
    public LightCandle c2;
    public LightCandle c3;
    public LightCandle c4;
    public LightCandle c5;

    private bool interactive = false;

    public GameObject endScreen;
    public Dialogue dialogue;

    public Item EndKey;

    public AudioSource devilLaugh;

    public void TriggerInteraction(GameObject interactedObject)
    {
        if (!interactive) return;

        endScreen.SetActive(true);
        devilLaugh.Play();
        EventSystem.CallDialogueStart(this, new EventArgsDialogueStart { m_DialogueID = dialogue.m_Id });
        InventorySystemImpl.Instance.AddItem(EndKey);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (c1.isLit && c2.isLit && c3.isLit && c4.isLit && c5.isLit)
        {
            interactive = true;
        }
    }
}
