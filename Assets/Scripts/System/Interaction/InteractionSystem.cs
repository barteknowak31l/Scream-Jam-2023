using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionSystem : CustomSystem
{
    event Action<GameObject> OnInteraction;  // Zdarzenie do obs�ugi interakcji
    void TriggerInteraction(GameObject interactedObject);  // Metoda do wywo�ywania interakcji
}
