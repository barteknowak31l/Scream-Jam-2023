using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystemImpl : MonoBehaviour, DialogueSystem
{

    private Dictionary<int, Dialogue> m_Dialogues;
    private int m_CurrentDialogueId;
    private Dialogue m_CurrentDialogue;

    public void DialogueNext()
    {
        if(m_CurrentDialogue != null)
        {
            string line = m_CurrentDialogue.GetNextLine();
            if(line != null)
                Debug.Log(line);
        }
        else 
        {
            Debug.Assert(false, "DialogueSystemImpl.DialogueNext : no dialogue has been initiated ");
        }
    }

    public void DialogueStart(int p_DialogueId)
    {
        m_CurrentDialogueId = p_DialogueId;
        m_CurrentDialogue = m_Dialogues.GetValueOrDefault(p_DialogueId, null);

        if(m_CurrentDialogue != null)
        {
            string line = m_CurrentDialogue.StartDialogue();
            Debug.Log(line);

        }
        else
        {
            Debug.Assert(false, "DialogueSystemImpl.DialogueStart : Wrong dialogue id");
        }

    }

    public void OnAttach()
    {
        Debug.Log(this.GetType() + " OnAttach");

        m_Dialogues = new Dictionary<int, Dialogue>();

        m_CurrentDialogueId = -1;

        Dialogue dialogue = new Dialogue(1);

        dialogue.AddLine("To jest testowy dialog");
        dialogue.AddLine("linia 2");
        dialogue.AddLine("Koniec");
        m_Dialogues.Add(1, dialogue);


        Dialogue dialogue2 = new Dialogue(2);
        dialogue2.AddLine("To jest inny testowy dialog");
        dialogue2.AddLine("Inna linia 2");
        dialogue2.AddLine("Inny koniec");
        m_Dialogues.Add(2, dialogue2);


    }

    public void OnDetach()
    {
        Debug.Log(this.GetType() + " OnDetach");
        m_Dialogues.Clear();
    }

    public void OnUpdate()
    {
       if(Input.GetKeyDown(KeyCode.A))
       {
            DialogueStart(1);
       }

       if(Input.GetKeyDown(KeyCode.S))
        {
            DialogueNext();
        }

    }


    void OnEnable()
    {
        CustomSystemImpl.Instance.Attach(this);
    }

    void OnDisable()
    {
        CustomSystemImpl.Instance.Detach(this);
    }

    void OnDestroy()
    {
        CustomSystemImpl.Instance.Detach(this);
    }

}
