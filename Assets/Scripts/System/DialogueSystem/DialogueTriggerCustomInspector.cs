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
                trigger.item = (Item)EditorGUILayout.ObjectField("ItemToBeRemoved", trigger.item, typeof(Item), false);
            }

            EditorGUILayout.EndVertical();
        }

    }
}
