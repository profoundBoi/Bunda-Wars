using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float gravity = -22f;

    [Header("Jump / Bounce")]
    public float bounceForce = 12f;

    [Header("Rotation")]
    public float rotationSpeed = 180f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;

    private bool jumpPressed;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Rotate();
        HandleMovement();
        HandleJumpAndGravity();
    }

    void Rotate()
    {
        float turn = lookInput.x;
        transform.Rotate(Vector3.up * turn * rotationSpeed * Time.deltaTime);
    }

    void HandleMovement()
    {
        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        // Horizontal movement stored (no Move call yet)
        velocity.x = move.x * moveSpeed;
        velocity.z = move.z * moveSpeed;
    }

    void HandleJumpAndGravity()
    {
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (jumpPressed)
            {
                velocity.y = bounceForce;
                jumpPressed = false;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // ONE Move call (always runs)
        controller.Move(velocity * Time.deltaTime);
    }

    // INPUT SYSTEM EVENTS
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
            jumpPressed = true;
    }
}
