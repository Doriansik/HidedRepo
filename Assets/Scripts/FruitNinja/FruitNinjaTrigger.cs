using UnityEngine;

public class FruitNinjaTrigger : MonoBehaviour
{
    [SerializeField] private GameObject fruitNinjaManagers;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fruitNinjaManagers.SetActive(true);
            FruitNinjaManager.Instance.NewGame();
        }
    }
}
