using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField] private string requiredKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (InventoryManager.Instance.HasItem(requiredKey))
            {
                Debug.Log("Welcome");
                InventoryManager.Instance.RemoveItem(requiredKey);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("You need the key");
            }
        }
    }
}
