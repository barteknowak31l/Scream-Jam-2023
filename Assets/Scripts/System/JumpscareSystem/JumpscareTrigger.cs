using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{

    public Transform m_JumpscarePosition;
    public GameObject m_FlashingScreen;

    public Jumpscare m_Jumpscare;

    public bool TriggerOnlyOnce = true;

    private bool m_IsTriggered;
    private bool m_IsTriggeredOnce;
    private GameObject m_InstantiatedJumpscare;

    public Camera camera;

    private void Start()
    {
        JumpscareSystemImpl.Instance.Attach(m_Jumpscare);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!m_IsTriggered)
        {
            if(TriggerOnlyOnce && !m_IsTriggeredOnce)
            {
                TriggerJumpscare();
            }

            if(!TriggerOnlyOnce)
            {
                TriggerJumpscare();
            }
        }
    }

    private void TriggerJumpscare()
    {

        JumpscareSystemImpl.Instance.Trigger(m_Jumpscare, m_JumpscarePosition);
        //camera.transform.LookAt(m_JumpscareTransform);
        camera.transform.eulerAngles = new Vector3(0, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);


        m_JumpscarePosition.LookAt(camera.transform);
        m_InstantiatedJumpscare = Instantiate(m_Jumpscare.model, m_JumpscarePosition.position, m_JumpscarePosition.rotation ,m_JumpscarePosition);
        m_InstantiatedJumpscare.transform.Translate(m_Jumpscare.offset, Space.World);

        camera.transform.LookAt(m_JumpscarePosition);


        AudioSource src = m_InstantiatedJumpscare.AddComponent<AudioSource>();
        src.clip = m_Jumpscare.scream;
        src.Play();

        m_FlashingScreen.SetActive(true);

        m_IsTriggered = true;
        m_IsTriggeredOnce = true;


        StartCoroutine(EndJumpscare());


    }

    private IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(m_Jumpscare.duration + 0.05f);

        JumpscareSystemImpl.Instance.EndJumpscare(m_Jumpscare);

        m_FlashingScreen.SetActive(false);
        Destroy(m_InstantiatedJumpscare);

        m_IsTriggered = false;

    }

}
