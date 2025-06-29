using FMOD.Studio;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerT;
    [SerializeField] private float moveSpeed;
    private float moveX;
    private float moveZ;
    [SerializeField] private ZoomingManager zm;
    private Rigidbody rb;
    
    
        private void Update()
    {
        HandleInput();
        HandleMovement();
        UpdateSound();
    }

    private void HandleInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    private void HandleMovement()
    {
        playerT.Translate(moveX * moveSpeed * Time.deltaTime, 0f, moveZ * moveSpeed * Time.deltaTime);
    }

    private void UpdateSound()
    {
        if (moveX != 0 || moveZ != 0)
        {
            zm.StartFootsteps();
        }
        else
        {
            zm.StopFootsteps();
        }
        
    }
}