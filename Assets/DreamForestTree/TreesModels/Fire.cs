using UnityEngine;
using static EventSystem;

public class Fire : MonoBehaviour
{
    public GameObject fire;
    public Dialogue dialogue;
    public float czasDoZaplonu = 3f;

   
    void FireOff()
    {
        fire.SetActive(true);
        Debug.Log("FIRE");
    }

    public void OnDialogueStart(object sender, EventArgs args)
    {

        if(args is EventArgsDialogueStart dArgs)
        {
            if(dArgs.m_DialogueID == dialogue.m_Id)
            {
                Invoke("FireOff", czasDoZaplonu+Random.Range(-1,1));
            }
        }



    }

    private void OnEnable()
    {
        EventSystem.DialogueStart += OnDialogueStart;

    }
    private void OnDestroy()
    {
        EventSystem.DialogueStart -= OnDialogueStart;

    }
    private void OnDisable()
    {
        EventSystem.DialogueStart -= OnDialogueStart;

    }

}