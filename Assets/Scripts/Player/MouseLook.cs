using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private Transform playerT;
    [SerializeField] private float mouseSensitivityX;
    

    private float mouseX;
    private float mouseY;

    private void Update()
    {
        HandleInput();
        HandleMouseLooking();
    }

    private void HandleInput()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivityX;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivityX;
    }

    private void HandleMouseLooking()
    {
        mouseY = Mathf.Clamp(mouseY, -90, 90);
        playerT.rotation = Quaternion.Euler(0, mouseX, 0);
        playerCam.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
    }
}
