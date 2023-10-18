using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscarePositionSetter : MonoBehaviour
{
    public Camera camera;
    public float playerHeight = 1.5f;

    void Update()
    {

        Vector3 newPosition = camera.transform.position + camera.transform.forward;
        transform.position = newPosition;
        transform.position = new Vector3(transform.position.x, playerHeight, transform.position.z);
    }
}
