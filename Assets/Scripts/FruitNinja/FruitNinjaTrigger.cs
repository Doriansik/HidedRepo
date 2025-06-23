using UnityEngine;

public class FruitNinjaTrigger : MonoBehaviour
{
    [SerializeField] private GameObject fruitNinjaManagers;

    private void OnMouseDown()
    {
        fruitNinjaManagers.SetActive(true);
        FruitNinjaManager.Instance.NewGame();
        Debug.Log("FruitNinja");
    }
}
