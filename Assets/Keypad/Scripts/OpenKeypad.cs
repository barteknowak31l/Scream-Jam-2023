
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    //private Camera cam;
    //private void Awake() => cam = Camera.main;
    //private void Update()
    //{
    //    var ray = cam.ScreenPointToRay(Input.mousePosition);

    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (Physics.Raycast(ray, out var hit))
    //        {
    //            if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
    //            {
    //                keypadButton.PressButton();
    //            }
    //        }
    //    }
    //}
    public GameObject keypadOB;
    public GameObject keypadText;

    private bool inReach;

    void Start()
    {
        inReach = false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            keypadText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            keypadText.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inReach) 
        {
            keypadOB.SetActive(true);
            Debug.Log("dziala");
        }
        
    }
}
