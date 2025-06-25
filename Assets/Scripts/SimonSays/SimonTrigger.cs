using UnityEngine;

public class SimonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject startSimonSays;

    private void OnMouseDown()
    {
        SimonGameManager.Instance.StartSimonSaysGame();
        startSimonSays.SetActive(false);
    }
}
