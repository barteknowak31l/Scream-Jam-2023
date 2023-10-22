using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntearctionDoor : MonoBehaviour, Interactable
{
    public Door door;
    bool isActivated = false;
    public bool isLockedOnKey = false;
    private bool unlocked;
    private void Start()
    {
        unlocked = !isLockedOnKey;
        EventSystem.DoorUnlocked += OnDoorUnlocked;
    }


    public void TriggerInteraction(GameObject interactedObject)
    {


        if (isActivated && unlocked) return;




        isActivated = true;
        EventSystem.CallOnInteractionDoor(this, new EventArgsInteractionDoor { m_Door = door }); // Wywo³anie eventu
    }

    public void OnDoorUnlocked(object sender, EventArgs args)
    {
        if (args is EventArgsDoorUnlocked dArgs)
        {
            if (door.doorID == dArgs.m_Door.doorID)
            {
                unlocked = true;
            }
        }
    }

}
