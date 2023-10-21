using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour, EventReaction
{

    public enum TriggerType
    {
        OnTriggerEnter, OnEvent
    }

    public enum SupportedEvents
    {
        None,PickupItem,DoorOpened
    }

    [HideInInspector]
    public TriggerType triggerType = TriggerType.OnTriggerEnter;

    [HideInInspector]
    public SupportedEvents eventType = SupportedEvents.None;

    [HideInInspector]
    public Item item;

    [HideInInspector]
    public Door door;


    private Transform m_JumpscarePosition;
    public GameObject m_FlashingScreen;

    public Jumpscare m_Jumpscare;
    public float m_Delay = 0.0f;
    public bool TriggerOnlyOnce = true;

    private bool m_IsTriggered;
    private bool m_IsTriggeredOnce;
    private GameObject m_InstantiatedJumpscare;

    private Camera camera;
    private Transform player;
    private float RotationSpeed = 500;

    public string m_Name;



    private void Start()
    {
        JumpscareSystemImpl.Instance.Attach(m_Jumpscare);
        m_JumpscarePosition = GameObject.FindGameObjectWithTag("JumpscarePosition").transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerType != TriggerType.OnTriggerEnter) return;

        if(!m_IsTriggered)
        {
            if(TriggerOnlyOnce && !m_IsTriggeredOnce)
            {
                Invoke("TriggerJumpscare", m_Delay);     }

            if(!TriggerOnlyOnce)
            {
                Invoke("TriggerJumpscare", m_Delay);
            }
        }
    }

    private void TriggerJumpscare()
    {

        JumpscareSystemImpl.Instance.Trigger(m_Jumpscare, m_JumpscarePosition);

        Quaternion rotation = Quaternion.Euler(player.rotation.eulerAngles.x, player.rotation.eulerAngles.y + 180, player.rotation.eulerAngles.z);
        m_InstantiatedJumpscare = Instantiate(m_Jumpscare.model, player.transform.position + player.transform.forward + m_Jumpscare.offset, rotation ,player.transform);


        AudioSource src = m_InstantiatedJumpscare.AddComponent<AudioSource>();
        src.clip = m_Jumpscare.scream;
        src.Play();

        m_FlashingScreen.SetActive(true);

        m_IsTriggered = true;
        m_IsTriggeredOnce = true;


        StartCoroutine(EndJumpscare());


    }

    private void Update()
    {
        if(m_IsTriggered)
        {
            CameraSlerp();
        }
    }

    private void CameraSlerp()
    {

        if (camera.transform.eulerAngles.x > 0 && camera.transform.eulerAngles.x < 270)
        {
            if (camera.transform.eulerAngles.x < 5)
            {
                camera.transform.eulerAngles = new Vector3(0.0f, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
            }
            else
                camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x - RotationSpeed * Time.deltaTime, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
        }

        else if (camera.transform.eulerAngles.x > 270)
        {
            if (camera.transform.eulerAngles.x > 355)
            {
                camera.transform.eulerAngles = new Vector3(0.0f, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
            }
            else
                camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x + RotationSpeed * Time.deltaTime, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);

        }
    }

    private IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(m_Jumpscare.duration + 0.05f);

        JumpscareSystemImpl.Instance.EndJumpscare(m_Jumpscare);

        m_FlashingScreen.SetActive(false);
        Destroy(m_InstantiatedJumpscare);

        m_IsTriggered = false;

    }


    private void OnValidate()
    {
        if (triggerType == TriggerType.OnTriggerEnter)
        {
            Collider myCollider = GetComponent<Collider>();

            if (myCollider == null)
            {
                Debug.LogError("JumpscareTrigger " + m_Name + " nie ma aktywnego Collider'a!");
            }
        }
    }

    public void OnEvent(object sender, EventArgs args)
    {
        switch (eventType)
        {
            case SupportedEvents.None:
                {
                    break;
                }
            case SupportedEvents.PickupItem:
                {

                    if (args is EventArgsInteractionPickupItem pickupArgs)
                    {
                        if (pickupArgs.m_Item.itemID == item.itemID)
                            Invoke("TriggerJumpscare", m_Delay);
                    }
                    break;
                }
            case SupportedEvents.DoorOpened:
                {

                    if (args is EventArgsDoorUnlocked dArgs)
                    {
                        if (dArgs.m_Door.doorID == door.doorID)
                            Invoke("TriggerJumpscare", m_Delay);
                    }
                    break;
                }
        }
    }

    public void SubscribeToEvent()
    {
        if (triggerType != TriggerType.OnEvent) return;

        switch (eventType)
        {
            case SupportedEvents.None:
                {
                    break;
                }
            case SupportedEvents.PickupItem:
                {
                    EventSystem.InteractionPickupItem += OnEvent;
                    break;
                }
            case SupportedEvents.DoorOpened:
                {
                    EventSystem.DoorUnlocked += OnEvent;
                    break;
                }
        }
    }

    public void UnsubscribeFromEvent()
    {
        if (triggerType != TriggerType.OnEvent) return;

            switch (eventType)
        {
            case SupportedEvents.None:
                {
                    break;
                }
            case SupportedEvents.PickupItem:
                {
                    EventSystem.InteractionPickupItem -= OnEvent;
                    break;
                }
            case SupportedEvents.DoorOpened:
                {
                    EventSystem.DoorUnlocked -= OnEvent;
                    break;
                }
        }

    }

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


