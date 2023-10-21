using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTestDoorAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayOpen()
    {
        anim.Play("open");
    }

}
