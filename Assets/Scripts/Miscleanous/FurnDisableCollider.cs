using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnDisableCollider : MonoBehaviour
{
    public Collider collider;
    public Dialogue disableAfterThis;

    public Dialogue showKeyAfterThis;
    public GameObject key;

    public Item KeyInFurnanceItem;

    private void Start()
    {
        EventSystem.DialogueEnd += DisableCollider;
        EventSystem.DialogueStart += ShowKey;
    }

    public void DisableCollider(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueEnd dArgs)
        {
            if (disableAfterThis.m_Id == dArgs.m_DialogueID)
            {
                collider.enabled = false;
            }
        }
    }

    public void ShowKey(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueStart dArgs)
        {
            if (showKeyAfterThis.m_Id == dArgs.m_DialogueID)
            {
                key.SetActive(true);
                InventorySystemImpl.Instance.AddItem(KeyInFurnanceItem);
            }
        }
    }


}
