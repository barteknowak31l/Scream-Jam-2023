using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Wall Check")]
    public float detectionLength;
    public float sphereCastRadius;
    public float wallForce;
    private RaycastHit wallHit;
    public LayerMask whatIsWall;
    private bool wallFront;
    
    [Header("Slope Handing")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private bool canMove = true;

    public MovementState state;
    public enum MovementState
    {
        walking
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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

    void Update()
    {

        if (canMove == false) return;

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        //wall check
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, moveDirection, out wallHit, detectionLength, whatIsWall);
        MyInput();
        SpeedControl();
        StateHandler();
        //drag
        if (grounded)
            rb.drag = groundDrag;
        else 
            rb.drag = 0;

        if (wallFront)
        {
            Vector3 pushDirection = moveDirection * wallForce;
            rb.velocity = pushDirection;
        }
    }

    private void FixedUpdate()
    {
        if (canMove == false) return;

        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
       
    }

    private void StateHandler()
    {
        //Walking
        if(grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
    }

    private void MovePlayer()
    {
        //moving
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //on slope
        if(OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if(rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }
        //on ground
        else if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        rb.useGravity = !OnSlope();
    }
    private void SpeedControl()
    {
        //speed on slope
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }
        //limit velocity if needed
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }
    //slope
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection() 
    { 
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    private void OnJumpscareTriggered(object sender, EventArgs args)
    {
        if(args is EventArgsJumpscare jumpArgs)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            canMove = false;
        }
    }

    private void OnJumpscareEnded(object sender, EventArgs args)
    {
        if (args is EventArgsJumpscare jumpArgs)
        {
            canMove = true;
        }
    }
}
