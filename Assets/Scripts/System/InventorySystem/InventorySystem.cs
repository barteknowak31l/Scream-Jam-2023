using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventorySystem : CustomSystem
{
    public void AddItem(Item item);
    public void RemoveItem(int itemID);
    public bool HasItem(int itemID);

    /// to tylko do debugowania
    public void PrintItemNames();

}
