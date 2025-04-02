using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string keyName;

    private void OnMouseDown()
    {
        InventoryManager.Instance.AddItem(keyName);
        Destroy(gameObject);
    }
}
