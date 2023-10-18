using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue 
{

    // Public members
    public int m_Id { get; set; }
    public int m_CurrentLine { get; private set; }

    // Public methods

    public Dialogue(int p_Id)
    {
        this.m_Id = p_Id;
        m_Lines = new List<string>();
    }

    public void AddLine(string p_Dialogue)
    {
        m_Lines.Add(p_Dialogue);
    }

    public string StartDialogue()
    {
        m_CurrentLine = 0;
        // call dialogue start event

        EventSystem.CallDialogueStart(this, new EventArgsDialogueStart { m_DialogueID = m_Id });

        return GetNextLine();
    }

    public string GetNextLine()
    {
        if (m_CurrentLine >= m_Lines.Count)
        {
            DialogueEnd();
            return null;
        }

        if (m_CurrentLine == -1)
        {
            return null;
        }


        EventSystem.CallDialogueNext(this, new EventArgsDialogueNext { m_DialogueID = m_Id, m_CurrentLine = this.m_CurrentLine });
        return m_Lines[m_CurrentLine++];
    }

    // Private members
    private List<string> m_Lines;



    // Private methods

    private void DialogueEnd()
    {
        EventSystem.CallDialogueEnd(this, new EventArgsDialogueEnd { m_DialogueID = m_Id });
        m_CurrentLine = -1;
    }

}
