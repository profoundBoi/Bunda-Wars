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
    private CameraThirdPerson cam;

    [Header("Shooting")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootCooldown = 0.2f;

    private float nextShootTime;

    private CharacterController controller;
    private Camera playerCamera;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 velocity;

    private bool jumpPressed;
    private bool shootPressed;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        cam = GetComponentInChildren<CameraThirdPerson>();
    }

    void Update()
    {
        Rotate();
        HandleMovement();
        HandleJumpAndGravity();

        if (shootPressed)
        {
            Shoot();
            shootPressed = false;
        }
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

        controller.Move(velocity * Time.deltaTime);
    }

    void Shoot()
    {
        if (Time.time < nextShootTime) return;
        nextShootTime = Time.time + shootCooldown;

        Ray aimRay = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        Vector3 targetPoint;

        if (Physics.Raycast(aimRay, out RaycastHit hit, 100f))
            targetPoint = hit.point;
        else
            targetPoint = aimRay.origin + aimRay.direction * 100f;

        Vector3 direction = (targetPoint - firePoint.position).normalized;

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.LookRotation(direction)
        );
    }
    // INPUT SYSTEM EVENTS
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();

        if (cam != null)
            cam.SetLookInput(lookInput.y);
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
            jumpPressed = true;
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed)
            shootPressed = true;
    }
}
