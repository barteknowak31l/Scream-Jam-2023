using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump=true;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

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
        walking,
        sprinting,
        crouching,
        air
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        startYScale = transform.localScale.y;
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
        MyInput();
        SpeedControl();
        StateHandler();
        //drag
        if (grounded)
            rb.drag = groundDrag;
        else 
            rb.drag = 0;
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
        //jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        //start crouch
        if (Input.GetKeyDown(crouchKey)) 
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        //stop crouch
        if(Input.GetKeyUp(crouchKey)) 
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void StateHandler()
    {
        //Crouching
        if (Input.GetKey(crouchKey)) 
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }
        //Sprinting
        else if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        //Walking
        else if(grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        //Air
        else 
        { 
        state = MovementState.air;
        }
    }

    private void MovePlayer()
    {
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
            //in air
        } else if(!grounded)
            {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        }
        rb.useGravity = !OnSlope();
    }
    private void SpeedControl()
    {
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

    private void Jump()
    {
        exitingSlope = true;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope = false;
    }

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
