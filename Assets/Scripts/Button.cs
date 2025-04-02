using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private void OnMouseDown()
    {
        door.SetActive(false);
    }
}
