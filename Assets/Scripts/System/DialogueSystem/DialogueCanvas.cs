using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueCanvas : MonoBehaviour
{
  
   public void Canvas(string tekst)
    {
        GetComponent<TMP_Text>().text = tekst;
    }


}
