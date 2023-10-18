using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareSystemImpl : MonoBehaviour, JumpscareSystem
{
    // Singleton declaration
    private static JumpscareSystemImpl s_Instance;
    public static JumpscareSystemImpl Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        s_Jumpscares = new List<Jumpscare>();
    }


    // private members
    private  List<Jumpscare> s_Jumpscares;
    
    public void Attach(Jumpscare p_Jumpscare)
    {
        s_Jumpscares.Add(p_Jumpscare);
    }

    public void EndJumpscare(Jumpscare p_Jumpscare)
    {
        EventSystem.CallJumpscareEnded(null, new EventArgsJumpscare { m_Jumpscare = p_Jumpscare });

    }

    public void OnAttach()
    {
        Debug.Log(this.GetType() + " OnAttach()");
    }

    public void OnDetach()
    {
        Debug.Log(this.GetType() + " OnDetach()");

    }

    public void OnUpdate()
    {
    }

    public void Trigger(Jumpscare p_Jumpscare)
    {
        EventSystem.CallJumpscareTriggered(this, new EventArgsJumpscare { m_Jumpscare = p_Jumpscare }); 

    }

    void OnEnable()
    {
        CustomSystemImpl.Instance.Attach(this);
    }

    void OnDisable()
    {
        CustomSystemImpl.Instance.Detach(this);
    }

    void OnDestroy()
    {
        CustomSystemImpl.Instance.Detach(this);
    }

}
