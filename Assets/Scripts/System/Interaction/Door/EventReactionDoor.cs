using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReactionDoor : MonoBehaviour, EventReaction
{

    public Door door; // item na ktorym ma zostac wykonana interakcja
    public bool isOpen = false;

    public string doorOpen;
    public string doorClose;

    // lista opcji, ktore maja sie wykonac po evencie, mozna dodac inne opcje, potem wystarczy w 
    // edytorze wybrac opcje i wszystko sie samo wykona - mozna dostosowac wtedy do roznych scenariuszy co ma sie wykonac
    public enum EventReactionDoorOptions
    {
        InteractWithDoor = 0,
        PlaySound = 1,
        Destroy = 2
    }

    // lista tych opcji
    public List<EventReactionDoorOptions> options;


    // subskrypcja eventu - ta funkcja musi byc wywolana w onEnable
    public void SubscribeToEvent()
    {
        EventSystem.InteractionDoor += OnEvent;
    }

    // unsub eventu - ta funkcja musi byc wywolana w onDisable i onDestroy - na dole sa te funkcje
    public void UnsubscribeFromEvent()
    {
        EventSystem.InteractionDoor -= OnEvent;

    }


    public void OnEvent(object sender, EventArgs args)
    {
        // sprawdzasz czy to na pewno dobry event 
        if (args is EventArgsInteractionDoor intargs)
        {

            // sprawdz, czy drzwi z eventu to te drzwi, na ktorym ma byc wykonana reakcja
            if (door.doorID != intargs.m_Door.doorID) return;


            options.Sort(); // WAZNE!, musi byc posortowane, zeby destroy wykonal sie zawsze na koncu

            // przechodzisz po posortowanej juz liscie, wiec destroy na pewno bedzie ostatnie
            foreach (EventReactionDoorOptions option in options)
            {
                switch (option) // w zaleznosci od opcji wykonuje odpowienia reakcje
                {
                    case EventReactionDoorOptions.Destroy:
                        {
                            OnDestroyOption();
                            break;
                        }
                    case EventReactionDoorOptions.InteractWithDoor:
                        {
                            OnInteractionWithDoor(intargs.m_Door);
                            break;
                        }
                    case EventReactionDoorOptions.PlaySound:
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

    }

    private void OnPlaySoundOption()
    {
        //TO DO
        // wywolac event dzwiekowy jak juz bedzie system dzwiekow
    }

    private void OnInteractionWithDoor(Door door)
    {

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


// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

