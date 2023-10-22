using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableColliderOnDialogEnd : MonoBehaviour
{
    public Dialogue dialog;
    public Collider col;

    private void Start()
    {
        EventSystem.DialogueEnd += OnDialogEnd;
    }

    public void OnDialogEnd(object sender, EventArgs args)
    {
        Debug.Log(gameObject);

        if (args is EventArgsDialogueEnd dArgs)
        {
            if(dialog.m_Id == dArgs.m_DialogueID)
            {
                Debug.Log(gameObject);
                col.enabled = true;
                EventSystem.DialogueEnd -= OnDialogEnd;
            }
        }
    }
}
