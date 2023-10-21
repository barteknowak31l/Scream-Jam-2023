using UnityEngine;
using static EventSystem;

public class Fire : MonoBehaviour
{
    public GameObject fire;
    public float czasDoZaplonu = 3f;

   
    void FireOff()
    {
        fire.SetActive(true);
    }

    public void OnDialogueEnd(object sender, EventArgs args)
    {

        Invoke("FireOff", czasDoZaplonu+Random.Range(-1,1));


    }

    private void OnEnable()
    {
        EventSystem.DialogueEnd += OnDialogueEnd;

    }
    private void OnDestroy()
    {
        EventSystem.DialogueEnd -= OnDialogueEnd;

    }
    private void OnDisable()
    {
        EventSystem.DialogueEnd -= OnDialogueEnd;

    }

}