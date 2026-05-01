using UnityEngine;
using UnityEngine.InputSystem;

public class ExpandedMovement : MonoBehaviour
{
    private Rigidbody rb;

    /* [Header("Sprint")]
    [SerializeField] private float sprintAcceleration = 6f;
    [SerializeField] private float sprintMaxSpeed = 12f; */

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private int maxJumps = 2;

    [Header("Wall Jump")]
    [SerializeField] private float wallJumpHorizontalForce = 6f;
    [SerializeField] private float wallJumpVerticalForce = 7f;

    /* [Header("Air Dash")]
    [SerializeField] private float dashSpeed = 16f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f; */

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool wasGrounded = false;
    private bool isTouchingWall = false;
    // private bool hasAirDashed = false;
    // private bool isDashing = false;

    private Vector3 wallNormal = Vector3.zero;
    // private Vector3 dashDirection = Vector3.zero;
    // private float dashTimer = 0f;
    // private float dashCooldownTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /* if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.deltaTime;
        } */

        if (Keyboard.current == null)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            HandleJump();
        }

        bool shiftPressed =
            Keyboard.current.leftShiftKey.wasPressedThisFrame ||
            Keyboard.current.rightShiftKey.wasPressedThisFrame;

        /* if (shiftPressed && CanAirDash())
        {
            StartAirDash();
        } */
    }

    void FixedUpdate()
    {
        if (isGrounded && !wasGrounded)
        {
            jumpCount = 0;
            // hasAirDashed = false;
            // isDashing = false;
            rb.useGravity = true;
        }

        wasGrounded = isGrounded;

        /* if (isDashing)
        {
            PerformAirDash();
            return;
        } */

        // HandleSprint();
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = false;
        // isTouchingWall = false;
        // wallNormal = Vector3.zero;

        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 normal = contact.normal;

            if (normal.y > 0.5f)
            {
                isGrounded = true;
            }

            if (Mathf.Abs(normal.y) < 0.3f)
            {
                // isTouchingWall = true;
                // wallNormal = normal;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        // isTouchingWall = false;
        // wallNormal = Vector3.zero;
    }

    void HandleJump()
    {
        /* if (isDashing)
        {
            return;
        } */

        Vector3 currentVelocity = GetVelocity();

        bool normalJumpEnabled = jumpForce > 0f && maxJumps > 0;
        bool wallJumpEnabled = wallJumpHorizontalForce > 0f || wallJumpVerticalForce > 0f;

        if (isGrounded && normalJumpEnabled)
        {
            SetVelocity(new Vector3(currentVelocity.x, 0f, currentVelocity.z));
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpCount = 1;
            return;
        }

        if (isTouchingWall && wallJumpEnabled)
        {
            Vector3 jumpDir = wallNormal * wallJumpHorizontalForce + Vector3.up * wallJumpVerticalForce;
            SetVelocity(new Vector3(currentVelocity.x, 0f, currentVelocity.z));
            rb.AddForce(jumpDir, ForceMode.VelocityChange);

            if (jumpCount < 1)
            {
                jumpCount = 1;
            }

            return;
        }

        if (!isGrounded && normalJumpEnabled && jumpCount < maxJumps)
        {
            SetVelocity(new Vector3(currentVelocity.x, 0f, currentVelocity.z));
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpCount++;
        }
    }

    /* void HandleSprint()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (sprintAcceleration <= 0f || sprintMaxSpeed <= 0f)
        {
            return;
        }

        bool shiftHeld =
            Keyboard.current.leftShiftKey.isPressed ||
            Keyboard.current.rightShiftKey.isPressed;

        if (!shiftHeld || !isGrounded)
        {
            return;
        }

        Vector3 inputDir = GetKeyboardMoveDirection();

        if (inputDir == Vector3.zero)
        {
            return;
        }

        Vector3 velocity = GetVelocity();
        Vector3 flatVelocity = new Vector3(velocity.x, 0f, velocity.z);

        float currentSpeedInInputDir = Vector3.Dot(flatVelocity, inputDir);

        if (currentSpeedInInputDir < sprintMaxSpeed)
        {
            rb.AddForce(inputDir * sprintAcceleration, ForceMode.Force);
        }
    } */

    /* bool CanAirDash()
    {
        if (dashSpeed <= 0f || dashDuration <= 0f)
        {
            return false;
        }

        if (isGrounded)
        {
            return false;
        }

        if (hasAirDashed)
        {
            return false;
        }

        if (isDashing)
        {
            return false;
        }

        if (dashCooldownTimer > 0f)
        {
            return false;
        }

        return true;
    } */

    /* void StartAirDash()
    {
        dashDirection = GetKeyboardMoveDirection();

        if (dashDirection == Vector3.zero)
        {
            Vector3 flatForward = transform.forward;
            flatForward.y = 0f;

            if (flatForward.sqrMagnitude < 0.001f)
                flatForward = Vector3.forward;

            dashDirection = flatForward.normalized;
        }

        isDashing = true;
        hasAirDashed = true;
        dashTimer = dashDuration;
        dashCooldownTimer = dashCooldown;
        rb.useGravity = false;

        SetVelocity(new Vector3(dashDirection.x * dashSpeed, 0f, dashDirection.z * dashSpeed));
    } */

    /* void PerformAirDash()
    {
        dashTimer -= Time.fixedDeltaTime;

        SetVelocity(new Vector3(dashDirection.x * dashSpeed, 0f, dashDirection.z * dashSpeed));

        if (dashTimer <= 0f)
        {
            isDashing = false;
            rb.useGravity = true;
        }
    } */

    Vector3 GetKeyboardMoveDirection()
    {
        if (Keyboard.current == null)
        {
            return Vector3.zero;
        }

        Vector3 dir = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            dir += Vector3.forward;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            dir += Vector3.back;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            dir += Vector3.left;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            dir += Vector3.right;
        }

        dir = dir.normalized;

        Camera cam = Camera.main;
        if (cam == null)
        {
            return dir;
        }

        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        return (camForward * dir.z + camRight * dir.x).normalized;
    }

    Vector3 GetVelocity()
    {
        return rb.linearVelocity;
    }

    void SetVelocity(Vector3 newVelocity)
    {
        rb.linearVelocity = newVelocity;
    }
}