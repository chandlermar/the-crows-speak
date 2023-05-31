using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    Vector3 velocity;
    Vector3 playerMovementInput;
    private Vector3 lastMovementInput;
    private float lastFootstepTime;
    public float movementThreshold = 0.1f;
    public float footstepDelay = 0.5f;
    Vector2 PlayerMouseInput;
    Vector3 MoveVector;

    float xRot;


    Transform playerCamera;

    public CharacterController controller;

    private float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float mouseSensitivity;
    [SerializeField] float gravity = -9.81f;



    //mechanic variables

    public float walkSpeed;
    public float sprintSpeed;


    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        controller = GetComponent<CharacterController>();
        speed = walkSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        PlayerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Mathf.Clamp(Input.GetAxisRaw("Mouse Y"), -90, 90));

        MovePlayer();
        MoveCamera();
        Sprint();
    }

    void MovePlayer()
    {
        if (controller.isGrounded)
        {
            MoveVector = transform.TransformDirection(playerMovementInput);
            velocity = AdjustVelocityToSlope(velocity);
            velocity.y += -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            MoveVector = transform.TransformDirection(playerMovementInput);
            velocity.y -= gravity * -2f * Time.deltaTime;
        }

        controller.Move(MoveVector * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, lastMovementInput) > movementThreshold)
        {
            float timeSinceLastFootstep = Time.time - lastFootstepTime;
            if (timeSinceLastFootstep >= footstepDelay)
            {
                AudioMgr.inst.PlayFootstep();
                lastFootstepTime = Time.time;
            }
            lastMovementInput = transform.position;
        }
    }

    void MoveCamera()
    {
        xRot -= PlayerMouseInput.y * mouseSensitivity;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.Rotate(transform.rotation.x, PlayerMouseInput.x * mouseSensitivity, transform.rotation.z);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }


    private Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        var ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f))
        {
            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedVelocity = slopeRotation * velocity;

            if (adjustedVelocity.y < 0)
            {
                return adjustedVelocity;
            }
        }

        return velocity;
    }
}