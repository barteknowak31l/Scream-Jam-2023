using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineHandle : MonoBehaviour
{
    private Outline outline;
    private Color color1 = Color.green;
    private Color color2;

    void Start()
    {
        outline= GetComponent<Outline>();
        color2= new Color(0,0,0,0);
        outline.OutlineColor = color2;
    }
    public void OutlineOn()
    {
        outline.OutlineColor = color1;
        CancelInvoke("OutlineOff");
    }
    public void OutlineOff()
    {
        outline.OutlineColor = color2;

    }


    private void Update()
    {
        Invoke("OutlineOff",0.1f);
    }

}
