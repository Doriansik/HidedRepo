using UnityEngine;

public class SimonTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SimonGameManager.Instance.StartSimonSaysGame();
        }
    }
}
