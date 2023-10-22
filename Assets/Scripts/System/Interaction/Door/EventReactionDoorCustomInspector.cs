using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventReactionDoor))]
public class EventReactionDoorCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EventReactionDoor trigger = (EventReactionDoor)target;

        if (trigger.options.Contains(EventReactionDoor.EventReactionDoorOptions.OpenIfKeyInEq))
        {
           //trigger.key = (Item)EditorGUILayout.ObjectField("Key", trigger.key, typeof(Item), false);
        }

        if (trigger.options.Contains(EventReactionDoor.EventReactionDoorOptions.OpenOnDialogEnd))
        {
            trigger.dialog = (Dialogue)EditorGUILayout.ObjectField("Dialog", trigger.dialog, typeof(Dialogue), false);
        }

    }
}
