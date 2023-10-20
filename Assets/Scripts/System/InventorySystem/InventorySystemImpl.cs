using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemImpl : MonoBehaviour, InventorySystem
{
    public static InventorySystemImpl Instance { get; private set; }
    public List<Item> items;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        items = new List<Item>();
    }


    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(int itemID)
    {
        Debug.Log("Trying to remove item id" + itemID);
        Item itemToRemove = items.Find(item => item.itemID == itemID);
        Debug.Log("Item to remove "+itemToRemove.itemName);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
            EventSystem.CallInventoryItemRemove(this,new EventArgsInventoryItemRemove {m_ItemID = itemToRemove.itemID });
        }


    }

    bool InventorySystem.HasItem(int itemID)
    {
        return items.Exists(item => item.itemID == itemID);
    }
    private void Start()
    {
 
    }

    public void OnAttach()
    {
        Debug.Log(this.GetType() + "OnAttach");
    }
    public void OnDetach()
    {
        Debug.Log(this.GetType() + "OnDetach");
    }
    public void OnUpdate()
    {
       // DEBUG
       if(Input.GetKeyDown(KeyCode.P))
        {
            PrintItemNames();
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

    public void PrintItemNames()
    {
        string msg = "";
        foreach(Item i in items)
        {
            msg += i.name;
            msg += " ";
        }
        Debug.Log("ITEMS IN EQ: " + msg);
    }
}
