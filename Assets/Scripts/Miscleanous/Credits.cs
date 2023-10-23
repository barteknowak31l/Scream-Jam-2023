using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private Animator anim;
    public Dialogue dialog;
    public AudioSource endingTheme;
    public GameObject replay;


    public Flashlight flashlight;

    private void Start()
    {
        anim = GetComponent<Animator>();
        EventSystem.DialogueEnd += OnDialogEnd;

    }

    private void Update()
    {
        if(replay.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ReplayOnClick();
            }
        }
    }

    public void OnDialogEnd(object sender, EventArgs args)
    {
        if (args is EventArgsDialogueEnd dArgs)
        {
            if (dArgs.m_DialogueID == dialog.m_Id)
            {
                anim.Play("credits");
                endingTheme.Play();
                flashlight.DisableFlickering();
            }
        }
    }


    public void enableReplay()
    {
        replay.SetActive(true);
    }
    public void ReplayOnClick()
    {
        SceneManager.LoadScene(0);
    }

}
