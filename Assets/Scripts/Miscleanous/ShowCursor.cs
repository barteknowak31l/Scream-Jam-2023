using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{

    private Transform InteractorSource;
    public float InteractRange = 2; // dalem defaultowo 1
    public GameObject cursor;


    private void Start()
    {
        InteractorSource = GameObject.FindAnyObjectByType<Camera>().transform;
    }

    void Update()
    {
        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.CompareTag("Keypad"))
            {
                cursor.SetActive(true);
            }
            else
            {
                cursor.SetActive(false);
            }

        }
    }
}
