using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventArgs
{
    // Po tej klasie dziedzicz� klasy przechowuj�ce argumenty poszczeg�lnych event�w
}



//////////////////////////////////////////////////////////////////
///                                                            ///
///                      DIALOGUE EVENTS ARGS                  ///
///                                                            ///
//////////////////////////////////////////////////////////////////

public class EventArgsDialogueStart : EventArgs
{
    public int m_DialogueID { get; set; }
}

public class EventArgsDialogueEnd : EventArgs
{
    public int m_DialogueID { get; set; }
}

public class EventArgsDialogueNext : EventArgs
{
    public int m_DialogueID { get; set; }
    public int m_CurrentLine { get; set; }
}



//////////////////////////////////////////////////////////////////
///                                                            ///
///                   INVENTORY EVENTS ARGS                    ///
///                                                            ///
//////////////////////////////////////////////////////////////////

public class EventArgsInventoryItemAdd : EventArgs
{
    public int m_ItemID { get; set; }
}



//////////////////////////////////////////////////////////////////
///                                                            ///
///                   JUMPSCARE EVENTS ARGS                    ///
///                                                            ///
//////////////////////////////////////////////////////////////////
public class EventArgsJumpscare : EventArgs
{
    public Jumpscare m_Jumpscare{ get; set; }
    public Transform m_JumpscareTransform{ get; set; }
//////////////////////////////////////////////////////////////////
///                                                            ///
///                   INTERACTION EVENTS ARGS                  ///
///                                                            ///
//////////////////////////////////////////////////////////////////

public class EventArgsInteraction : EventArgs
{
    public Item m_Item { get; set; }
}
