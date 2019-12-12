using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 10;
    public float disFromTarget = 5;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public bool lockCursor;
    public float rotSmoothTime = 0.12f;
    Vector3 rotSmoothVelocity;
    Vector3 currentRotation;

    float yaw, pitch;

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(-pitch, yaw), ref rotSmoothVelocity, rotSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * disFromTarget;
    }
}
