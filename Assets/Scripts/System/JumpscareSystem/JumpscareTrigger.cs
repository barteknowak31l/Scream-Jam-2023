using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{

    public GameObject m_PlayerCamera;
    public GameObject m_JumpscareCamera;
    public Transform m_JumpscarePosition;
    public GameObject m_FlashingScreen;

    public Jumpscare m_Jumpscare;

    private GameObject m_InstantiatedJumpscare;

    private void Start()
    {
        JumpscareSystemImpl.Instance.Attach(m_Jumpscare);
    }

    private void OnTriggerEnter(Collider other)
    {
           
    }

    private void TriggerJumpscare()
    {
        m_InstantiatedJumpscare = Instantiate(m_Jumpscare.m_Model, m_JumpscarePosition.position, Quaternion.identity);
        
        AudioSource src = m_InstantiatedJumpscare.AddComponent<AudioSource>();
        src.clip = m_Jumpscare.m_Scream;
        src.Play();

        m_JumpscareCamera.SetActive(true);
        m_PlayerCamera.SetActive(false);
        m_FlashingScreen.SetActive(true);


        JumpscareSystemImpl.Instance.Trigger(m_Jumpscare);


        StartCoroutine(EndJumpscare());


    }

    private IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(m_Jumpscare.m_Duration + 0.05f);

        m_PlayerCamera.SetActive(true);
        m_JumpscareCamera.SetActive(false);
        m_FlashingScreen.SetActive(false);
        Destroy(m_InstantiatedJumpscare);

        JumpscareSystemImpl.Instance.EndJumpscare(m_Jumpscare);

    }

}
