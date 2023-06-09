using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity;
    private float currentCameraRotationX = 0.0f;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    void Update()
    {
        GetInput();
        Move();
    }

    private void Move()
    {
        currentCameraRotationX += xRotation * mouseSensitivity;
        transform.localEulerAngles = new Vector3(-Mathf.Clamp(currentCameraRotationX, -90.0f, 90.0f), 0.0f, 0.0f);
    }
    
    private void GetInput()
    {
        xRotation = Input.GetAxisRaw("Mouse Y");
        yRotation = Input.GetAxisRaw("Mouse X");
    }
}
