using UnityEngine;

public interface IInteractable
{
    void Interact(Transform interactionTransform);
    Transform GetTransform();
}
