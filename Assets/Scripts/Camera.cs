using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Distance / Height")]
    [SerializeField] private float distance = 10f;
    [SerializeField] private float heightOffset = 3f;

    [Header("Zoom")]
    [SerializeField] private float zoomStep = 0.1f;
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private float zoomSmoothSpeed = 10f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float minPitch = -20f;
    [SerializeField] private float maxPitch = 60f;

    [Header("Follow Smoothing")]
    [SerializeField] private float followSmoothSpeed = 10f;

    private float yaw;
    private float pitch = 20f;

    private float currentDistance;
    private float targetDistance;

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("FollowCamera: No target assigned!");
            return;
        }

        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        currentDistance = distance;
        targetDistance = distance;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        HandleCursor();
        HandleMouseLook();
        HandleZoom();
        UpdateCameraPosition();
    }

    void HandleCursor()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void HandleMouseLook()
    {
        if (Mouse.current == null || Cursor.lockState != CursorLockMode.Locked)
            return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        yaw += mouseDelta.x * mouseSensitivity * 0.02f;
        pitch -= mouseDelta.y * mouseSensitivity * 0.02f;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    void HandleZoom()
    {
        if (Mouse.current == null)
            return;

        float scroll = Mouse.current.scroll.ReadValue().y;

        if (Mathf.Abs(scroll) > 0.01f)
        {
            targetDistance -= scroll * zoomStep;
            targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
        }

        currentDistance = Mathf.Lerp(
            currentDistance,
            targetDistance,
            zoomSmoothSpeed * Time.deltaTime
        );
    }

    void UpdateCameraPosition()
    {
        Vector3 targetPos = target.position + Vector3.up * heightOffset;

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0f, 0f, -currentDistance);

        Vector3 desiredPosition = targetPos + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSmoothSpeed * Time.deltaTime
        );

        transform.LookAt(targetPos);
    }
}