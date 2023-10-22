using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollRoomBlockade : MonoBehaviour
{
    public List<Item> dolls;
    private List<Item> dollsOwned;
    public GameObject blockade;

    private void Start()
    {
        EventSystem.InteractionPickupItem += EnableBlockade;
        dollsOwned = new List<Item>();

}

public void EnableBlockade(object sender, EventArgs args)
    {
        if(args is EventArgsInteractionPickupItem iArgs)
        {
            if(dolls.Contains(iArgs.m_Item))
            {
                blockade.SetActive(true);
                dollsOwned.Add(iArgs.m_Item);
                if(dollsOwned.Count >= 6)
                {
                    Destroy(gameObject);
                }
            }
        }
    }


}
