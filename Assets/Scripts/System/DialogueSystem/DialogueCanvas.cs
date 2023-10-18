using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueCanvas : MonoBehaviour
{
  
   public void Canvas(string tekst, Color color)
    {
        TMP_Text text =  GetComponent<TMP_Text>();
        text.text = tekst;
        text.color = color;
    }


}
