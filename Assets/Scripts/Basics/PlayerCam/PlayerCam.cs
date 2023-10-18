using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    public float xRotation;
    public float yRotation;

    private Camera camera;
    private bool canMove = true;

    void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (canMove == false) return;


        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }


    private void OnEnable()
    {
        EventSystem.JumpscareTriggered += OnJumpscareTriggered;
        EventSystem.JumpscareEnded += OnJumpscareEnded;
    }

    private void OnDisable()
    {
        EventSystem.JumpscareTriggered -= OnJumpscareTriggered;
        EventSystem.JumpscareEnded -= OnJumpscareEnded;
    }

    private void OnDestroy()
    {
        EventSystem.JumpscareTriggered -= OnJumpscareTriggered;
        EventSystem.JumpscareEnded -= OnJumpscareEnded;
    }


    private void OnJumpscareTriggered(object sender, EventArgs args)
    {
        if (args is EventArgsJumpscare jumpArgs)
        {
            canMove = false;
        }
    }

    private void OnJumpscareEnded(object sender, EventArgs args)
    {
        if (args is EventArgsJumpscare jumpArgs)
        {
            canMove = true;

            xRotation = 0;
        }



    }

}
