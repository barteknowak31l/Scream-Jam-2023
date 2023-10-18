using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionSystem : CustomSystem
{
    event Action<GameObject> OnInteraction;  // Zdarzenie do obs³ugi interakcji
    void TriggerInteraction(GameObject interactedObject);  // Metoda do wywo³ywania interakcji
}
