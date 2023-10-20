using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "Door/doors")]
public class Door : ScriptableObject
{
    public int doorID;// Unikalne ID drzwi

    // Metoda, która inicjuje drzwi
    public void Initialize(int id)
    {
        doorID = id;

    }
}
