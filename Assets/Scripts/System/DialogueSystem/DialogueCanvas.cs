using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueCanvas : MonoBehaviour
{

   public GameObject panel;
   public TMP_Text text;

   public void Canvas(string tekst, Color color)
    {

        text.text = tekst;
        text.color = color;
    }


    private void OnEnable()
    {
        EventSystem.DialogueEnd += OnDialogueEnd;
        EventSystem.DialogueStart += OnDialogueStart;
    }

    private void OnDisable()
    {
        EventSystem.DialogueEnd -= OnDialogueEnd;
        EventSystem.DialogueStart -= OnDialogueStart;


    }

    private void OnDestroy()
    {
        EventSystem.DialogueEnd -= OnDialogueEnd;
        EventSystem.DialogueStart -= OnDialogueStart;


    }

    public void OnDialogueEnd(object sender, EventArgs args)
    {
        panel.SetActive(false);
    }

    public void OnDialogueStart(object sender, EventArgs args)
    {
        panel.SetActive(true);
    }



}
