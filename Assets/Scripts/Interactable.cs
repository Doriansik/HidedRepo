using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static Interactable Instance;

    [SerializeField] private string objectName;

    private void Awake()
    {
        Instance = this;
    }

    public void Interact()
    {
        Debug.Log("ObjectType " + objectName);
    }
}

