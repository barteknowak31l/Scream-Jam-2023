using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "Door")]
public class Door : MonoBehaviour
{
    public int itemID;        // Unikalne ID przedmiotu
    public string itemName;   // Nazwa przedmiotu
    public string description; // Opis przedmiotu

    // Metoda, która inicjuje przedmiot
    public void Initialize(int id, string name, string desc)
    {
        itemID = id;
        itemName = name;
        description = desc;

    }
}
