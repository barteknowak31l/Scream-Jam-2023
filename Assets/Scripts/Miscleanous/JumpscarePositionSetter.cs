using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscarePositionSetter : MonoBehaviour
{
    public Camera camera;

    void Update()
    {
        transform.position  = camera.transform.position + camera.transform.forward;
    }
}
