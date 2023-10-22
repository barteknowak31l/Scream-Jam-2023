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

        if(tekst.Contains("Joe:"))
        {
            text.color = Color.yellow;
        }

        if (tekst.Contains("???:") || tekst.Contains("Mammon:"))
        {
            text.color = Color.red;
        }

        if (tekst.Contains("Narrator:") )
        {
            text.color = Color.white;
        }


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
