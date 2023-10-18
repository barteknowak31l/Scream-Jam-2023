using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamJumpscareAnimation : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        EventSystem.JumpscareTriggered += OnJumpscareTriggered;
        EventSystem.JumpscareEnded += OnJumpscareEnded;

        animator.Play("CameraFOvNormal");


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
        if(args is EventArgsJumpscare jumpArgs)
        {
            animator.Play("CameraFOVonJumpscare");
        }
    }

    private void OnJumpscareEnded(object sender, EventArgs args)
    {
        if (args is EventArgsJumpscare jumpArgs)
        {
            animator.Play("CameraFOvNormal");
        }
    }

}
