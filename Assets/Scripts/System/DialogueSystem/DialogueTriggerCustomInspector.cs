using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueTrigger))]

public class DialogueTriggerCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DialogueTrigger trigger = (DialogueTrigger)target;
        trigger.triggerType = (DialogueTrigger.TriggerType)EditorGUILayout.EnumPopup("Selected Option", trigger.triggerType);

        if (trigger.triggerType == DialogueTrigger.TriggerType.OnEvent)
        {
            EditorGUILayout.BeginVertical();
            trigger.eventType = (DialogueTrigger.SupportedEvents)EditorGUILayout.EnumPopup("EventType", trigger.eventType);

            if (trigger.eventType == DialogueTrigger.SupportedEvents.RemoveItem)
            {
                trigger.itemToRemove = (Item)EditorGUILayout.ObjectField("ItemToBeRemoved", trigger.itemToRemove, typeof(Item), false);
            }

            if (trigger.eventType == DialogueTrigger.SupportedEvents.PickItem)
            {
                trigger.itemToPick = (Item)EditorGUILayout.ObjectField("ItemToBePicked", trigger.itemToPick, typeof(Item), false);
            }

            EditorGUILayout.EndVertical();
        }

    }
}
