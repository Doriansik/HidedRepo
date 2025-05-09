using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform playerT;
    [SerializeField] private float mouseSensitivity;
    private float mouseX;
    private float mouseY;

    private void Update()
    {
        HandleInput();
        HandleMouseLooking();
    }

    private void HandleInput()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;
    }

    private void HandleMouseLooking()
    {
        mouseY = Mathf.Clamp(mouseY, -90, 90);
        playerT.rotation = Quaternion.Euler(0, mouseX, 0);
        playerCam.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
    }
}
