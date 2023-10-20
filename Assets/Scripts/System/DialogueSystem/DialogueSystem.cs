using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DialogueSystem : CustomSystem
{
    public void DialogueStart(int p_DialogueId);
    public void DialogueNext();
    public void AddToList(Dialogue dialogue);


}
