using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabBlockade : MonoBehaviour
{
    public Item itemNeeded;
    public GameObject blockade;
    public Dialogue trigger;

    public bool openOnDialogEnd = false;
    public Dialogue dialogEnd;

    private void Start()
    {
        EventSystem.DialogueStart += EnableBlockade;

        if(openOnDialogEnd)
        {
            EventSystem.DialogueEnd += DisableBlockadeDialogEnd;
        }
        else
        {
            EventSystem.InteractionPickupItem += DisableBlockade;
        }

    }

    public void EnableBlockade(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueStart iArgs)
        {
            if (iArgs.m_DialogueID != trigger.m_Id) return;
            blockade.SetActive(true);
        
        }
    }

    public void DisableBlockade(object sender, EventArgs args)
    {
        if(args is EventArgsInteractionPickupItem iArgs)
        {
            if(iArgs.m_Item.itemID == itemNeeded.itemID)
            {
                blockade.SetActive(false);
            }
        }
    }

    public void DisableBlockadeDialogEnd(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueEnd dArgs)
        {
            if (dArgs.m_DialogueID == dialogEnd.m_Id)
            {
                blockade.SetActive(false);
            }
        }
    }

}
