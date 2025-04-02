using System.Collections;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float interactDistance;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float upOffset;
    [SerializeField] private float backOffset;

    [Header("Others")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private GameObject playerVisual;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;

    private bool isZooming = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform targetObject;

    void Update()
    {
        PlayerInteracts();
    }

    private void PlayerInteracts()
    {
        if (!isZooming)
        {
            Ray ray = new Ray(playerCamera.position, playerCamera.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null && Input.GetMouseButton(0))
                {
                    StartZoom(hit.transform);
                    playerVisual.SetActive(false);
                    playerMovement.enabled = false;
                    mouseLook.enabled = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetCamera();
            playerMovement.enabled = true;
            mouseLook.enabled = true;
            playerVisual.SetActive(true);
        }
    }

    private void StartZoom(Transform target)
    {
        isZooming = true;
        targetObject = target;
        originalPosition = playerCamera.position;
        originalRotation = playerCamera.rotation;

        Vector3 zoomPosition = target.position + target.forward * -backOffset + Vector3.up * upOffset;
        StartCoroutine(ZoomTo(zoomPosition, target.rotation));

        ObjectRotator rotator = target.GetComponent<ObjectRotator>();
        if (rotator != null)
        {
            rotator.StartInspection();
        }
    }

    private IEnumerator ZoomTo(Vector3 targetPosition, Quaternion targetRotation)
    {
        float countdownToZoom = 0;
        while (countdownToZoom < 1)
        {
            countdownToZoom += Time.deltaTime * zoomSpeed;
            playerCamera.position = Vector3.Lerp(originalPosition, targetPosition, countdownToZoom);
            playerCamera.rotation = Quaternion.Lerp(originalRotation, targetRotation, countdownToZoom);
            yield return null;
        }
    }

    private void ResetCamera()
    {
        isZooming = false;
        StartCoroutine(ZoomTo(originalPosition, originalRotation));

        if (targetObject != null)
        {
            ObjectRotator rotator = targetObject.GetComponent<ObjectRotator>();
            if (rotator != null)
            {
                rotator.StopInspection();
            }
        }
    }
}