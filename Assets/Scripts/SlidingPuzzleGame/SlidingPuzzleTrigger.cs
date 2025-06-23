using UnityEngine;

public class SlidingPuzzleTrigger : MonoBehaviour
{
    private void OnMouseDown()
    {
        SlidingPuzzleGameManager.Instance.ChangeCameraToPuzzle();
        Debug.Log("SlidingPuzzle");
    }
}
