using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour, Interactable
{
    public GameObject fire;
    public Item lighter;
    public bool isLit = false;

    public void TriggerInteraction(GameObject interactedObject)
    {
        if (InventorySystemImpl.Instance.HasItem(lighter))
        {
            fire.SetActive(true);
            isLit = true;
        }

    }
}
