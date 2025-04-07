using UnityEngine;

public class SlidingPuzzleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SlidingPuzzleGameManager.Instance.StartPuzzlingSlideGame();
        }
    }
}
