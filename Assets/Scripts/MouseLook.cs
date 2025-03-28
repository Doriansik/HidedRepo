using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform playerT;
    [SerializeField] private float mouseSens;
    private float mouseX;
    private float mouseY;

    private void Update()
    {
        HandleInput();
        HandleMovement();
    }

    private void HandleInput()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
    }

    private void HandleMovement()
    {
        mouseY = Mathf.Clamp(mouseY, -90, 90);
        playerT.rotation = Quaternion.Euler(0, mouseX, 0);
        playerCam.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
    }
}
