using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRelativeMovementToggle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cam;

    [Header("Toggle")]
    [SerializeField] private bool cameraRelativeMovement = false;
    [SerializeField] private Key toggleKey = Key.T;

    [Header("Movement")]
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float maxSpeed = 12f;

    private float originalSpeed;

    void Start()
    {
        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }

        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (cam == null && Camera.main != null)
        {
            cam = Camera.main.transform;
        }

        originalSpeed = playerController.speed;
    }

    void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current[toggleKey].wasPressedThisFrame)
        {
            cameraRelativeMovement = !cameraRelativeMovement;

            if (cameraRelativeMovement)
            {

                playerController.speed = 0f;
            }
            else
            {
                playerController.speed = originalSpeed;
            }

        }
    }

    void FixedUpdate()
    {
        if (!cameraRelativeMovement)
        {
            return;
        }

        Vector2 input = GetInput();

        if (input == Vector2.zero || cam == null)
        {
            return;
        }

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * input.y + camRight * input.x;
        moveDir.Normalize();

        Vector3 velocity = rb.linearVelocity;
        Vector3 flatVel = new Vector3(velocity.x, 0f, velocity.z);

        float speedInDir = Vector3.Dot(flatVel, moveDir);

        if (speedInDir < maxSpeed)
        {
            rb.AddForce(moveDir * acceleration, ForceMode.Force);
        }
    }

    Vector2 GetInput()
    {
        if (Keyboard.current == null)
        {
            return Vector2.zero;
        }

        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) input.y += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;
        if (Keyboard.current.dKey.isPressed) input.x += 1;

        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        return input;
    }
}