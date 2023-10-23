using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamGenerator : MonoBehaviour
{
    public AudioSource scream1;
    public AudioSource scream2;
    public AudioSource scream3;
    public AudioSource scream4;

    public float delay = 40.0f;
    public float randomDelay = 10.0f;

    public Dialogue turnOffAfterThisDialogue;


    void Start()
    {
        EventSystem.DialogueStart += OnDialogueStart;
        StartCoroutine(GenerateScreams());
    }


    IEnumerator GenerateScreams()
    {
        float d = 0;
        int scr = 0;
        while (true)
        {
            d = delay + Random.Range(-randomDelay, randomDelay);
            yield return new WaitForSeconds(d);

            // random scream
            scr = Random.Range(0, 4);

            switch (scr)
            {
                case 0:
                    {
                        scream1.Play();
                        break;
                    }
                case 1:
                    {
                        scream2.Play();
                        break;
                    }
                case 2:
                    {
                        scream3.Play();
                        break;
                    }
                case 3:
                    {
                        scream4.Play();
                        break;
                    }
            }


        }
    }
    public void OnDialogueStart(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueStart dArgs)
        {
            if (dArgs.m_DialogueID == turnOffAfterThisDialogue.m_Id)
            {
                Destroy(this);
            }
        }
    }

}
