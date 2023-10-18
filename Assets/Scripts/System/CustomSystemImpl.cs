using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSystemImpl : MonoBehaviour, CustomSystem
{

    // Singleton declaration
    private static CustomSystemImpl s_Instance;


    public static CustomSystemImpl Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        m_Systems = new List<CustomSystem>();
    }


    // public methods

    public List<CustomSystem> GetSystems() { return m_Systems; }

    public void OnAttach() { }
    public void OnDetach() { }
    public void OnUpdate() { }

    public void CallUpdate()
    {
        foreach (CustomSystem system in m_Systems)
        {
            system.OnUpdate();
        }
    }
    public void Attach(CustomSystem system)
    {
        m_Systems.Add(system);
        system.OnAttach();
    }
    public void Detach(CustomSystem system)
    {
        m_Systems.Remove(system);
        system.OnDetach();
    }

    public void Update()
    {
        CallUpdate();
    }


    // private members
    private List<CustomSystem> m_Systems;

}
