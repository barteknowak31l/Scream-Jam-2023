using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntearctionDoor : MonoBehaviour, Interactable
{
    public Door door;
    bool isActivated = false;
    public void TriggerInteraction(GameObject interactedObject)
    {
        if (!isActivated)
        {
            Debug.Log("Event sie calluje id:" + door.doorID);

            isActivated = true;
            EventSystem.CallOnInteractionDoor(this, new EventArgsInteractionDoor { m_Door = door }); // Wywo³anie eventu
            Debug.Log("Event sie calluje 2");
        }
    }
}
