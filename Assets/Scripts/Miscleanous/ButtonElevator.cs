using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElevator : MonoBehaviour, Interactable
{

    public Item button;
    public Animator doorAnim;

    public AudioSource buttonSound;
    public AudioSource door;

    private bool opened = false;

    private void Start()
    {
        EventSystem.InteractionPickupItem += OpenDoor;
    }



    private void OpenDoor(object sender, EventArgs args)
    {
        if(args is EventArgsInteractionPickupItem iArgs)
        {
            if (button.itemID == iArgs.m_Item.itemID)
            {

                if (opened) return;

                doorAnim.Play("open");
                door.Play();
                opened = true;
            }
        }
    }


    public void CloseDoor()
    {
        doorAnim.Play("close");
        door.Play();

        EventSystem.InteractionPickupItem -= OpenDoor;

    }

    public void TriggerInteraction(GameObject interactedObject)
    {
        buttonSound.Play();
    }
}
