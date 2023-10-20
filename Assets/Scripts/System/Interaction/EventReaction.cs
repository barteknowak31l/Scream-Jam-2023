using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EventReaction
{
    public void OnEvent(object sender, EventArgs args);

    public void SubscribeToEvent();
    public void UnsubscribeFromEvent();

}
