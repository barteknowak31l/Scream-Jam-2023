using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventorySystem : CustomSystem
{
    public void OnDialogueStart(object sender, EventArgs args);
    public void OnDialogueNext(object sender, EventArgs args);
    public void OnDialogueEnd(object sender, EventArgs args);
}
