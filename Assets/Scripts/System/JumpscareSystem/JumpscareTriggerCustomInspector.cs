using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JumpscareTrigger))]
public class JumpscareTriggerCustomInspector : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        JumpscareTrigger trigger = (JumpscareTrigger)target;
        trigger.triggerType = (JumpscareTrigger.TriggerType)EditorGUILayout.EnumPopup("Selected Option", trigger.triggerType);

        if (trigger.triggerType == JumpscareTrigger.TriggerType.OnEvent)
        {
            EditorGUILayout.BeginVertical();
            trigger.eventType = (JumpscareTrigger.SupportedEvents)EditorGUILayout.EnumPopup("EventType", trigger.eventType);

            if(trigger.eventType == JumpscareTrigger.SupportedEvents.PickupItem)
            {
                trigger.item = (Item)EditorGUILayout.ObjectField("Item", trigger.item, typeof(Item), false);
            }

            if (trigger.eventType == JumpscareTrigger.SupportedEvents.DoorOpened)
            {
                trigger.door = (Door)EditorGUILayout.ObjectField("Door", trigger.door, typeof(Door), false);
            }

            EditorGUILayout.EndVertical();
        }

    }

}

