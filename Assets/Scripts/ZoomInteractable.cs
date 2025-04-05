using UnityEngine;

public class ZoomInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ZoomingManager zoomingManager;

    public void Interact(Transform interactor)
    {
        zoomingManager.StartZoom(transform);
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
