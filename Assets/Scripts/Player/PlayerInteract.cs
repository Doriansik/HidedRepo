using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private ZoomingManager zoomingManager;
    [SerializeField] private BlockCursor blockCursor;

    private bool isInspecting = false;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(transform);
                zoomingManager.StartZoom(interactable.GetTransform());
                isInspecting = true;
                blockCursor.ShowCursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isInspecting)
        {
            blockCursor.HideCursor();
            isInspecting = false;
            zoomingManager.ResetCamera();
        }
    }


    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 1.5f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }
        return closestInteractable;
    }
}
