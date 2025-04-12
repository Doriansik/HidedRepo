using TMPro;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField] private string requiredKey;
    [SerializeField] private GameObject wardrobePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (InventoryManager.Instance.HasItem(requiredKey))
        {
            InventoryManager.Instance.RemoveItem(requiredKey);
            Destroy(gameObject);
        }
        else
        {
            wardrobePanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wardrobePanel.SetActive(false);
    }
}
