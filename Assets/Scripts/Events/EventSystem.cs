using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventSystem
{

    ///////////////// SYGNATURA EVENTÓW ( patrzeæ gdzie DUZE litery! ) /////////////
    //  
    // public delegate void On<NazwaSystemu><Czynnoœæ>(object sender, EventArgs args)
    // public static event On<NazwaSystemu><Czynnoœæ> <System><Czynnoœæ>
    // public static void Call<NazwaSystemu><Czynnoœæ> (object sender, EventArgs args)
    // {
    //      <System><Czynnoœæ>?.Invoke(sender, args);
    // }
    //


    //////////////////////////////////////////////////////////////////
    ///                                                            ///
    ///                      DIALOGUE EVENTS                       ///
    ///                                                            ///
    //////////////////////////////////////////////////////////////////

    public delegate void OnDialogueStart(object sender, EventArgs args);
    public static event OnDialogueStart DialogueStart;
    public static void CallDialogueStart(object sender, EventArgs args)
    {
        DialogueStart?.Invoke(sender, args);
    }


    public delegate void OnDialogueEnd(object sender, EventArgs args);
    public static event OnDialogueStart DialogueEnd;
    public static void CallDialogueEnd(object sender, EventArgs args)
    {
        DialogueEnd?.Invoke(sender, args);
    }

    public delegate void OnDialogueNext(object sender, EventArgs args);
    public static event OnDialogueStart DialogueNext;
    public static void CallDialogueNext(object sender, EventArgs args)
    {
        DialogueNext?.Invoke(sender, args);
    }


    //////////////////////////////////////////////////////////////////
    ///                                                            ///
    ///                      INVENTORY EVENTS                      ///
    ///                                                            ///
    //////////////////////////////////////////////////////////////////
   

    public delegate void OnInventoryItemAdd(object sender, EventArgs args);
    public static event OnInventoryItemAdd InventoryItemAdd;
    public static void CallInventoryItemAdd(object sender, EventArgs args)
    {
        InventoryItemAdd?.Invoke(sender, args);
    }
    //////////////////////////////////////////////////////////////////
    ///                                                            ///
    ///                      INTERACTION EVENTS                    ///
    ///                                                            ///
    //////////////////////////////////////////////////////////////////
    public delegate void OnInteraction(object sender, EventArgs args);
    public static event OnInteraction Interaction;
    public static void CallOnInteraction(object sender, EventArgs args)
    {
        Interaction?.Invoke(sender, args);
    }

}