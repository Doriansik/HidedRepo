using System.Collections;
using UnityEngine;

public class ZoomingManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float upOffset;
    [SerializeField] private float backOffset;

    [Header("Scripts References")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;

    [Header("Others")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private GameObject playerVisual;

    private bool isZooming = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform targetObject;

    public void StartZoom(Transform target)
    {
        if (isZooming) return;

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

        playerVisual.SetActive(false);
        playerMovement.enabled = false;
        mouseLook.enabled = false;
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

    public void ResetCamera()
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

        playerVisual.SetActive(true);
        playerMovement.enabled = true;
        mouseLook.enabled = true;
    }
}
