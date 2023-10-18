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
    public float RotationSpeed;
    private Quaternion startRotation;
    private Quaternion targetRotation;


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
        //camera.transform.eulerAngles = new Vector3(0, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);

/*        Transform t = camera.transform;
        t.LookAt(m_JumpscarePosition);

        startRotation = camera.transform.rotation;
        targetRotation = t.rotation;*/


        m_JumpscarePosition.LookAt(camera.transform);
        m_InstantiatedJumpscare = Instantiate(m_Jumpscare.model, m_JumpscarePosition.position, m_JumpscarePosition.rotation ,m_JumpscarePosition);
        m_InstantiatedJumpscare.transform.Translate(m_Jumpscare.offset, Space.World);

       // camera.transform.LookAt(m_JumpscarePosition);


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
        Debug.Log(camera.transform.eulerAngles.x);


        if (camera.transform.eulerAngles.x > 0 && camera.transform.eulerAngles.x < 270)
        {
            if(camera.transform.eulerAngles.x < 5)
            {
                camera.transform.eulerAngles = new Vector3(0.0f, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
            }
            else
            camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x - RotationSpeed * Time.deltaTime, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
        }

        else if (camera.transform.eulerAngles.x > 270 )
        {
            if (camera.transform.eulerAngles.x > 355 )
            {
                camera.transform.eulerAngles = new Vector3(0.0f, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
            }
            else
            camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x + RotationSpeed * Time.deltaTime, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);


            Debug.Log("siema");
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

}
