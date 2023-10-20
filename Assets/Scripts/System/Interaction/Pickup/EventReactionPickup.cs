using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReactionPickup : MonoBehaviour, EventReaction
{

    public Item item; // item na ktorym ma zostac wykonana interakcja

    // lista opcji, ktore maja sie wykonac po evencie, mozna dodac inne opcje, potem wystarczy w 
    // edytorze wybrac opcje i wszystko sie samo wykona - mozna dostosowac wtedy do roznych scenariuszy co ma sie wykonac
    public enum EventReactionPickupOptions
    { 
        AddToInventory = 0,
        PlaySound = 1,
        Destroy = 2
    }

    // lista tych opcji
    public List<EventReactionPickupOptions> options;


    // subskrypcja eventu - ta funkcja musi byc wywolana w onEnable
    public void SubscribeToEvent()
    {
        EventSystem.InteractionPickupItem += OnEvent;
    }

    // unsub eventu - ta funkcja musi byc wywolana w onDisable i onDestroy - na dole sa te funkcje
    public void UnsubscribeFromEvent()
    {
        EventSystem.InteractionPickupItem -= OnEvent;

    }


    public void OnEvent(object sender, EventArgs args)
    {
        // sprawdzasz czy to na pewno dobry event 
        if (args is EventArgsInteractionPickupItem intargs)
        {

            // sprawdz, czy item z eventu to ten item, na ktorym ma byc wykonana reakcja
            if (item.itemID != intargs.m_Item.itemID) return;


            options.Sort(); // WAZNE!, musi byc posortowane, zeby destroy wykonal sie zawsze na koncu

            // przechodzisz po posortowanej juz liscie, wiec destroy na pewno bedzie ostatnie
            foreach(EventReactionPickupOptions option in options)
            {
                switch (option) // w zaleznosci od opcji wykonuje odpowienia reakcje
                {
                    case EventReactionPickupOptions.Destroy:
                        {
                            OnDestroyOption();
                            break;
                        }
                    case EventReactionPickupOptions.AddToInventory:
                        {
                            OnAddToInventoryOption(intargs.m_Item);
                            break;
                        }
                    case EventReactionPickupOptions.PlaySound:
                        {
                            OnPlaySoundOption();
                            break;
                        }
                }

            }
        }
    }


    // a tu definicje poszczegolnych akcji

    private void OnDestroyOption()
    {
        Destroy(gameObject);
    }

    private  void OnPlaySoundOption()
    {
        //TO DO
        // wywolac event dzwiekowy jak juz bedzie system dzwiekow
    }

    private void OnAddToInventoryOption(Item item)
    {

        InventorySystemImpl.Instance.AddItem(item);

    }


    /////////////////////////////////////////////////////////////
    private void OnEnable()
    {
        SubscribeToEvent();
    }
    private void OnDestroy()
    {
        UnsubscribeFromEvent();
    }
    private void OnDisable()
    {
        UnsubscribeFromEvent();
    }

}
