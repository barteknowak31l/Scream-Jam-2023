using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerWithCamera : MonoBehaviour
{
    public Transform cameraTransform;
    private void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
    }
}
