using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionSystem : CustomSystem
{

    void TriggerInteraction(GameObject interactedObject);  // Metoda do wywo³ywania interakcji
}
