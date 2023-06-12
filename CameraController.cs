using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables
    [SerializeField] private float mouseSensitivityX;
    [SerializeField] private float mouseSensitivityY;
    [SerializeField] private float maxRotationX = 90f;
    [SerializeField] private float minRotationX = -90f;
    [SerializeField] private float startRotationY = 35f;

    // References
    private Transform parent;
    private float rotationX = 0f;

    private void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;

        // Set initial Y rotation of the camera
        rotationX = startRotationY;
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        // Rotate camera in Y axis
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        parent.Rotate(Vector3.up, mouseX);
    }
}
