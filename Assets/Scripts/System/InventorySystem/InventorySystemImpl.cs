using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemImpl : MonoBehaviour, InventorySystem
{
    public static InventorySystemImpl Instance;
    public List<Item> items = new List<Item>();
    private void Awake()
    {
        Instance = this;
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(int itemID)
    {
        Item itemToRemove = items.Find(item => item.itemID == itemID);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
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
       
    }
    public void OnDetach()
    {
        
    }
    public void OnUpdate()
    {
       
    }

    //void OnEnable()
   // {
    //    CustomSystemImpl.Instance.Attach(this);
    //}

   // void OnDisable()
    //{
    //    CustomSystemImpl.Instance.Detach(this);
    //}

   // void OnDestroy()
  // {
   //     CustomSystemImpl.Instance.Detach(this);
   // }


}
