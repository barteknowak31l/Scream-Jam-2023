using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventSystem
{

    ///////////////// SYGNATURA EVENT�W ( patrze� gdzie DUZE litery! ) /////////////
    //  
    // public delegate void On<NazwaSystemu><Czynno��>(object sender, EventArgs args)
    // public static event On<NazwaSystemu><Czynno��> <System><Czynno��>
    // public static void Call<NazwaSystemu><Czynno��> (object sender, EventArgs args)
    // {
    //      <System><Czynno��>?.Invoke(sender, args);
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
        Debug.Log(sender.ToString() + " called DialogueStart");
        DialogueStart?.Invoke(sender, args);
    }


    public delegate void OnDialogueEnd(object sender, EventArgs args);
    public static event OnDialogueStart DialogueEnd;
    public static void CallDialogueEnd(object sender, EventArgs args)
    {
        Debug.Log(sender.ToString() + " called DialogueEnd");
        DialogueEnd?.Invoke(sender, args);
    }

    public delegate void OnDialogueNext(object sender, EventArgs args);
    public static event OnDialogueStart DialogueNext;
    public static void CallDialogueNext(object sender, EventArgs args)
    {
        Debug.Log(sender.ToString() + " called DialogueNext");
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
        Debug.Log(sender.ToString() + " called InventoryItemAdd");
        InventoryItemAdd?.Invoke(sender, args);
    }

    public delegate void OnInventoryItemRemove(object sender, EventArgs args);
    public static event OnInventoryItemRemove InventoryItemRemove;
    public static void CallInventoryItemRemove(object sender, EventArgs args)
    {
        EventArgsInventoryItemRemove iArgs = (EventArgsInventoryItemRemove)args;
        Debug.Log(sender.ToString() + " called InventoryItemRemove ID: " +iArgs.m_ItemID);
        InventoryItemAdd?.Invoke(sender, args);
    }


    //////////////////////////////////////////////////////////////////
    ///                                                            ///
    ///                     JUMPSCARE EVENTS                       ///
    ///                                                            ///
    //////////////////////////////////////////////////////////////////

    public delegate void OnJumpscareTriggered(object sender, EventArgs args);
    public static event OnJumpscareTriggered JumpscareTriggered;
    public static void CallJumpscareTriggered(object sender, EventArgs args)
    {
        Debug.Log(sender.ToString() + " called JumpscareTriggered");
        JumpscareTriggered?.Invoke(sender, args);
    }

    public delegate void OnJumpscareEnded(object sender, EventArgs args);
    public static event OnJumpscareEnded JumpscareEnded;
    public static void CallJumpscareEnded(object sender, EventArgs args)
    {
        Debug.Log(sender.ToString() + " called JumpscareEnded");
        JumpscareEnded?.Invoke(sender, args);
    }
    //////////////////////////////////////////////////////////////////
    ///                                                            ///
    ///                      INTERACTION EVENTS                    ///
    ///                                                            ///
    //////////////////////////////////////////////////////////////////
    public delegate void OnInteractionPickupItem(object sender, EventArgs args);
    public static event OnInteractionPickupItem InteractionPickupItem;
    public static void CallOnInteractionPickupItem(object sender, EventArgs args)
    {
        EventArgsInteractionPickupItem a = (EventArgsInteractionPickupItem)args;
        Debug.Log(sender.ToString() + " called InteractionPickupItem ID: " + a.m_Item.itemID);
        InteractionPickupItem?.Invoke(sender, args);
    }

}