using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractionStartDialogue))]
public class InteractionStartDialogueCustomInspector : Editor
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        InteractionStartDialogue trigger = (InteractionStartDialogue)target;

        if (trigger.ConditionalDialogue)
        {
            EditorGUILayout.BeginVertical();
            trigger.condition = (InteractionStartDialogue.Condition)EditorGUILayout.EnumPopup("Condition", trigger.condition);

            EditorGUILayout.EndVertical();
        }

    }
}
